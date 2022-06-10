using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Signature
{
    internal static class Settings
    {

        internal static void GetDirInitials(ComboBox box)
        {
            string[] initialsFiles = Directory.GetFiles(@"Initials\");
            for(int i = 0; i < initialsFiles.Length; i++)
            {
                Console.WriteLine(initialsFiles[i]);
                box.Items.Add(initialsFiles[i].Substring(initialsFiles[i].IndexOf('\\') + 1));
            }
        }

        internal static RSA_Encrypt.KeyPair GetInitialsKey(string nameFile)
        {
            string[] fileLine = File.ReadAllLines(nameFile);

            return RSA_Encrypt.KeyPair.Generate(BigInteger.Parse(fileLine[1]), BigInteger.Parse(fileLine[2]));
        }

        internal static void CreateInitials(string initials, RSA_Encrypt.KeyPair key)
        {
            using (StreamWriter sw = new StreamWriter(@"Initials\" + initials + ".settings"))
            {
                sw.WriteLine(initials);
                sw.WriteLine(key.private_.n);
                sw.WriteLine(key.private_.d);
                sw.Close();
            }
        }

        internal static byte[] GetFileSignature(string pathFile)
        {
            return File.ReadAllBytes(pathFile);
        }

        internal static bool CreateFileSignature(string nameFile, string dirPath, byte[] signature)
        {
            File.Create(dirPath + nameFile + ".sig").Close();
            File.WriteAllBytes(dirPath + nameFile + ".sig", signature);
            return true;
        }

        internal static byte[] GetHashSignature(byte[] hash)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
                return md5.ComputeHash(hash);
        }
    }
}
