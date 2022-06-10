using System;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;

namespace RSA_Encrypt
{
    public class RSA
    {
        //Генерирует пару ключей требуемой длины в битах и возвращает ее.
        public static KeyPair GenerateKeyPair(int bitlength)
        {
            //Генерация простых чисел, проверка, равен ли GCD (n-1)(p-1) и e 1.
            BigInteger q, p, n, x, d = new BigInteger();
            do
            {
                q = FindPrime(bitlength / 2);
            } while (q % Constants.e == 1);
            do
            {
                p = FindPrime(bitlength / 2);
            } while (p % Constants.e == 1);

            //Установка n в качестве QP, phi (представленного здесь как x) в tortiary.
            n = q * p;
            x = (p - 1) * (q - 1);

            //Computing D such that ed = 1%x.
            d = Maths.ModularInverse(Constants.e, x);

            //Вычисление D таким образом, чтобы ed = 1%x.
            return KeyPair.Generate(n, d);
        }

        //Находит простое число заданной длины в битах, которое будет использоваться как n и p в вычислениях ключа RSA.
        public static BigInteger FindPrime(int bitlength)
        {
            //Генерация случайного числа битовой длины.
            if (bitlength % 8 != 0)
            {
                throw new Exception("Invalid bit length for key given, cannot generate primes.");
            }

            //Заполнение байтов псевдослучайным числом.
            byte[] randomBytes = new byte[(bitlength / 8) + 1];
            Maths.rand.NextBytes(randomBytes);
            //Делаем дополнительный байт 0x0, чтобы большие цифры были без знака (маленький конец).
            randomBytes[randomBytes.Length - 1] = 0x0;

            //Установка нижнего бита и двух верхних битов числа.
            //Это гарантирует, что число нечетное, и гарантирует, что при генерации ключей установлен старший бит N.
            Utils.SetBitInByte(0, ref randomBytes[0]);
            Utils.SetBitInByte(7, ref randomBytes[randomBytes.Length - 2]);
            Utils.SetBitInByte(6, ref randomBytes[randomBytes.Length - 2]);

            while (true)
            {
                //Выполнение теста на первичность Рабина-Миллера.
                bool isPrime = Maths.RabinMillerTest(randomBytes, 40);
                if (isPrime)
                {
                    break;
                }
                else
                {
                    Utils.IncrementByteArrayLE(ref randomBytes, 2);
                    var upper_limit = new byte[randomBytes.Length];

                    //Очистка верхнего бита для неподписанного, создание верхней и нижней границ.
                    upper_limit[randomBytes.Length - 1] = 0x0;
                    BigInteger upper_limit_bi = new BigInteger(upper_limit);
                    BigInteger lower_limit = upper_limit_bi - 20;
                    BigInteger current = new BigInteger(randomBytes);

                    if (lower_limit < current && current < upper_limit_bi)
                    {
                        //Не удалось найти простое число, возвращая значение -1.
                        //Достигнут предел без каких-либо решений.
                        return new BigInteger(-1);
                    }
                }
            }

            //Возврат рабочего BigInt.
            return new BigInteger(randomBytes);
        }

        //Шифрует набор байтов при предоставлении открытого ключа.
        public static byte[] EncryptBytes(byte[] bytes, Key public_key)
        {
            //Проверка того, что размер байтов меньше n и больше 1.
            if (1 > bytes.Length || bytes.Length >= public_key.n.ToByteArray().Length)
            {
                throw new Exception("Bytes given are longer than length of key element n (" + bytes.Length + " bytes).");
            }

            //Заполнение массива для отмены подписи.
            byte[] bytes_padded = new byte[bytes.Length + 2];
            Array.Copy(bytes, bytes_padded, bytes.Length);
            bytes_padded[bytes_padded.Length - 1] = 0x00;

            //Установка старшего байта непосредственно перед данными, чтобы предотвратить потерю данных.
            bytes_padded[bytes_padded.Length - 2] = 0xFF;

            //Вычисление в качестве BigInteger операции шифрования.
            var cipher_bigint = new BigInteger();
            var padded_bigint = new BigInteger(bytes_padded);
            cipher_bigint = BigInteger.ModPow(padded_bigint, public_key.e, public_key.n);

            //Возвращает байтовый массив зашифрованных байтов.
            return cipher_bigint.ToByteArray();
        }

        //Расшифровывает набор байтов при получении закрытого ключа.
        public static byte[] DecryptBytes(byte[] bytes, Key private_key)
        {
            //Проверка того, что закрытый ключ является законным и содержит d.
            if (private_key.type != KeyType.PRIVATE)
            {
                throw new Exception("Private key given for decrypt is classified as non-private in instance.");
            }

            //Расшифровка.
            var plain_bigint = new BigInteger();
            var padded_bigint = new BigInteger(bytes);
            plain_bigint = BigInteger.ModPow(padded_bigint, private_key.d, private_key.n);

            //Удаление всех байтов заполнения, включая маркер 0xFF.
            byte[] plain_bytes = plain_bigint.ToByteArray();
            int lengthToCopy = -1;
            for (int i = plain_bytes.Length - 1; i >= 0; i--)
            {
                if (plain_bytes[i] == 0xFF)
                {
                    lengthToCopy = i;
                    break;
                }
            }

            //Проверка на предмет невозможности найти байт маркера.
            if (lengthToCopy == -1)
            {
                throw new Exception("Marker byte for padding (0xFF) not found in plain bytes.\nPossible Reasons:\n1: PAYLOAD TOO LARGE\n2: KEYS INVALID\n3: ENCRYPT/DECRYPT FUNCTIONS INVALID");
            }

            //Копирование в возвращаемый массив, возврат.
            byte[] return_array = new byte[lengthToCopy];
            Array.Copy(plain_bytes, return_array, lengthToCopy);
            return return_array;
        }

        //Метод для сериализации данного класса и последующего шифрования.
        public static LockedBytes EncryptClass(object obj, Key public_)
        {
            BinaryFormatter bf = new BinaryFormatter();
            byte[] b;
            using (var memstream = new MemoryStream())
            {
                bf.Serialize(memstream, obj);
                b = memstream.ToArray();
            }

            //Шифрование.
            return new LockedBytes(b, public_);
        }

        //Метод для десериализации данного класса и дешифрования.
        public static T DecryptClass<T>(LockedBytes encrypted, Key private_)
        {
            //Расшифровка байтов.
            byte[] decrypted = encrypted.DecryptBytes(private_);

            //Возврат к объекту.
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(decrypted, 0, decrypted.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return (T)obj;
            }
        }
    }
}
