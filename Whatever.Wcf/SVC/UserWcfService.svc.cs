using System;
using System.Linq;
using Common;
using Common.Exception;
using Model;
using MongoDB.Bson;
using Newtonsoft.Json;
using Service;

namespace Whatever.Wcf
{
    public class UserWcfService : IUserWcfService
    {
        private WcfModel model = new WcfModel();

        public WcfModel AddUser(User user) {
            try {
                UserService userService = new UserService();
                userService.AddUser(user);
                model.Code = WcfStatus.AddSuccessful;
            }
            catch (Exception e) {
                model.Code = WcfStatus.AddFailed;
                model.ErrorMsg = e.Message;
            }
            return model;
        }

        public WcfModel GetUserByPing(string ping) {
            try {
                UserService userService = new UserService();
                var user = userService.GetUserByPing(ping);
                var data = from o in user
                           select new {
                               ID = o.ID.ToString(),
                               Money = o.Money,
                               Tags = o.Tags,
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch (RepeatedException e) {
                model.Code = WcfStatus.QueryError;
                model.ErrorMsg = e.OutMsg;
            }
            catch (DataNotFoundException e) {
                model.Code = WcfStatus.QueryNoData;
                model.ErrorMsg = e.Message;
            }
            return model;
        }

        public WcfModel GetUserListByNameAndPsd(string username, string password, string mac) {
            try {
                UserService userService = new UserService();

                User item = new User();
                item.UserName = username;
                item.Password = password;
                var user = userService.GetUserList(item);
                string ping = null;
                if (!String.IsNullOrEmpty(mac)) {
                    ping = Security.GetPing(user.First().ID.ToString() + mac);
                    userService.UpdateUserPing(user.First().ID, ping);
                }
                var data = from o in user
                           select new {
                               ID = o.ID.ToString(),
                               Money = o.Money,
                               Tags = o.Tags,
                               Ping = ping,
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch (RepeatedException e) {
                model.Code = WcfStatus.QueryError;
                model.ErrorMsg = e.OutMsg;
            }
            catch (DataNotFoundException e) {
                model.Code = WcfStatus.QueryNoData;
                model.ErrorMsg = e.Message;
            }
            return model;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <returns>存在返回0，不存在返回1</returns>
        public WcfModel IsUserNameExist(string username) {
            try {
                UserService userService = new UserService();
                User item = new User();
                item.UserName = username;
                var user = userService.GetUserList(item);
                model.Code = WcfStatus.QuerySuccessful;
                model.Data = "true";
            }
            catch {
                model.Code = WcfStatus.QuerySuccessful;
                model.Data = "false";
            }
            return model;
        }

        public WcfModel UpdateUserTag(string id, string tagID) {
            try {
                UserService userService = new UserService();
                userService.UpdateUserTag(DataConvert.ToObjectId(id), DataConvert.ToObjectId(tagID));
                model.Code = WcfStatus.UpdateSuccessful;
            }
            catch (InvalidIdException e) {
                model.Code = WcfStatus.ParameterError;
                model.ErrorMsg = e.Message;
            }
            return model;
        }

        public WcfModel UpdateUserMoney(string id, int money) {
            try {
                UserService userService = new UserService();
                userService.UpdateUserMoney(DataConvert.ToObjectId(id), money);
                model.Code = WcfStatus.UpdateSuccessful;
            }
            catch (InvalidIdException e) {
                model.Code = WcfStatus.ParameterError;
                model.ErrorMsg = e.Message;
            }
            return model;
        }
    }
}
