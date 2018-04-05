using System;
using System.Net;
using System.Net.Http;
using Booking.Common.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;

namespace UnitTest
{
    [TestClass]
    public class GetExtensionTests
    {
        [TestMethod]
        public  void HttpClientNotFound()
        {
            var client = new HttpClient(new MockDelegatingHandler(HttpStatusCode.NotFound,""));
            
           
            var val =  client.GetAsync<int>("https://bob.co.za").Result;
            Assert.AreEqual(default(int),val);

        } 
        [TestMethod]
        public  void OKAndDeserializedValueCorrectly()
        {
            var client = new HttpClient(new MockDelegatingHandler(HttpStatusCode.OK,"1"));
            
           
            var val =  client.GetAsync<int>("https://bob.co.za").Result;
            Assert.AreEqual(1,val);

        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException),
            "Ensure Success didnt fire correctly ")]
        public  void ServerError()
        {
            var client = new HttpClient(new MockDelegatingHandler(HttpStatusCode.InternalServerError,"1"));

            
                var val =  client.GetAsync<int>("https://bob.co.za").Result;
           
           
            

        }
    }
}
