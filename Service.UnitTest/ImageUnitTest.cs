﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Linq;

namespace Service.UnitTest
{
    [TestClass]
    public class ImageUnitTest
    {
        ImageService imgService = new ImageService("TestTag");

        [TestMethod]
        public void AddImgTest() {
            string[] strs = System.IO.Directory.GetFiles("D:\\ImageTest");
            foreach (string file in strs) {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                if (fi.Extension == ".jpg" || fi.Extension == ".gif"
                    || fi.Extension == ".bmp" || fi.Extension == ".png") {

                    FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);

                    byte[] data = new byte[fs.Length];

                    fs.Read(data, 0, data.Length);
                    fs.Close();

                    Image img = new Image();
                    img.Random = new Random().Next();
                    img.ImageSource = ImageSource.Web;
                    img.ImgContent = data;
                    img.IsPublic = true;
                    img.IsConfirm = true;
                    img.IsDelete = false;
                    img.UserID = "5307115548bf9516d4ee8ed1";
                    img.ImgSize = data.Length;
                    imgService.AddImg(img);

                }
            }
        }

        [TestMethod]
        public void GetImageByRandomTest() {
            var a = imgService.GetImageByRandom();
        }
    }
}
