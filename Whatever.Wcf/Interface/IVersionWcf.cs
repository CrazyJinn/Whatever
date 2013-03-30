using System.ServiceModel;
using System.ServiceModel.Web;

namespace Whatever.Wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IVersionWcf”。
    [ServiceContract]
    public interface IVersionWcf
    {
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string  GetVersion();
    }
}
