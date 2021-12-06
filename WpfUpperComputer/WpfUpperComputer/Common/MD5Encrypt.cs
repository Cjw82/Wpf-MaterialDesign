using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfUpperComputer.Common
{
    public class MD5Encrypt
    {
        private static MD5 d5;
        //MD5 32位加密
        private static string MD5Encrypt32(string Name, string PassWord)
        {
            d5 = MD5.Create();
            string mds = string.Empty;
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] np = d5.ComputeHash(Encoding.UTF8.GetBytes((Name + PassWord)));

            for (int i = 0; i < np.Length; i++)
            {
                mds = mds + np[i].ToString("X");
            }
            return mds;
        }
        //MD5 64位加密
        private static string MD5Encrypt64(string Name, string PassWord)
        {
            d5 = MD5.Create();
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] np = d5.ComputeHash(Encoding.UTF8.GetBytes((Name + PassWord)));
            return Convert.ToBase64String(np);
        }
    }
}
