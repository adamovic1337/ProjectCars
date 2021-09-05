namespace ProjectCars.Service.JWT
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audiance { get; set; }
    }
}