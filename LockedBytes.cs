using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

namespace RSA_Encrypt
{
    [DataContract]
    [Serializable]
    public class LockedBytes
    {
        /// <summary>
        /// This constructor makes LockedBytes nullable.
        /// </summary>
        public LockedBytes() { }

        /// <summary>
        /// Parses, chunks and encrypts the bytes, storing as a list of encrypted byte arrays.
        /// </summary>
        /// <param name="b">The bytes to encrypt.</param>
        /// <param name="public_">The public key to encrypt with.</param>
        public LockedBytes(byte[] b, Key public_)
        {
            //Получение максимальной длины блока (длина байта открытого ключа -2) и количества блоков в заданном байтовом массиве b.
            initialByteLength = b.Length;
            maxChunkLength = public_.n.ToByteArray().Length - 4;
            chunkModulus = b.Length % maxChunkLength;
            float unroundedChunks = (float)b.Count() / (float)maxChunkLength;
            chunks = (int)Math.Ceiling(unroundedChunks);

            for (int i=0; i<chunks; i++)
            {
                //Копирование выбранной части массива b в созданный новый фрагмент.
                byte[] unencrypted = new byte[maxChunkLength];
                byte[] encrypted;
                if (i == chunks - 1 && chunkModulus != 0)
                {
                    unencrypted = new byte[chunkModulus];
                    Array.Copy(b, i * maxChunkLength, unencrypted, 0, chunkModulus);
                }
                else
                {
                    Array.Copy(b, i * maxChunkLength, unencrypted, 0, maxChunkLength);
                }

                encrypted = RSA.EncryptBytes(unencrypted, public_);

                //Добавление в список.
                byteChunks.Add(encrypted);
            }
        }

        /// <summary>
        /// Decrypts the bytes held within the class using the given private key.
        /// </summary>
        /// <param name="private_">The private key to decrypt with.</param>
        /// <returns></returns>
        public byte[] DecryptBytes(Key private_)
        {
            //Creating a list of decrypted padded bytes.
            List<byte[]> decryptedList = new List<byte[]>();
            for (int i=0; i<chunks; i++)
            {
                decryptedList.Add(RSA.DecryptBytes(byteChunks[i], private_));
            }

            //Converting back to a single byte array, returning.
            return decryptedList.SelectMany(a => a).ToArray();
        }

        //Сериализуемые свойства, зависящие от конкретного экземпляра.
        [DataMember]
        public int chunkModulus;
        [DataMember]
        public int initialByteLength;
        [DataMember]
        public int chunks;
        [DataMember]
        public int maxChunkLength;
        [DataMember]
        public List<byte[]> byteChunks = new List<byte[]>();
    }
}
