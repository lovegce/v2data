

using Org.BouncyCastle.Crypto.Parameters;

namespace SecretLib.Symmetric
{
    /// <summary>
    /// �ԳƼ����㷨��ͨ�ýӿ�
    /// </summary>
    public interface ISymmetric
    {
        /// <summary>
        /// �����㷨
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] Encrypto(byte[] data, KeyParameter key);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] Decrypto(byte[] data, KeyParameter key);
    }
}