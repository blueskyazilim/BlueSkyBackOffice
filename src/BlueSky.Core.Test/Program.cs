using BlueSky.Core.Cryptography;
using BlueSky.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSky.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Encoding.ASCII.GetBytes("Blue Sky Yazılım");
            var iv = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            var text = Hel.per<SymmetricEncryptionHelper>().Encrypt("Osman YILDIRIM", key, iv, SymmetricEncryptionAlgorithm.Rijndael);

            Console.WriteLine(text);

            var text2 = Hel.per<SymmetricEncryptionHelper>().Decrypt(text, key, iv, SymmetricEncryptionAlgorithm.Rijndael).Replace("\0","");

            Console.WriteLine(text2);

            Console.Read();
        }
    }
}
