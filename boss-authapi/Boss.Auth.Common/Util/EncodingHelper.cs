using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Common.Util
{
    public class EncodingHelper
    {
        private static string hexStr = "0123456789abcdef";
        private static char[] hexCharArr = hexStr.ToCharArray();

        public static string ByteArrToHex(byte[] btArr)
        {
            var strArr = new char[btArr.Length * 2];
            int i = 0;
            foreach (byte bt in btArr)
            {
                strArr[i++] = hexCharArr[bt >> 4 & 0xf];
                strArr[i++] = hexCharArr[bt & 0xf];
            }
            return new string(strArr);
        }

        public static byte[] HexToByteArr(string hexStr)
        {
            var charArr = hexStr.ToCharArray();
            var btArr = new byte[charArr.Length / 2];
            int index = 0;
            for (int i = 0; i < charArr.Length; i++)
            {
                int highBit = EncodingHelper.hexStr.IndexOf(charArr[i]);
                int lowBit = EncodingHelper.hexStr.IndexOf(charArr[++i]);
                btArr[index] = (byte)(highBit << 4 | lowBit);
                index++;
            }
            return btArr;
        }

        public static string ByteArrToHexDefault(byte[] btArr)
        {
            var sb = new StringBuilder();
            foreach (byte b in btArr)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        public static byte[] HexToByteArrDefault(string hexStr)
        {
            var inputArr = new byte[hexStr.Length / 2];
            for (int i = 0; i < hexStr.Length / 2; i++)
            {
                int v = Convert.ToInt32(hexStr.Substring(i * 2, 2), 16);
                inputArr[i] = (byte)v;
            }
            return inputArr;
        }
    }
}
