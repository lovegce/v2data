using System;
using Org.BouncyCastle.Crypto;

namespace SecretLib.Asymmetric
{
    public interface IAsymmetric
    {
        /// <summary>
        /// ǩ���㷨
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        byte[] Encrypto(byte[] data, AsymmetricKeyParameter pk);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ppk"></param>
        /// <returns></returns>
        byte[] Decrypto(byte[] data, AsymmetricKeyParameter ppk);
    }
}