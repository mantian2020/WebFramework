using System;
using System.Text;
using System.Security.Cryptography;

namespace CommonHelper.Security
{
    /// <summary>
    /// 非对称加密类-RSA
    /// </summary>
    internal class RSACryptoSecurity : IAsymmetricSecurity
    {
        private string privateKey = "";
        private string publicKey = "";
        private RSACryptoServiceProvider crypt;

        public RSACryptoSecurity()
        {
            crypt = new RSACryptoServiceProvider();
        }

        public RSACryptoSecurity(string keyContainerName)
        {
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = keyContainerName;

            crypt = new RSACryptoServiceProvider(cp);
        }

        #region IAsymmetricSecurity 成员

        /// <summary>
        /// 私钥解密
        /// </summary>
        /// <param name="text">密文</param>
        /// <returns>明文</returns>
        public string PrivateKeyDecrypt(string text)
        {
            UTF8Encoding enc = new UTF8Encoding();

            byte[] bytes = Convert.FromBase64String(text);
            byte[] decryptbyte;

            crypt.FromXmlString(privateKey);
            decryptbyte = crypt.Decrypt(bytes, false);

            crypt.Clear();

            return enc.GetString(decryptbyte);
        }

        /// <summary>
        /// 公钥加密
        /// </summary>
        /// <param name="text">明文</param>
        /// <returns>密文</returns>
        public string PublicKeyEncrypt(string text)
        {
            UTF8Encoding enc = new UTF8Encoding();

            byte[] bytes = enc.GetBytes(text);
            crypt.FromXmlString(publicKey);
            bytes = crypt.Encrypt(bytes, false);

            crypt.Clear();

            return Convert.ToBase64String(bytes);
        }

        public string PrivateKey
        {
            get
            {
                return privateKey;
            }
            set
            {
                privateKey = value;
            }
        }

        public string PublicKey
        {
            get
            {
                return publicKey;
            }
            set
            {
                publicKey = value;
            }
        }

        public bool PersistKeyInCsp
        {
            get { return crypt.PersistKeyInCsp; }
            set { crypt.PersistKeyInCsp = value; }
        }

        #endregion
    }
}
