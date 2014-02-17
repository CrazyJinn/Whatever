using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using MongoDB.Bson;
using System.Linq;

namespace Service.UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
        private UserService userService = new UserService();

        [TestMethod]
        public void AddUserTest() {
            User user = new User();
            user.UserName = "CrazyJinn";
            user.Password = "123";
            user.Gender = Gender.Man;
            user.CreateTime = DateTime.Now;

            userService.AddUser(user);
        }

        [TestMethod]
        public void UpdateUserMoneyTest() {
            userService.UpdateUserMoney(new ObjectId("5301d19e48bf9502ac42130b"), 10);

            //var user = userService.GetUserByID(new ObjectId("5301c91b48bf950dece8f447")).First();
            //user.Money = 10;
            //user.Mac = "qqqqqq";
            //userService.SaveUser(user);
        }

        [TestMethod]
        public void GetUserListTest() {
            User user = new User();
            var a = userService.GetUserList(user);
            foreach (var item in a) {
                Console.Write(item.UserName + "\n");
                Console.Write(item.CreateTime + "\n");
            }
        }

        [TestMethod]
        public void GetUserByIdTest() {
            var a = userService.GetUserByID(new ObjectId("5139960357751f14d45aa4b1")).First();
            Console.Write(a.ID.Increment + "\n");
            Console.Write(a.ID.Machine + "\n");
            Console.Write(a.ID.Pid + "\n");
            Console.Write(a.ID.Timestamp + "\n");
        }
    }
}
