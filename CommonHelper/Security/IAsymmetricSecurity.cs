using System;

namespace CommonHelper.Security
{
    public interface IAsymmetricSecurity
    {
        /// <summary>
        /// 私钥解密
        /// </summary>
        /// <param name="text">要解密的信息</param>
        /// <returns>解密后的信息</returns>
        string PrivateKeyDecrypt(string text);

        /// <summary>
        /// 公钥加密
        /// </summary>
        /// <param name="text">要加密的信息</param>
        /// <returns>加密后的信息</returns>
        string PublicKeyEncrypt(string text);

        /// <summary>
        /// 私钥
        /// </summary>
        string PrivateKey { get; set; }

        /// <summary>
        /// 公钥
        /// </summary>
        string PublicKey { get; set; }

        /// <summary>
        /// 如果密钥应该永久驻留在 CSP 中，则为 true；否则为 false。 
        /// </summary>
        bool PersistKeyInCsp { get; set; }
    }
}
