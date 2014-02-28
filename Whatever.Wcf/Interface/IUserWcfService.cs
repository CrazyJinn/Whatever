using System.ServiceModel;
using System.ServiceModel.Web;
using Model;
using MongoDB.Bson;

namespace Whatever.Wcf
{
    [ServiceContract]
    public interface IUserWcfService
    {
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel AddUser(User user);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel GetUserByPing(string ping);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel GetUserByNameAndPsd(string username, string password, string mac);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel IsUserNameExist(string username);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel UpdateUserTag(string id, string tagID);

        [WebInvoke(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        WcfModel UpdateUserMoney(string id, int money);
    }
}
