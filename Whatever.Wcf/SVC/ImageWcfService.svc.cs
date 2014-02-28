using System;
using System.Linq;
using Model;
using Newtonsoft.Json;
using Service;
using System.Text;

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

    }
}
