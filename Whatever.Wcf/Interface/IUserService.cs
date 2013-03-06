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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserService”。
    [ServiceContract]
    public interface IUserService
    {
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string AddUser(User user);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetUserByID(Guid id);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetUserByInfo(string username, string password);
    }
}
