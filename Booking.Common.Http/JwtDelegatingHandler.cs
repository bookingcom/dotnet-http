using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Booking.Common.Http
{
    public class JwtDelegatingHandler : DelegatingHandler
    {
        private readonly JwtSettings _settings;
        private readonly DelegatingHandler _tokenInnerHandler;
        private TokenResponse _token;
        
        public JwtDelegatingHandler(JwtSettings settings, DelegatingHandler tokenInnerHandler,DelegatingHandler innerHandler):base(innerHandler)
        {
            _settings = settings;
            _tokenInnerHandler = tokenInnerHandler;
        }

        public JwtDelegatingHandler(JwtSettings settings) : base()
        {_settings = settings;
           
        }

        protected override  async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this._token==null)
            {
                await GetTokenAsync();
                
            }
            var httpResponse = await ExecuteRequestAsync(request, cancellationToken);
            if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetTokenAsync();
                
                httpResponse = await ExecuteRequestAsync(request, cancellationToken);
            }

            return httpResponse;
        }

        private async Task<HttpResponseMessage> ExecuteRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(_token.TokenType, _token.AccessToken);

            var httpResponse = await base.SendAsync(request, cancellationToken);
            return httpResponse;
        }

        private async Task GetTokenAsync()
        {
           
            TokenClient client;
            if(_tokenInnerHandler ==null)
            client = new TokenClient(
                _settings.TokenEndpoint,
                _settings.ClientId,
                _settings.ClientSecret);
            else
            {client = new TokenClient(
                _settings.TokenEndpoint,
                _settings.ClientId,
                _settings.ClientSecret,_tokenInnerHandler);
                
            }


            var dictionary = new Dictionary<string, string>() {{"resource", _settings.Resource}};
            var response = await client.RequestClientCredentialsAsync(extra:
                dictionary);
            _token = response;
        }
    }
}