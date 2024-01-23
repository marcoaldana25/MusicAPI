﻿using MusicAPI.Accessors;
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
            serviceCollection.AddTransient<ISpotifyAccessor, SpotifyAccessor>();
        }

        public static void ConfigureManagerDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISpotifyManager, SpotifyManager>();
        }

        public static void ConfigureUtilitiesDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<Utilities.Interfaces.IConfigurationManager, Utilities.ConfigurationManager>(serviceProvider =>
            {
                return new Utilities.ConfigurationManager(configuration);
            });
        }
    }
}
