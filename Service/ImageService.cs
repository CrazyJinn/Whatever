using System;
using System.Linq;
using Connection;
using Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

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
            image.ImageSource = ImageSource.User;
            image.CreateTime = DateTime.Now;
            this.AddImg(image);
        }

        #region Update

        public void SaveImg(Image img) {
            imgConn.Save(img);
        }

        public void UpdateImg(ObjectId id, bool isDelete = false, bool isConfirm = true, bool isPublic = true) {
            var query = Query<Image>.EQ(o => o.ID, id);
            var update = Update<Image>.Set(o => o.IsDelete, isDelete)
                .Set(o => o.IsConfirm, isConfirm)
                .Set(o => o.IsPublic, isPublic);
            imgConn.Update(query, update);
        }

        #endregion

        public IQueryable<Image> GetImageList(bool isDelete = false, bool isConfirm = true, bool isPublic = true) {
            return imgConn.AsQueryable<Image>()
                .Where(o => o.IsDelete == isDelete && o.IsConfirm == isConfirm && o.IsPublic == isPublic);
        }

        /// <summary>
        /// 随机查找图片
        /// </summary>
        /// <remarks>
        /// 这里有个Bug，一个随机数可能找到多张图片
        /// 对于这个Bug，不做处理，多张图片一起返回
        /// 再在人少的时候跑个程序，把随机数相同的数据拆开
        /// </remarks>
        public IQueryable<Image> GetImageByRandom() {
            var random = new Random().Next();
            var img = this.GetImageList().Where(o => o.Random > random).Take(1);    //返回一个作为测试
            if (img.Count() == 0) {
                return this.GetImageList().Where(o => o.Random < random).Take(1);
            }
            else {
                return img;
            }
        }
    }
}
