namespace Core.Infrastructure.Configurations;

public class AuthorizationConfigurations
{
    public const string AdminPolicy = "RequireAdmin";
    public const string MerchandiserPolicy = "RequireMerchandiser";
    public const string AdminOrMerchandiserPolicy = $"AdminOrMerchandiser";
}