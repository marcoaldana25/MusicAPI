using MusicAPI.Accessors;
using MusicAPI.Accessors.Interfaces;

namespace MusicAPI.InversionOfControl
{
    public static class InversionOfControlConfiguration
    {
        public static void ConfigureAccessorDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthorizationAccessor, AuthorizationAccessor>();
        }
    }
}
