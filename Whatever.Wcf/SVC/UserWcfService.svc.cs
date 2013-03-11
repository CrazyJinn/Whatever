using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common.Exception;
using Model;
using MongoDB.Bson;
using Newtonsoft.Json;
using Service;

namespace Whatever.Wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UserService.svc 或 UserService.svc.cs，然后开始调试。
    public class UserWcfService : IUserWcfService
    {
        private UserService userService = new UserService();
        private WcfModel model = new WcfModel();

        public WcfModel AddUser(Model.User user)
        {
            try
            {
                userService.AddUser(user);
                model.Code = WcfStatus.AddSuccessful;
            }
            catch (Exception e)
            {
                model.Code = WcfStatus.AddFailed;
                model.ErrorMsg = e.Message;
            }
            return model;
        }

        //public WcfModel<User> GetUserByID(ObjectId id)
        //{
        //    WcfModel<User> model = new WcfModel<User>();
        //    try
        //    {
        //        model.Data = userService.GetUserByID(id);
        //        model.Code = WcfStatus.QuerySuccessful;
        //    }
        //    catch (Exception e)
        //    {
        //        model.Code = WcfStatus.QueryError;
        //        model.ErrorMsg = e.Message;
        //    }
        //    return model;
        //}

        public WcfModel GetUserListByNameAndPsd(string username, string password)
        {
            WcfModel model = new WcfModel();
            try
            {
                var data = from o in userService.GetUserListByNameAndPsd(username, password)
                           select new
                           {
                               ID = o.ID,
                               Money = o.Money,
                               Tags = o.Tags,
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch (RepeatedUsernameException e)
            {
                model.Code = WcfStatus.QueryError;
                model.ErrorMsg = e.Message;
            }
            return model;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <returns>存在返回true，不存在返回false</returns>
        public string IsUserNameExist(string username)
        {
            var user = userService.GetUserListByName(username);

            return "101";
        }
    }
}
