namespace Booking.Common.Http
{
	public class JwtSettings
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public string TokenEndpoint { get; set; }
		public string Resource { get; set; }

		public JwtSettings()
		{
			TokenEndpoint = "https://login.microsoftonline.com/a430c977-2786-4a63-a50e-90b71e55d889/oauth2/token";
		}
	}
}