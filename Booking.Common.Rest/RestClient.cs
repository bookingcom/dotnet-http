using Booking.Common.HttpClient.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booking.Common.Rest
{
	public abstract class RestClient<TResponse> : RestClient<TResponse, string, object>
	{
		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(string baseAddress)
			: base(baseAddress)
		{
		}
		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(System.Net.Http.HttpClient client, string baseAddress)
			: base(client, baseAddress)
		{
		}

		public RestClient(System.Net.Http.HttpClient client)
			: base(client)
		{
		}

		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(HttpMessageHandler handler, string baseAddress)
			: base(handler, baseAddress)
		{
		}
	}

	public abstract class RestClient<TResponse, TKey, TBody> : RestClient, IRestClient<TResponse, TKey, TBody>
	{
		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(string baseAddress)
			: base(baseAddress)
		{
		}

		public RestClient(System.Net.Http.HttpClient client)
			: base(client)
		{
		}

		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(System.Net.Http.HttpClient client, string baseAddress)
			: base(client, baseAddress)
		{
		}

		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(HttpMessageHandler handler, string baseAddress)
			: base(handler, baseAddress)
		{
		}

		public virtual Task<IEnumerable<TResponse>> GetAsync()
		{
			return HttpClient.GetAsync<IEnumerable<TResponse>>($"{ControllerName}");
		}
		public virtual Task<TResponse> GetAsync(TKey id)
		{
			return HttpClient.GetAsync<TResponse>($"{ControllerName}{id}");
		}

		public virtual Task<TResponse> PostAsync(TBody model)
		{
			return HttpClient.PostAsync<TResponse>($"{ControllerName}", model);
		}

		public virtual Task DeleteAsync(TKey id)
		{
			return HttpClient.DeleteAsync($"{ControllerName}{id}");
		}
	}

	public abstract class RestClient : IRestClient
	{
		protected System.Net.Http.HttpClient HttpClient { get; }
		protected string ControllerName => this.GetType().Name.Replace("Client", "/");

		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(string baseAddress)
			: this(new HttpClientHandler(), baseAddress)
		{

		}

		public RestClient(System.Net.Http.HttpClient client)
		{
			HttpClient = client;
		}

		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(System.Net.Http.HttpClient client, string baseAddress) : this(client)
		{
			string controller = this.GetType().Name.Replace("Client", "/");
			HttpClient.BaseAddress = new Uri(new Uri(baseAddress), controller);
		}

		[Obsolete("Use RestClient(HttpClient client) instead.", true)]
		public RestClient(HttpMessageHandler handler, string baseAddress)
			: this(new System.Net.Http.HttpClient(handler), baseAddress)
		{

		}

	}
}
