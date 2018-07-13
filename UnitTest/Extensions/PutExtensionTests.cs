using System;
using System.Net;
using System.Net.Http;
using Booking.Common.HttpClient.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Mocks;

namespace UnitTest.Extensions
{
    [TestClass]
    public class PutExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(AggregateException),
            "Ensure Success didnt fire correctly ")]
        public  void HttpClientNotFound()
        {
            var client = new HttpClient(new MockDelegatingHandler(HttpStatusCode.NotFound,""));
            
           
            var val =  client.PutAsync<string>("https://bob.co.za",null).Result;
           

        } 
        [TestMethod]
        public  void OKAndDeserializedValueCorrectly()
        {
            var client = new HttpClient(new MockDelegatingHandler(HttpStatusCode.OK,"1"));
            
           
            var val =  client.PutAsync<string>("https://bob.co.za",null).Result;
            Assert.AreEqual("1",val);

        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException),
            "Ensure Success didnt fire correctly ")]
        public  void ServerError()
        {
            var client = new HttpClient(new MockDelegatingHandler(HttpStatusCode.InternalServerError,"1"));

            
                var val =  client.PutAsync<string>("https://bob.co.za",null).Result;
           
           
            

        }
    }
}
