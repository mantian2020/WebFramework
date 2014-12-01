using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace CommonHelper.Security
{
    /// <summary>
    /// 对称加密解密类接口
    /// </summary>
    public interface ISymmetricSecurity
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">要解密的信息</param>
        /// <returns>解密后的信息</returns>
        string Decrypt(string text);

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">要加密的信息</param>
        /// <returns>加密后的信息</returns>
        string Encrypt(string text);

        /// <summary>
        /// 解密并把对象并行化
        /// </summary>
        /// <param name="text">串行化的对象</param>
        /// <returns>解密，并行化后的对象</returns>
        object DecryptObject(string text);

        /// <summary>
        /// 加密并把对象串行化
        /// </summary>
        /// <param name="obj">要加密的对象</param>
        /// <returns>加密，串行化后的信息</returns>
        string EncryptObject(object obj);

        /// <summary>
        /// 加密流
        /// </summary>
        /// <param name="stream">加密后的写入流</param>
        /// <param name="data">要加密的数据</param>
        /// <param name="count">data的个数</param>
        void EncryptStream(Stream stream, byte[] data, int count);

        /// <summary>
        /// 解密流
        /// </summary>
        /// <param name="stream">加密数据流</param>
        /// <returns>解密后的字节数组</returns>
        byte[] DecryptStream(TextReader stream);

        /// <summary>
        /// 加密解密密钥
        /// </summary>
        string KEY { get; set; }

        /// <summary>
        /// 加密解密向量
        /// </summary>
        string IV { get; set; }

        /// <summary>
        /// 设置对称算法的运算模式
        /// </summary>
        CipherMode Mode { get; set; }

        /// <summary>
        /// 加密用字符集默认是UTF-8
        /// </summary>
        Encoding Enc { get; set; }
    }
}
