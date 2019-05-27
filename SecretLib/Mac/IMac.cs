using System;
using Org.BouncyCastle.Crypto.Parameters;

namespace SecretLib.Mac
{
    /// <summary>
    /// Mac�㷨
    /// </summary>
    public interface IMac
    {
        /// <summary>
        /// �㷨����
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ������Ϣ��
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] MessageCode(byte[] message, KeyParameter key);
    }
}