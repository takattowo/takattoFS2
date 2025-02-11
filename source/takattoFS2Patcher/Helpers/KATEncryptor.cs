using System;
using System.Linq;
using System.Text;

namespace takattoFS2.Helpers
{
    class KATEncryptor
    {
        private static readonly byte xorConstant = 0x29;

        internal static string Decrypt(string st, int n)
        {
            if (n <= 0)
                return st;

            var enctped = st;
            try
            {
                byte[] data = Convert.FromBase64String(st);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)(data[i] ^ xorConstant);
                }
                enctped = Encoding.UTF8.GetString(data);
            }

            catch { }
            return Decrypt(enctped, --n);
        }

        internal static string Encrypt(string st, int n)
        {
            if (n <= 0)
                return st;

            var decrpt = st;
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(st);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)(data[i] ^ xorConstant);
                }
                decrpt = Convert.ToBase64String(data);
            }

            catch { }
            return Encrypt(decrpt, --n);
        }

        internal static string DecryptSwapping(string ww)
        {       
            string result = null;

            foreach (char ch in ww.ToCharArray()) // loop through each character in str
                result += (char)(ch - 29022000); // need to cast subtraction to char

            return result;
        }

        internal static string EncryptSwapping(string ww)
        {
            String encryptedStr = null;

            foreach (char ch in ww.ToCharArray())
                encryptedStr += (char)(ch + 29022000);

            return encryptedStr;
        }

        internal static void ConvertB(string inPath, string outPath)
        {
            if (!System.IO.File.Exists(inPath))
                throw new Exception("Input is non-existence!");
            
            if (System.IO.File.Exists(outPath))
                System.IO.File.Delete(outPath);

            using (var fdIn = new System.IO.FileStream(inPath, System.IO.FileMode.Open))
            {
                using (var fdOut = new System.IO.FileStream(outPath, System.IO.FileMode.OpenOrCreate))
                {
                    var buffer = new byte[1];
                    var readCount = 0;
                    while (true)
                    {
                        readCount += fdIn.Read(buffer, 0, 1);
                        buffer[0] = (byte)(255 - buffer[0]);
                        fdOut.Write(buffer, 0, 1);
                        if (readCount == fdIn.Length)
                            break;
                    }
                }
            }
        }


        internal static string ConvertB(string inPath)
        {
            if (!System.IO.File.Exists(inPath))
                throw new Exception("Input is non-existence!");

            using (var fdIn = new System.IO.FileStream(inPath, System.IO.FileMode.Open))
            {
                var buffer = new byte[fdIn.Length];
                var readCount = fdIn.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = (byte)(255 - buffer[i]);
                }

                return Encoding.UTF8.GetString(buffer); // Convert the byte array to a string
            }
        }

        internal static void ConvertBFromString(string content, string outPath)
        {
            if (System.IO.File.Exists(outPath))
                System.IO.File.Delete(outPath);
            
            byte[] input = Encoding.UTF8.GetBytes(content);
            
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (byte)(255 - input[i]);
            }

            System.IO.File.WriteAllBytes(outPath, input);
            input = null;
        }

        internal static string ConvertBFromStringToString(string content)
        {
            byte[] input = Encoding.UTF8.GetBytes(content);

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (byte)(255 - input[i]);
            }

            return Encoding.UTF8.GetString(input);
        }
    }
}
