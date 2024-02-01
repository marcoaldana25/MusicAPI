using MusicAPI.Accessors;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Engines;
using MusicAPI.Engines.Interfaces;
using MusicAPI.Managers;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.Mapping;

namespace MusicAPI.InversionOfControl
{
    /// <summary>
    /// Class responsible for extension methods that register services necessary for the app to function.
    /// </summary>
    public static class InversionOfControlConfiguration
    {
        /// <summary>
        /// Responsible for registering necessary services for the MusicAPI.Accessors project
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureAccessorDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthorizationAccessor, AuthorizationAccessor>();
            serviceCollection.AddTransient<ISpotifyAccessor, SpotifyAccessor>();
        }

        /// <summary>
        /// Responsible for registering necessary services for the MusicAPI.Engines project
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureEngineDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQueryEngine, QueryEngine>();
        }

        /// <summary>
        /// Responsible for registering necessary services for the MusicAPI.Manager project
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureManagerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(UserProfileMappingProfile).Assembly);

            serviceCollection.AddTransient<ISpotifyManager, SpotifyManager>();
        }

        /// <summary>
        /// Responsible for registering necessary services for the MusicAPI.Utilities project
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public static void ConfigureUtilitiesDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<Utilities.Interfaces.IConfigurationManager, Utilities.ConfigurationManager>(serviceProvider =>
            {
                return new Utilities.ConfigurationManager(configuration);
            });
        }
    }
}
