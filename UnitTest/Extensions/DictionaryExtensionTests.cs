using System.Collections.Generic;
using Booking.Common.HttpClient.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Extensions
{
    [TestClass]
    public class DictionaryExtensionTests
    {
        [TestMethod]
       
        public  void EmptyDictionaryTest()
        {
            var dict = new Dictionary<string, string>();
            var value = dict.ToQueryString();
            Assert.AreEqual(string.Empty, value);   



        } 

        [TestMethod]
        public  void NullDictionaryTest()
        {
            var dict = new Dictionary<string, string>();
            dict = null;
            var value = dict.ToQueryString();
            Assert.AreEqual(string.Empty, value);   




        } 

        [TestMethod]
        public  void OneItemDictionaryTest()
        {
            var dict = new Dictionary<string, string>() { {"bob","1"}};
           
            var value = dict.ToQueryString();
            Assert.AreEqual("?bob=1", value);   



        }

        [TestMethod]
        public void TwoItemDictionaryTest()
        {
            var dict = new Dictionary<string, string>()
            {
                {"bob", "1"},
                {"bob2", "2"}
            };

        var value = dict.ToQueryString();
            Assert.AreEqual("?bob=1&bob2=2", value);   



        } 
        [TestMethod]
        public  void ThreeItemDictionaryTest1()
        {
            var dict = new Dictionary<string, string>()
            {
                {"bob", "1"},
                {"bob2", "2"},
                {"bob3", "2"}
            };
           
            var value = dict.ToQueryString();
            Assert.AreEqual("?bob=1&bob2=2&bob3=2", value);   



        } 
    }
}
