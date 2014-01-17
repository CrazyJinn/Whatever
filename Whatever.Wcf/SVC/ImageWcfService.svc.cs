using System;
using System.Linq;
using Model;
using Newtonsoft.Json;
using Service;

namespace Whatever.Wcf
{
    public class ImageWcfService : IImageWcfService
    {
        private WcfModel model = new WcfModel();

        public WcfModel AddImage(Image image, string tagName) {
            throw new NotImplementedException();
        }

        public WcfModel GetImageByRandom(string tagName) {
            try {
                ImageService imageService = new ImageService(tagName);
                var img = imageService.GetImageByRandom();
                var data = from o in img
                           select new {
                               ID = o.ID.ToString(),
                               Content = o.Content,
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
