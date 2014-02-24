using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Whatever.Wcf.UnitTest
{
    [TestClass]
    public class TagWcfTest
    {
        [TestMethod]
        public void GetTagListTest() {
            string url = "http://localhost:54475/SVC/TagWcfService.svc/GetTagList";
            string message = "";
            BaseTest.Post(url, message);
        }
    }
}
