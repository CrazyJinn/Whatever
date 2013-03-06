using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Whatever.Wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UserService.svc 或 UserService.svc.cs，然后开始调试。
    public class UserService : IUserService
    {
        public string AddUser(Model.User user)
        {
            return "aaa";
        }

        public string GetUserByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public string GetUserByInfo(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
