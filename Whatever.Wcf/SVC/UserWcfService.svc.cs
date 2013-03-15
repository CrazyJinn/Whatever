using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using Common.Exception;
using Common.Msg;
using Model;
using MongoDB.Bson;
using Newtonsoft.Json;
using Service;

namespace Whatever.Wcf
{
    public class UserWcfService : IUserWcfService
    {
        private UserService userService = new UserService();
        private WcfModel model = new WcfModel();

        public WcfModel AddUser(User user) {
            try {
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
                var user = userService.GetUserByPing(ping);
                var data = from o in user
                           select new {
                               ID = o.ID,
                               Money = o.Money,
                               Tags = o.Tags,
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch (RepeatedPingException e) {
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
                var user = userService.GetUserListByNameAndPsd(username, password);
                string ping = null;
                if (!String.IsNullOrEmpty(mac)) {
                    ping = Security.GetPing(user.First().ID.ToString() + mac);
                    userService.UpdateUserPing(user.First().ID, ping);
                }

                var data = from o in user
                           select new {
                               ID = o.ID,
                               Money = o.Money,
                               Tags = o.Tags,
                               Ping = ping,
                           };
                model.Data = JsonConvert.SerializeObject(data);
                model.Code = WcfStatus.QuerySuccessful;
            }
            catch (RepeatedUsernameException e) {
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
        public int IsUserNameExist(string username) {
            var user = userService.GetUserListByName(username);
            if (user.Count() == 0) {
                return 1;
            }
            else {
                return 0;
            }
        }

        public int UpdateUserTag(ObjectId uid, Tag tag) {
            try {
                userService.UpdateUserTag(uid, tag);
                return 1;
            }
            catch {
                return 0;
            }
        }
    }
}
