using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Booking.Common.Rest;
using IdentityModel.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Mocks;

namespace UnitTest.Rest
{
    [TestClass]
  public  class JwtClientTest
    {
        private JwtSettings _jwtSettings= new JwtSettings()
        {
            ClientId = "1",
            ClientSecret = "1",
            Resource = "1",
            TokenEndpoint = "http://bob.co.za/token"
        };

        private JwtDelegatingHandler _jwtDelegatingHandler;
        [TestMethod]
        public void TestingNoToken()
        {

            string tokenResponse =
                "{\r\n    \"token_type\": \"Bearer\",\r\n    \"expires_in\": \"3599\",\r\n    \"ext_expires_in\": \"0\",\r\n    \"expires_on\": \"1522922456\",\r\n    \"not_before\": \"1522918556\",\r\n    \"resource\": \"resource\",\r\n    \"access_token\": \"eyJ0eXAiOiJKV1QiLCJhbGc\"\r\n}";

            var mockInspectRequestDelegatingHandler = new MockInspectRequestDelegatingHandler(HttpStatusCode.OK,"1");
            _jwtDelegatingHandler = new JwtDelegatingHandler(_jwtSettings, new MockDelegatingHandler(HttpStatusCode.OK,tokenResponse),mockInspectRequestDelegatingHandler);
            var client =  new MockRestClient(_jwtDelegatingHandler, "http://bob.co.za");
            
            client.GetAsync("1");

            Assert.AreEqual(mockInspectRequestDelegatingHandler.Request.Headers.Authorization.Scheme,"Bearer");
            Assert.AreEqual(mockInspectRequestDelegatingHandler.Request.Headers.Authorization.Parameter,"eyJ0eXAiOiJKV1QiLCJhbGc");

        }
        [TestMethod]
        public void TestingNoToken2Requests()
        {

            string tokenResponse =
                "{\r\n    \"token_type\": \"Bearer\",\r\n    \"expires_in\": \"3599\",\r\n    \"ext_expires_in\": \"0\",\r\n    \"expires_on\": \"1522922456\",\r\n    \"not_before\": \"1522918556\",\r\n    \"resource\": \"resource\",\r\n    \"access_token\": \"eyJ0eXAiOiJKV1QiLCJhbGc\"\r\n}";

            var mockInspectRequestDelegatingHandler = new MockInspectRequestDelegatingHandler(HttpStatusCode.OK,"1");
            _jwtDelegatingHandler = new JwtDelegatingHandler(_jwtSettings, new MockDelegatingHandler(HttpStatusCode.OK,tokenResponse),mockInspectRequestDelegatingHandler);
            var client =  new MockRestClient(_jwtDelegatingHandler, "http://bob.co.za");
            
            client.GetAsync("1");
             tokenResponse =
                "{\r\n    \"token_type\": \"Bearer\",\r\n    \"expires_in\": \"3599\",\r\n    \"ext_expires_in\": \"0\",\r\n    \"expires_on\": \"1522922456\",\r\n    \"not_before\": \"1522918556\",\r\n    \"resource\": \"resource\",\r\n    \"access_token\": \"eyJ0eXAiOiJV1QiLCJhbGc\"\r\n}";
            _jwtDelegatingHandler = new JwtDelegatingHandler(_jwtSettings, new MockDelegatingHandler(HttpStatusCode.OK,tokenResponse),mockInspectRequestDelegatingHandler);
            client.GetAsync("1");
            Assert.AreEqual(mockInspectRequestDelegatingHandler.Request.Headers.Authorization.Scheme,"Bearer");
            Assert.AreNotEqual( mockInspectRequestDelegatingHandler.Request.Headers.Authorization.Parameter,"eyJ0eXAiOiJV1QiLCJhbGc");

        }
       
    }
}
