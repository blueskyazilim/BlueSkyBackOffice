namespace BlueSky.Core.Cryptography
{
    using Helpers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Specifies the algorithm to be used in a <see cref="SymmetricEncryptionHelper"/> instance.
    /// </summary>
    public enum SymmetricEncryptionAlgorithm
    {
        Des = 1,
        TripleDes = 2,
        Rijndael = 3
    }

    /// <summary>
    /// A helper class around .NET's symmetric encryption routines.
    /// </summary>
    public class SymmetricEncryptionHelper : IHelper
    {
        /// <summary>
        /// Encrypts the specified plaintext
        /// </summary>
        public string Encrypt(string plainText, byte[] key, byte[] iv, SymmetricEncryptionAlgorithm algorithm, PaddingMode? paddingMode = null)
        {
            var hash = Encrypt(
                Encoding.ASCII.GetBytes(plainText),
                key,
                iv,
                algorithm,
                paddingMode);

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Encrypts the specified plaintext
        /// </summary>
        public byte[] Encrypt(byte[] plainText, byte[] key, byte[] iv, SymmetricEncryptionAlgorithm algorithm, PaddingMode? paddingMode = null)
        {
            using (SymmetricAlgorithm symmetricAlgorithm = this.GetNewSymmetricAlgorithm(key, iv, algorithm, paddingMode))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainText, 0, plainText.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                    }

                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Decrypts the specified hash.
        /// </summary>
        public string Decrypt(string hash, byte[] key, byte[] iv, SymmetricEncryptionAlgorithm algorithm, PaddingMode? paddingMode = null)
        {
            var plainText = Decrypt(
                Convert.FromBase64String(hash),
                key,
                iv,
                algorithm,
                paddingMode);

            return Encoding.ASCII.GetString(plainText);
        }

        /// <summary>
        /// Decrypts the specified hash.
        /// </summary>
        public byte[] Decrypt(byte[] hash, byte[] key, byte[] iv, SymmetricEncryptionAlgorithm algorithm, PaddingMode? paddingMode = null)
        {
            using (SymmetricAlgorithm symmetricAlgorithm = this.GetNewSymmetricAlgorithm(key, iv, algorithm, paddingMode))
            {
                using (ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(new MemoryStream(hash), decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            byte[] buffer = new byte[BufferSize];
                            int readBytes;

                            while ((readBytes = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ms.Write(buffer, 0, buffer.Length);
                            }

                            return ms.ToArray();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns a new symmetric algorithm instance to be used during the
        /// encryption/decryption operations. The algorithm to create is chosen
        /// using the algorithm field.
        /// </summary>
        private SymmetricAlgorithm GetNewSymmetricAlgorithm(byte[] key, byte[] iv, SymmetricEncryptionAlgorithm algorithm, PaddingMode? paddingMode)
        {
            SymmetricAlgorithm symmetricAlgorithm;

            switch (algorithm)
            {
                case SymmetricEncryptionAlgorithm.Des:
                    symmetricAlgorithm = new DESCryptoServiceProvider();

                    byte[] desKey = new byte[8];
                    byte[] desIV = new byte[8];

                    Array.Copy(key, 0, desKey, 0, 8);
                    Array.Copy(iv, 0, desIV, 0, 8);

                    symmetricAlgorithm.Key = desKey;
                    symmetricAlgorithm.IV = desIV;
                    break;
                case SymmetricEncryptionAlgorithm.TripleDes:
                    symmetricAlgorithm = new TripleDESCryptoServiceProvider();

                    symmetricAlgorithm.Key = key;
                    symmetricAlgorithm.IV = iv;

                    break;
                case SymmetricEncryptionAlgorithm.Rijndael:
                    symmetricAlgorithm = new RijndaelManaged();

                    symmetricAlgorithm.Key = key;
                    symmetricAlgorithm.IV = iv;

                    break;
                default:
                    throw new ArgumentOutOfRangeException("algorithm");
            }

            if (paddingMode.HasValue)
            {
                symmetricAlgorithm.Padding = paddingMode.Value;
            }

            return symmetricAlgorithm;
        }

        private const int BufferSize = 1024;
    }
}
