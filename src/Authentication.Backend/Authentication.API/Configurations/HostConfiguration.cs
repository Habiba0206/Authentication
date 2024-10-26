namespace Authentication.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddDevTools()
            .AddPersistence()
            .AddHttpContextProvider()
            .AddIdentityInfrustructure()
            .AddNotificationInfrustructure()
            .AddMappers()
            .AddExposers()
            .AddCors();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseCors();
        app
            .UseDevTools()
            .UseExposers()
            .UseIdentityInfrustructure();

        return new(app);
    }
}
