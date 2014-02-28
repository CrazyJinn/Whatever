using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Service.UnitTest
{
    [TestClass]
    public class TagUnitTest
    {
        private TagService tagService = new TagService();
        [TestMethod]
        public void AddTagTest() {
            Tag tag = new Tag();
            tag.TagName = "TestTag";
            tag.DisplayName = "测试";
            tag.NeedMoney = 100;
            tag.ConnString = "mongodb://localhost";
            tagService.AddTag(tag);
        }
    }
}
