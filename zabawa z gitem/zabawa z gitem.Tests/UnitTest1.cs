using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zabawa_z_gitem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           var e =  System.IO.Directory.EnumerateFiles(
                @"C:\Users\Sebastian\Dropbox\zabawa z gitem\zabawa z gitem\zabawa z gitem\Data\ssarnecki35@gmail.com");
        }
    }
}
