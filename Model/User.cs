﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Model
{
    public class User : ModelBase
    {
        public User() {
            this.Tags = new List<string>();
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? Money { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        public string Mac { get; set; }

        /// <summary>
        /// 用户通过ID与Mac加密后的唯一标示符
        /// </summary>
        public string Ping { get; set; }

        public DateTime? LastLogOnTime { get; set; }

        public UserType UserType { get; set; }

        /// <summary>
        /// 用户状态,比如说被锁之类的
        /// </summary>
        public UserStatus UserStatus { get; set; }

        public List<string> Tags { get; set; }
    }

    public enum Gender
    {
        Undefined = 0,
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
