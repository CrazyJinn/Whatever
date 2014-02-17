using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 类别标签
    /// </summary>
    public class Tag : ModelBase
    {
        public string TagName { get; set; }

        /// <summary>
        /// 购买此Tag需要的钱
        /// </summary>
        public int? NeedMoney { get; set; }

        public string ConnString { get; set; }
    }
}
