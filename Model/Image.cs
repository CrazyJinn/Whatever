using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Image : ModelBase
    {

        /// <summary>
        /// 看看以后是用文件系统还是GridFS来做
        /// </summary>
        public byte[] ImgContent { get; set; }

        public string UserID { get; set; }

        public int? ImgSize { get; set; }

        public int? Random { get; set; }

        /// <summary>
        /// 是否公开，用户决定
        /// </summary>
        public bool? IsPublic { get; set; }

        /// <summary>
        /// 是否确认，管理员决定
        /// </summary>
        public bool? IsConfirm { get; set; }

        public bool? IsDelete { get; set; }

        /// <summary>
        /// 图片来源
        /// </summary>
        public ImageSource ImageSource { get; set; }

        /// <summary>
        /// 素质点
        /// </summary>
        public int? QualityPiont { get; set; }

        public int? HP { get; set; }

        public int? Damage { get; set; }

        /// <summary>
        /// 回避率
        /// </summary>
        public int? DoubleChance { get; set; }

        /// <summary>
        /// 暴击率
        /// </summary>
        public int? CriticalChance { get; set; }
    }

    public enum ImageSource
    {
        Unknow = 0,
        /// <summary>
        /// 网络抓取
        /// </summary>
        Web = 1,
        /// <summary>
        /// 用户上传
        /// </summary>
        User = 2,
    }
}
