using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;

namespace RSA_Encrypt
{
    /// <summary>
    /// Wrapper KeyPair class, for the case when people generate keys locally.
    /// </summary>
    [DataContract]
    [Serializable]
    public class KeyPair
    {
        //After assignment, the keys cannot be touched.
        [DataMember]
        public readonly Key private_;
        [DataMember]
        public readonly Key public_;

        public KeyPair(Key private__, Key public__)
        {
            private_ = private__;
            public_ = public__;
        }

        /// <summary>
        /// Returns a keypair based on the calculated n and d values from RSA.
        /// </summary>
        /// <param name="n">The "n" value from RSA calculations.</param>
        /// <param name="d">The "d" value from RSA calculations.</param>
        /// <returns></returns>
        public static KeyPair Generate(BigInteger n, BigInteger d)
        {
            Key public_ = new Key(n, KeyType.PUBLIC);
            Key private_ = new Key(n, KeyType.PRIVATE, d);
            return new KeyPair(private_, public_);
        }
    }


    /// <summary>
    /// Class to contain RSA key values for public and private keys. All values readonly and protected
    /// after construction, type set on construction.
    /// </summary>
    [DataContract(Name = "Key", Namespace = "RSA_Encrypt")]
    [Serializable]
    public class Key
    {
        //Константы скрытого ключа, n и e являются переменными открытого ключа.
        [DataMember(Name = "n")]
        public BigInteger n { get; set; }
        [DataMember(Name = "e")]
        public int e = Constants.e;


        //Необязательная нулевая переменная D.
        //Это никогда не должно использоваться совместно в качестве элемента данных, в принципе это не должно передаваться по сети.
        public readonly BigInteger d;

        //Переменная для типа ключа.
        [DataMember(Name = "type")]
        public KeyType type { get; set; }

        //Конструктор, который устанавливает значения один раз, а затем значения постоянно недоступны для записи.
        public Key(BigInteger n_, KeyType type_, BigInteger d_)
        {
            //Catching edge cases for invalid input.
            if (type_==KeyType.PRIVATE && d_<2) { throw new Exception("Constructed as private, but invalid d value provided."); }

            //Setting values.
            n = n_;
            type = type_;
            d = d_;
        }

        //Перегрузить конструктор для ключа без значения d.
        public Key(BigInteger n_, KeyType type_)
        {
            //Улавливание крайних случаев неверного ввода.
            if (type_ == KeyType.PRIVATE) { throw new Exception("Constructed as private, but no d value provided."); }

            //Установка значений.
            n = n_;
            type = type_;
        }
    }
    
    public enum KeyType
    {
        PUBLIC,
        PRIVATE
    }
}
