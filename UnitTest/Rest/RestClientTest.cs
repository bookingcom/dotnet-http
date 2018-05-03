using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Rest
{
    [TestClass]
    public class RestClientTest
    {
        [TestMethod]
        public void BaseAddressTest()
        {
            var restAddress = new MockRestClient("http://bob.co.za");
            Assert.AreEqual("http://bob.co.za/MockRest/", restAddress.BaseAddress);
        }
        [TestMethod]
        public void BaseAddressTest1()
        {
            var restAddress = new MockRestClient("http://bob.co.za/");
            Assert.AreEqual("http://bob.co.za/MockRest/", restAddress.BaseAddress);
        }
    }
}