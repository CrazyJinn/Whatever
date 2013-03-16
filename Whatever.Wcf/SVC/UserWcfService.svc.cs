﻿using System;
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
                               ID = o.ID.ToString(),
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
                               ID = o.ID.ToString(),
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
        public WcfModel IsUserNameExist(string username) {
            try {
                var user = userService.GetUserListByName(username);
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
