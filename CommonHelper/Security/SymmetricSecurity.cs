using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

namespace CommonHelper.Security
{
    /// <summary>
    /// 对称加密解密类(AES)
    /// </summary>
    internal class SymmetricSecurity : ISymmetricSecurity
    {
        private string key = "gua*nyuhuaxia*gkaifasunweis*heng";
        private string iv = "sun1we9is8he1ngw";
        private Encoding enc = new UTF8Encoding();
        private SymmetricAlgorithm sa = null;

        public SymmetricSecurity()
        {
            sa = SymmetricAlgorithm.Create(SymmetricCategory.Rijndael.ToString());

            this.KEY = key;
            this.IV = iv;
            sa.Mode = CipherMode.CBC;
        }

        public SymmetricSecurity(SymmetricCategory sc)
        {
            sa = SymmetricAlgorithm.Create(sc.ToString());
        }

        #region ISymmetricSecurity 成员

        /// <summary>
        /// 加密用字符集
        /// </summary>
        public Encoding Enc
        {
            get { return enc; }
            set { enc = value; }
        }

        /// <summary>
        /// 设置对称算法的运算模式
        /// </summary>
        public CipherMode Mode
        {
            get
            {
                return sa.Mode;
            }
            set
            {
                this.sa.Mode = value;
            }
        }

        /// <summary>
        /// 加密解密密钥
        /// </summary>
        public string KEY
        {
            get { return key; }
            set
            {
                key = value;

                sa.Key = enc.GetBytes(key);
            }
        }

        /// <summary>
        /// 加密解密向量
        /// </summary>
        public string IV
        {
            get { return iv; }
            set
            {
                iv = value;

                sa.IV = enc.GetBytes(iv);
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">要解密的信息</param>
        /// <returns>解密后的信息</returns>
        public string Decrypt(string text)
        {
            MemoryStream ms = new MemoryStream();

            byte[] rawData = enc.GetBytes(text);

            CryptoStream csDecrypt = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Write);

            ICryptoTransform transformDecode = new FromBase64Transform();
            CryptoStream csDecode = new CryptoStream(csDecrypt, transformDecode, CryptoStreamMode.Write);

            csDecode.Write(rawData, 0, rawData.Length);
            csDecode.FlushFinalBlock();

            byte[] bytes = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, (int)ms.Length);

            ms.Close();

            return enc.GetString(bytes);
        }

        /// <summary>
        /// 解密并把对象并行化
        /// </summary>
        /// <param name="text">串行化的对象</param>
        /// <returns>解密，并行化后的对象</returns>
        public object DecryptObject(string msg)
        {
            MemoryStream ms = new MemoryStream();

            byte[] rawData = enc.GetBytes(msg);

            CryptoStream csDecrypt = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Write);

            ICryptoTransform transformDecode = new FromBase64Transform();
            CryptoStream csDecode = new CryptoStream(csDecrypt, transformDecode, CryptoStreamMode.Write);

            csDecode.Write(rawData, 0, rawData.Length);
            csDecode.FlushFinalBlock();

            ms.Seek(0, SeekOrigin.Begin);

            BinaryFormatter bf = new BinaryFormatter();
            object o = bf.Deserialize(ms);

            ms.Close();

            return o;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">要加密的信息</param>
        /// <returns>加密后的信息</returns>
        public string Encrypt(string text)
        {
            MemoryStream ms = new MemoryStream();

            ICryptoTransform transformEncode = new ToBase64Transform();

            CryptoStream csEncode = new CryptoStream(ms, transformEncode, CryptoStreamMode.Write);

            CryptoStream csEncrypt = new CryptoStream(csEncode, sa.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] rawData = enc.GetBytes(text);

            csEncrypt.Write(rawData, 0, rawData.Length);
            csEncrypt.FlushFinalBlock();

            byte[] encryptedData = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(encryptedData, 0, (int)ms.Length);

            ms.Close();

            return enc.GetString(encryptedData);
        }

        /// <summary>
        /// 加密并把对象串行化
        /// </summary>
        /// <param name="obj">要加密的对象</param>
        /// <returns>加密，串行化后的信息</returns>
        public string EncryptObject(object obj)
        {
            MemoryStream objMs = new MemoryStream();

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(objMs, obj);

            objMs.Seek(0, SeekOrigin.Begin);

            byte[] rawData = new byte[objMs.Length];
            objMs.Read(rawData, 0, (int)objMs.Length);

            MemoryStream ms = new MemoryStream();

            ICryptoTransform transformEncode = new ToBase64Transform();

            CryptoStream csEncode = new CryptoStream(ms, transformEncode, CryptoStreamMode.Write);

            CryptoStream csEncrypt = new CryptoStream(csEncode, sa.CreateEncryptor(), CryptoStreamMode.Write);

            csEncrypt.Write(rawData, 0, rawData.Length);
            csEncrypt.FlushFinalBlock();

            byte[] encryptedData = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(encryptedData, 0, (int)ms.Length);

            objMs.Close();
            ms.Close();

            return enc.GetString(encryptedData);
        }

        /// <summary>
        /// 加密流
        /// </summary>
        /// <param name="stream">加密后的写入流</param>
        /// <param name="data">要加密的数据</param>
        /// <param name="count">data的个数</param>
        public void EncryptStream(Stream stream, byte[] data, int count)
        {
            ICryptoTransform transformEncode = new ToBase64Transform();

            CryptoStream csEncode = new CryptoStream(stream, transformEncode, CryptoStreamMode.Write);

            CryptoStream csEncrypt = new CryptoStream(csEncode, sa.CreateEncryptor(), CryptoStreamMode.Write);

            csEncrypt.Write(data, 0, count);
            csEncrypt.FlushFinalBlock();
        }

        /// <summary>
        /// 解密流
        /// </summary>
        /// <param name="stream">加密的数据流</param>
        /// <param name="data">解密后的数据</param>
        /// <returns>data的个数</returns>
        public byte[] DecryptStream(TextReader stream)
        {
            MemoryStream ms = new MemoryStream();

            string rawData = stream.ReadToEnd();

            byte[] buffer = enc.GetBytes(rawData);

            CryptoStream csDecrypt = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Write);

            ICryptoTransform transformDecode = new FromBase64Transform();
            CryptoStream csDecode = new CryptoStream(csDecrypt, transformDecode, CryptoStreamMode.Write);

            csDecode.Write(buffer, 0, buffer.Length);
            csDecode.FlushFinalBlock();

            byte[] bytes = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, (int)ms.Length);

            ms.Close();

            return bytes;
        }

        #endregion
    }
}
