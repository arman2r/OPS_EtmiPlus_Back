using OPSEtmiPlus.Services;

namespace OPSEtmiPlus.Helpers
{
    internal static class CommonApiHelpers
    {
        public static IConfiguration? configuration;

        public static JwtManager getAuthManager()
        {
            string secret = configuration!.GetValue<string>("Authorization:secret")!;
            string issuer = configuration!.GetValue<string>("Authorization:issuer")!;
            string audience = configuration!.GetValue<string>("Authorization:audience")!;
            var jwtManager = new JwtManager(secret, issuer, audience);
            return jwtManager;
        }
        public static string GetConnectionString()
        {
            string connectionString = configuration!.GetValue<string>("ConnectionStrings:DefaultConnection")!;
            return connectionString;
        }
    }
}
