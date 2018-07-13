using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Booking.Common.Rest;

namespace UnitTest.Mocks
{
    public class MockDelegatingHandler: DelegatingHandler
    {
        private readonly HttpStatusCode _status;
        private readonly string _response;

        public MockDelegatingHandler(HttpStatusCode status, string response)
        {
            _status = status;
            _response = response;
        }

        protected override  Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
           
            return Task.FromResult(new HttpResponseMessage(_status){Content =new StringContent(_response)});
        }
    }
     public class MockInspectRequestDelegatingHandler: DelegatingHandler
    {
        private readonly HttpStatusCode _status;
        private readonly string _response;

        public MockInspectRequestDelegatingHandler(HttpStatusCode status, string response)
        {
            _status = status;
            _response = response;
        }
        public HttpRequestMessage Request { get; set; }
        protected override  Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {Request=request;
           
            return Task.FromResult(new HttpResponseMessage(_status){Content =new StringContent(_response)});
        }
    }
    public class MockRestClient : RestClient<string>
    {
        public MockRestClient(string baseAddress) : base(baseAddress)
        {
        }

        public MockRestClient(HttpClient client) : base(client)
        {
        }

        public MockRestClient(HttpClient client, string baseAddress) : base(client, baseAddress)
        {
        }

        public MockRestClient(HttpMessageHandler handler, string baseAddress) : base(handler, baseAddress)
        {
        }
        public string BaseAddress=> HttpClient.BaseAddress.ToString();
    }
}