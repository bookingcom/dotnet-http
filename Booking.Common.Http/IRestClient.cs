using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Common.Http
{
	public interface IRestClient<TResponse> : IRestClient<TResponse, string, object>
	{

	}
	public interface IRestClient<TResponse, TKey, TBody>
	{
		Task DeleteAsync(TKey id);
		Task<IEnumerable<TResponse>> GetAsync();
		Task<TResponse> GetAsync(TKey id);
		Task<TResponse> PostAsync(TBody model);
	}
}