using GameStore.FrontEnd.Clients;

public static class ServiceExtensions
{

    public static void AddLocalServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddRazorComponents();
        builder.Services.AddSingleton<GamesClient>();
        builder.Services.AddSingleton<IGenresClient, GenresClient>();
    }
}