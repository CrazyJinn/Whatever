using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Model;
using MongoDB.Bson;

namespace Whatever.Wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserService”。
    [ServiceContract]
    public interface IUserWcfService
    {
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel AddUser(User user);

        //[WebInvoke(RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    Method = "POST",
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //WcfModel<User> GetUserByID(ObjectId id);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel GetUserListByNameAndPsd(string username, string password);
    }
}
