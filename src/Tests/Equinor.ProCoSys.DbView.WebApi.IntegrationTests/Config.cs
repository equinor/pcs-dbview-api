﻿using Microsoft.Extensions.Configuration;

namespace Equinor.ProCoSys.DbView.WebApi.IntegrationTests
{
    internal class Config
    {
        private static Config instance;
        private IConfigurationRoot _config;

        private Config() =>
            _config = new ConfigurationBuilder()
                .AddJsonFile("testappsettings.json")
                .AddUserSecrets<Config>()
                .Build();

        private static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Config();
                }
                return instance;
            }
        }

        public static string TestClientId(string clientConfigKey) => Instance._config[$"{clientConfigKey}:ClientId"];
        public static string TestClientSecret(string clientConfigKey) => Instance._config[$"{clientConfigKey}:ClientSecret"];
        public static string Authority => Instance._config["Authority"];
        public static string WebApiScope => Instance._config["WebApiScope"];
        public static string ApplicationUrl => Instance._config["ApplicationUrl"];
    }
}
