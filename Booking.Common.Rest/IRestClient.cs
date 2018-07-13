using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Common.Rest
{
	public interface IRestClient
	{

	}
	public interface IRestClient<TResponse> : IRestClient<TResponse, string, object>
	{

	}
	public interface IRestClient<TResponse, TKey, TBody> : IRestClient
	{
		Task DeleteAsync(TKey id);
		Task<IEnumerable<TResponse>> GetAsync();
		Task<TResponse> GetAsync(TKey id);
		Task<TResponse> PostAsync(TBody model);
	}
}