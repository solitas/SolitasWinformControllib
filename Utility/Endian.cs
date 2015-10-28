using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public static class Endian
    {
        /// <summary>
        /// 0x1234 => 0x3412
        /// </summary>
        public static ushort Reverse(this ushort value)
        {
            return (ushort)(((value & 0x00FF) << 8) | (((value & 0xFF00) >> 8)));
        }

        /// <summary>
        /// 0x01020304 => 0x04030201
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint Reverse(this uint value)
        {
            return ((value & 0x000000FF) << 24) | ((value & 0xFF000000) >> 24) | ((value & 0x0000FF00) << 8) | (((value & 0x00FF0000) >> 8));
        }

        public static ushort ToUInt16(this byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToUInt16(bytes, 0);
        }

        public static uint ToUInt32 (this byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static byte[] ToBytes(this ushort value)
        {
            var bytes = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }

        public static byte[] ToBytes(this uint value)
        {
            var bytes = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }
        /// <summary>
        /// 0x1234 => 1234
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHexString(this uint value, int num)
        {
            return value.ToString("X" + num);
        }

        public static string ToHexString(this ushort value, int num)
        {
            return value.ToString("X" + num);
        }
    }
}
