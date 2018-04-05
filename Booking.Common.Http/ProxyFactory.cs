using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Booking.Common.Http
{
	public static class ProxyFactory
	{
		public static HttpClient CreateClient(Proxy proxy)
		{
			return new HttpClient(CreateHandler(proxy));
		}

		public static HttpClientHandler CreateHandler(Proxy proxy)
		{
			Dictionary<Proxy, string> dictionary = new Dictionary<Proxy, string>()
			{
				{Proxy.Corp,  "http://webproxy.corp.booking.com:3128" },
				{Proxy.Prod, "http://webproxy.prod.booking.com:3128" },
				{Proxy.Dev, "http://webproxy.lhr4.dqs.booking.com:3128" },
				{Proxy.CloudOut, "http://webproxy-cloud.prod.booking.com:3128" },
				{Proxy.EmkOut,  "http://emkout.prod.booking.com:3128" },
				{Proxy.Pci , "http://secure-webproxy.prod.booking.com:3128"}
			};

			var item = dictionary[proxy];

			var httpClientHandler = new HttpClientHandler
			{
				UseProxy = true,
				Proxy = new WebProxy(item)
			};

			return httpClientHandler;

		}

		public enum Proxy
		{
			Corp,
			Prod,
			Dev,
			CloudOut,
			EmkOut,
			Pci
		}
	}
}
