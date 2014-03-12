using System;
using System.Linq;
using Connection;
using Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

using Common.Exception;
using Common.Msg;


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

        public void AddImg(byte[] img, string userId) {
            Image image = new Image();
            image.ImgContent = img;
            image.Random = new Random().Next();
            image.ImageSource = ImageSource.User;
            image.CreateTime = DateTime.Now;
            image.IsDelete = false;
            image.IsConfirm = false;
            image.IsPublic = true;
            image.UserID = userId;
            image.ImgSize = img.Length;
            this.AddImg(image);
        }

        #region Update

        public void SaveImg(Image img) {
            imgConn.Save(img);
        }

        public void UpdateImgStatus(ObjectId id, bool isDelete, bool isPublic) {
            var query = Query<Image>.EQ(o => o.ID, id);
            var update = Update<Image>.Set(o => o.IsDelete, isDelete)
                .Set(o => o.IsPublic, isPublic);
            imgConn.Update(query, update);
        }

        public void UpdateImgStatus(ObjectId id, bool isConfirm) {
            var query = Query<Image>.EQ(o => o.ID, id);
            var update = Update<Image>.Set(o => o.IsConfirm, isConfirm);
            imgConn.Update(query, update);
        }

        public void UpdateImgQuality(ObjectId id, int qualityPiont, int damage, int doubleChance, int criticalChance) {
            var img = GetImageByID(id).FirstOrDefault();
            if (JudgeQuality(img, qualityPiont, damage, doubleChance, criticalChance)) {
                img.QualityPiont = qualityPiont;
                img.Damage = damage;
                img.DoubleChance = doubleChance;
                img.CriticalChance = criticalChance;
                SaveImg(img);
            }
            else {
                throw new UserCheatException(UserErrorMsg.UserCheat);
            }
        }

        /// <summary>
        /// 判断属性点是否合法
        /// </summary>
        public bool JudgeQuality(Image img, int qualityPiont, int damage, int doubleChance, int criticalChance) {
            return true;
        }

        #endregion

        public IQueryable<Image> GetImageByID(ObjectId id) {
            return imgConn.AsQueryable<Image>()
                .Where(o => o.ID == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="flag">查询大于还是小于的判断标志，如果是True则查询大于，反之则小于</param>
        /// <returns></returns>
        public IQueryable<Image> GetImageList(Image img = null, bool flag = true) {
            var result = imgConn.AsQueryable<Image>();
            if (img != null) {
                if (img.UserID != null)
                    result.Where(o => o.UserID == img.UserID);
                if (img.IsConfirm != null)
                    result.Where(o => o.IsConfirm == img.IsConfirm);
                if (img.IsDelete != null)
                    result.Where(o => o.IsDelete == img.IsDelete);
                if (img.IsPublic != null)
                    result.Where(o => o.IsPublic == img.IsPublic);
                if (img.ImageSource != ImageSource.Unknow)
                    result.Where(o => o.ImageSource == img.ImageSource);

                if (flag == true) {
                    if (img.QualityPiont != null)
                        result.Where(o => o.QualityPiont >= img.QualityPiont);
                    if (img.HP != null)
                        result.Where(o => o.HP >= img.HP);
                    if (img.Damage != null)
                        result.Where(o => o.Damage >= img.Damage);
                    if (img.DoubleChance != null)
                        result.Where(o => o.DoubleChance >= img.DoubleChance);
                    if (img.CriticalChance != null)
                        result.Where(o => o.CriticalChance >= img.CriticalChance);
                    if (img.ImgSize != null)
                        result.Where(o => o.ImgSize >= img.ImgSize);
                }
                else {
                    if (img.QualityPiont != null)
                        result.Where(o => o.QualityPiont <= img.QualityPiont);
                    if (img.HP != null)
                        result.Where(o => o.HP <= img.HP);
                    if (img.Damage != null)
                        result.Where(o => o.Damage <= img.Damage);
                    if (img.DoubleChance != null)
                        result.Where(o => o.DoubleChance <= img.DoubleChance);
                    if (img.CriticalChance != null)
                        result.Where(o => o.CriticalChance <= img.CriticalChance);
                    if (img.ImgSize != null)
                        result.Where(o => o.ImgSize <= img.ImgSize);
                }
            }
            return result;
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
