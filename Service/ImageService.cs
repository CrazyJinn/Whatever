using System;
using System.Linq;
using Common.Exception;
using Common.Msg;
using Connection;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;


namespace Service
{
    public class ImageService
    {
        public ImageService(string tagName) {
            this.imgConn = ConnectionFactory.GetImgConn(tagName);
        }

        private MongoCollection imgConn { get; set; }

        public void AddImg(Image img) {
            imgConn.Insert(img);
        }

        public void AddImg(byte[] img) {
            Image image = new Image();
            image.Content = img;
            image.Random = new Random().Next();
            this.AddImg(image);
        }

        public IQueryable<Image> GetImageList() {
            return imgConn.AsQueryable<Image>();
        }

        public IQueryable<Image> GetImageByPublic() {
            return this.GetImageList().Where(o => o.IsPublic == true);
        }

        /// <summary>
        /// 随机查找图片
        /// </summary>
        /// <remarks>
        /// 这里有个Bug，一个随机数可能找到多张图片
        /// 对于这个Bug，不做处理，多张图片一起返回
        /// 然后哪天心情好，再在人少的时候跑个程序，把随机数相同的数据拆开
        /// </remarks>
        public IQueryable<Image> GetImageByRandom() {
            var random = new Random().Next();
            var img = this.GetImageByPublic().Where(o => o.Random > random);
            if (img.Count() == 0) {
                return this.GetImageByPublic().Where(o => o.Random < random);
            }
            else {
                return img;
            }
        }
    }
}
