using MusicAPI.Accessors;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Managers;
using MusicAPI.Managers.Interfaces;

namespace MusicAPI.InversionOfControl
{
    public static class InversionOfControlConfiguration
    {
        public static void ConfigureAccessorDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthorizationAccessor, AuthorizationAccessor>();
        }

        public static void ConfigureManagerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISpotifyManager, SpotifyManager>();
        }
    }
}
