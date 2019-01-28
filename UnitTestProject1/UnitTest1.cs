using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreadTest;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        async public Task TestMethod1()
        {
            var mwvm = new MainWindowViewModel();

            await mwvm.Submit.ExecuteAsync();

            Assert.AreEqual(2, mwvm.MyProp);
        }
    }
}
