namespace Booking.Common.Rest
{
    public class JwtSettings
    {

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenEndpoint { get;set; }
        public string Resource { get; set; }
    }
}