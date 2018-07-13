using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Booking.Common.HttpClient.Extensions;

namespace Booking.Common.Rest
{
	public abstract class RestClient<TResponse> : RestClient<TResponse, string, object>
	{
		public RestClient(string baseAddress)
			: base(baseAddress)
		{
		}
		public RestClient(System.Net.Http.HttpClient client, string baseAddress)
			: base(client, baseAddress)
		{


		}

		public RestClient(System.Net.Http.HttpClient client)
			: base(client)
		{
		}

		public RestClient(HttpMessageHandler handler, string baseAddress)
			: base(handler, baseAddress)
		{
		}
	}


	public abstract class RestClient<TResponse, TKey, TBody> : RestClient, IRestClient<TResponse, TKey, TBody>
	{
		public RestClient(string baseAddress)
			: base(baseAddress)
		{
		}

		public RestClient(System.Net.Http.HttpClient client)
			: base(client)
		{
		}

		public RestClient(System.Net.Http.HttpClient client, string baseAddress)
			: base(client, baseAddress)
		{
		}

		public RestClient(HttpMessageHandler handler, string baseAddress)
			: base(handler, baseAddress)
		{
		}

		public virtual Task<IEnumerable<TResponse>> GetAsync()
		{
			return HttpClient.GetAsync<IEnumerable<TResponse>>();
		}
		public virtual Task<TResponse> GetAsync(TKey id)
		{
			return HttpClient.GetAsync<TResponse>(id.ToString());
		}

		public virtual Task<TResponse> PostAsync(TBody model)
		{
			return HttpClient.PostAsync<TResponse>(model);
		}

		public virtual Task DeleteAsync(TKey id)
		{
			return HttpClient.DeleteAsync(id.ToString());
		}
	}


	public abstract class RestClient : IRestClient
	{
		protected System.Net.Http.HttpClient HttpClient { get; }

		public RestClient(string baseAddress)
			: this(new HttpClientHandler(), baseAddress)
		{

		}

		public RestClient(System.Net.Http.HttpClient client)
		{
			HttpClient = client;
		}
		public RestClient(System.Net.Http.HttpClient client, string baseAddress) : this(client)
		{
			string controller = this.GetType().Name.Replace("Client", "/");
			HttpClient.BaseAddress = new Uri(new Uri(baseAddress), controller);
		}

		public RestClient(HttpMessageHandler handler, string baseAddress)
			: this(new System.Net.Http.HttpClient(handler), baseAddress)
		{

		}

	}
}
