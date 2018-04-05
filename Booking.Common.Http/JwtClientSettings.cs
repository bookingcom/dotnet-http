namespace Booking.Common.Http
{
    public class JwtClientSettings
    {

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenEndpoint { get;set; }
        public string Resource { get; set; }
    }
}