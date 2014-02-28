using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Model;

namespace Whatever.Wcf
{
    [ServiceContract]
    public interface IImageWcfService
    {
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel AddImage(string imgContent, string tagName, string userId);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel GetImageByRandom(string tagName);
    }
}
