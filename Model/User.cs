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

        public int Money { get; set; } //改名

        public DateTime RegisterTime { get; set; }
    }
}
