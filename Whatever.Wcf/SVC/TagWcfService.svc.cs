using Newtonsoft.Json;
using Service;
using System.Linq;

namespace Whatever.Wcf
{
    public class TagWcfService : ITagWcfService
    {
        private TagService tagService = new TagService();
        private WcfModel model = new WcfModel();

        public WcfModel GetTagList() {
            try {
                var tag = tagService.GetTagList();
                var data = from o in tag
                           select new {
                               ID = o.ID.ToString(),
                               TagName = o.TagName,
                               NeedMoney = o.NeedMoney
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch {
                model.Code = WcfStatus.QueryError;
                model.ErrorMsg = "WTF";
            }
            return model;
        }
    }
}
