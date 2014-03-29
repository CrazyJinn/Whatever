using System;
using System.Linq;
using Model;
using Newtonsoft.Json;
using Service;
using System.Text;
using Common;

namespace Whatever.Wcf
{
    public class ImageWcfService : IImageWcfService
    {
        private WcfModel model = new WcfModel();

        public WcfModel AddImage(string imgContent, string tagName, string userId) {
            try {
                ImageService imageService = new ImageService(tagName);
                imageService.AddImg(Convert.FromBase64String(imgContent), userId);
                model.Code = WcfStatus.AddSuccessful;
            }
            catch {
            }
            return model;
        }

        public WcfModel GetImageByRandom(string tagName) {
            try {
                ImageService imageService = new ImageService(tagName);
                var img = imageService.GetImageByRandom();
                var data = from o in img
                           select new {
                               ID = o.ID.ToString(),
                               ImgContent = o.ImgContent,
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch {
            }
            return model;
        }

        public WcfModel GetImageList(Image image, string tagName, bool flag) {
            try {
                ImageService imageService = new ImageService(tagName);
                var img = imageService.GetImageList(image, flag);
                var data = from o in img
                           select new {
                               ID = o.ID.ToString(),
                               ImgContent = o.ImgContent,
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch {
            }
            return model;
        }

        public WcfModel UpdateImageStatus(string imgID, string tagName, Image img) {
            try {
                ImageService imageService = new ImageService(tagName);
                imageService.UpdateImgStatus(DataConvert.ToObjectId(imgID), img.IsDelete, null, img.IsPublic);
                model.Code = WcfStatus.UpdateSuccessful;
            }
            catch {
            }
            return model;
        }

        //public WcfModel UpdateImgQuality(string imgID, string tagName, Image img) {
        //    try {
        //        ImageService imageService = new ImageService(tagName);
        //        imageService.UpdateImgStatus(DataConvert.ToObjectId(imgID), img., isPublic);
        //        model.Code = WcfStatus.UpdateSuccessful;
        //    }
        //    catch {
        //    }
        //    return model;
        //}
    }
}
