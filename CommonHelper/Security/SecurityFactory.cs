using System;

namespace CommonHelper.Security
{
    /// <summary>
    /// 对称加密算法种类
    /// </summary>
    [Serializable]
    public enum SymmetricCategory
    {
        /// <summary>
        /// AES
        /// </summary>
        Rijndael,
        /// <summary>
        /// DES
        /// </summary>
        DES
    }

    /// <summary>
    /// 创建加密类工厂
    /// </summary>
    public static class SecurityFactory
    {
        /// <summary>
        /// 返回对称加密的方法类默认是AES
        /// </summary>
        /// <returns>RijndaelManaged</returns>
        public static ISymmetricSecurity CreateSymmetricSecurity()
        {
            return new SymmetricSecurity();
        }

        /// <summary>
        /// 返回对称加密的方法
        /// </summary>
        /// <param name="sc">加密方法枚举</param>
        /// <returns>加密方法类</returns>
        public static ISymmetricSecurity CreateSymmetricSecurity(SymmetricCategory sc)
        {
            return new SymmetricSecurity(sc);
        }

        /// <summary>
        /// 返回非对称加密
        /// </summary>
        /// <returns>返回RSA高位非对称加密</returns>
        public static IAsymmetricSecurity CreateAsymmetricSecurity()
        {
            return new RSACryptoSecurity();
        }

        /// <summary>
        /// 返回非对称加密
        /// </summary>
        /// <param name="keyContainerName">密钥容器名称</param>
        /// <returns>使用密钥容器返回RSA高位非对称加密</returns>
        public static IAsymmetricSecurity CreateAsymmetricSecurity(string keyContainerName)
        {
            return new RSACryptoSecurity(keyContainerName);
        }
    }
}
