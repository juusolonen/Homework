namespace Server;

public static class Constants
{
    public static readonly string ClientUrl = "ClientUrl";
        
    public static class Cache
    {
        public const string FiveSeconds = "Expire5";
    }

    public static class DummyApiPaths
    {
        public const string Products = "products";
    }

    public static class HttpPolicies
    {
        public const int RetryCount = 2;
        public const int CircuitBreakerLimit = 3;
    }
}