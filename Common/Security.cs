using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Security
    {
        public static string GetPing(string key) {
            SHA1 sha = SHA1.Create();
            string ping = "";
            foreach (var item in sha.ComputeHash(Encoding.Unicode.GetBytes(key))) {
                ping += item;
            }
            return ping;
        }

        /// <summary>
        /// 检查Ping
        /// </summary>
        /// <param name="ping">要比较的Ping</param>
        /// <param name="dbPing">数据库中储存的Ping</param>
        /// <returns></returns>
        public static bool ComparePing(string ping, string dbPing) {
            if (ping.Length != dbPing.Length)
                return false;
            else {
                if (ping == dbPing)
                    return true;
                else
                    return false;
            }
        }
    }
}
