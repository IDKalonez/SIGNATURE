using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RSA_Encrypt
{
    public class Maths
    {
        public static Random rand = new Random(Environment.TickCount);

        /// <summary>
        /// A Rabin Miller primality test which returns true or false.
        /// </summary>
        /// <param name="num">The number to check for being likely prime.</param>
        /// <returns></returns>
        public static bool RabinMillerTest(BigInteger source, int certainty)
        {
            //Отфильтруем основные простые числа.
            if (source == 2 || source == 3)
            {
                return true;
            }
            //Ниже 2, и % 0? Не простые.
            if (source < 2 || source % 2 == 0)
            {
                return false;
            }

            //Нахождение четного целого числа ниже числа.
            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            //Получение случайного BigInt с использованием байтов.
            Random rng = new Random(Environment.TickCount);
            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            //Looping to check random factors.
            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    //Генерация новых случайных байтов для проверки в качестве фактора.
                    rng.NextBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= source - 2);

                //Проверка на наличие x=1 или x=s-1.
                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                {
                    continue;
                }

                //Повторение для проверки наличия простого числа.
                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                    {
                        return false;
                    }
                    else if (x == source - 1)
                    {
                        break;
                    }
                }

                if (x != source - 1)
                {
                    return false;
                }
            }

            //Все тесты не смогли доказать составность, поэтому вернём простое число.
            return true;
        }

        //Оболочка перегрузки для RabinMillerTest, которая принимает массив байтов.
        public static bool RabinMillerTest(byte[] bytes, int acc_amt)
        {
            BigInteger b = new BigInteger(bytes);
            return RabinMillerTest(b, acc_amt);
        }

        /// <summary>
        /// Performs a modular inverse on u and v,
        /// such that d = gcd(u,v);
        /// </summary>
        /// <returns>D, such that D = gcd(u,v).</returns>
        public static BigInteger ModularInverse(BigInteger u, BigInteger v)
        {
            //Объявление новых переменных в куче.
            BigInteger inverse, u1, u3, v1, v3, t1, t3, q = new BigInteger();
            //Остается в стеке, довольно маленький, поэтому нет необходимости в дополнительном времени памяти.
            BigInteger iteration;

            //Указание начальных переменных.
            u1 = 1;
            u3 = u;
            v1 = 0;
            v3 = v;

            //Начало итерации.
            iteration = 1;
            while (v3 != 0)
            {
                //Разделите и вычтите q, t3 и t1.
                q = u3 / v3;
                t3 = u3 % v3;
                t1 = u1 + q * v1;

                //Поменять местами переменные для следующего прохода.
                u1 = v1; v1 = t1; u3 = v3; v3 = t3;
                iteration = -iteration;
            }

            if (u3 != 1)
            {
                //Нет обратного, возвращает 0.
                return 0;
            }
            else if (iteration < 0)
            {
                inverse = v - u1;
            }
            else
            {
                inverse = u1;
            }

            //Return.
            return inverse;
        }

        /// <summary>
        /// Returns the greatest common denominator of both BigIntegers given.
        /// </summary>
        /// <returns>The GCD of A and B.</returns>
        public static BigInteger GCD(BigInteger a, BigInteger b)
        {
            //Цикл до тех пор, пока числа не станут нулевыми значениями.
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            //Возврат чека.
            return a == 0 ? b : a;
        }
    }
}
