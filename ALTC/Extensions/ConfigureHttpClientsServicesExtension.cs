using ALTC.Application.Infrastructure;
using ALTC.Utils;

namespace ALTC.Extensions;

public static class ConfigureHttpClientsServicesExtension
{
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        CreateClient(HttpClientNames.JsonApi, Environment.GetEnvironmentVariable(EnvironmentVariables.BaseUrlJsonPlaceHolderApi), services);
    }


    private static void CreateClient(string name, string baseAdress, IServiceCollection services)
    {
        services.AddHttpClient(name, client =>
        {
            client.BaseAddress = new Uri(baseAdress);
        });
    }
}