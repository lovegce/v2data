using System;

namespace SecretLib.Hash
{
    /// <summary>
    /// ɢ�к���
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// �㷨��
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ����ɢ��
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        byte[] HashCompute(byte[] message);
    }
}