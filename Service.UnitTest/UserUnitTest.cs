using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using MongoDB.Bson;

namespace Service.UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
       private  UserService userService = new UserService();

        [TestMethod]
        public void AddUserTest()
        {
            User user = new User();
            user.UserName = "CrazyJinn";
            user.Password = "123";
            user.Gender = Gender.Man;
            user.RegisterTime = DateTime.Now;

            userService.AddUser(user);
        }

        [TestMethod]
        public void GetUserListTest()
        {
            var a = userService.GetUserList();
            foreach (var item in a)
            {
                Console.Write(item.UserName + "\n");
                Console.Write(item.RegisterTime + "\n");
            }
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var a = userService.GetUserByID(new ObjectId("5139960357751f14d45aa4b1"));
            Console.Write(a.ID.Increment + "\n");
            Console.Write(a.ID.Machine + "\n");
            Console.Write(a.ID.Pid + "\n");
            Console.Write(a.ID.Timestamp + "\n");
        }
    }
}
