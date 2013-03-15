using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : Identifier
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Money { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Mac网卡地址
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 用户通过ID与Mac加密后的唯一标示符
        /// </summary>
        public string Ping { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }

        public UserType UserType { get; set; }

        /// <summary>
        /// 用户状态,比如说被锁之类的
        /// </summary>
        public UserStatus UserStatus { get; set; }

        public List<Tag> Tags { get; set; }
    }

    public enum Gender
    {
        Man = 1,
        Women = 2,
    }

    public enum UserStatus
    {
        Active = 1,
        InActive = 2,
        Lock = 4,
    }

    public enum UserType
    {
    }
}
