using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Whatever.Wcf.UnitTest
{
    [TestClass]
    public class UserWcfTest
    {
        [TestMethod]
        public void AddUserTest() {
            string url = "http://localhost:54475/SVC/UserWcfService.svc/AddUser";
            string message = "{\"user\":{\"UserName\":\"CrazyJinn\",\"Password\":\"asd\",\"Money\":100}}";
            BaseTest.Post(url, message);
        }

        [TestMethod]
        public void UpdateUserMoneyTest() {
            string url = "http://localhost:54475/SVC/UserWcfService.svc/UpdateUserMoney";
            string message = "{\"id\":\"5307115548bf9516d4ee8ed1\",\"money\":\"-200\"}";
            BaseTest.Post(url, message);
        }


        [TestMethod]
        public void IsUserNameExistTest() {
            string url = "http://localhost:54475/SVC/UserWcfService.svc/IsUserNameExist";
            string message = "{\"username\":\"CrazyJinn\"}";
            BaseTest.Post(url, message);
        }

        [TestMethod]
        public void UpdateUserTagTest() {
            string url = "http://localhost:54475/SVC/UserWcfService.svc/UpdateUserTag";
            string message = "{\"id\":\"5307115548bf9516d4ee8ed1\",\"tagID\":\"530716e048bf9502889a66b9\"}";
            BaseTest.Post(url, message);
        }

        [TestMethod]
        public void GetUserByNameAndPsdTest() {
            string url = "http://localhost:54475/SVC/UserWcfService.svc/GetUserByNameAndPsd";
            string message = "{\"userName\":\"CrazyJinn\",\"password\":\"asd\",\"mac\":\"00-1E-64-8A-34-7C\"}";
            BaseTest.Post(url, message);
        }

        [TestMethod]
        public void GetUserByPingTest() {
            string url = "http://localhost:54475/SVC/UserWcfService.svc/GetUserByPing";
            string message = "{\"ping\":\"6517832238154237211105819715811677711682198410417638\"}";
            BaseTest.Post(url, message);
        }

        
        
    }
}
