using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigManagerFile
{
    public class Common
    {
        static IConfigurationRoot Configuration = GetConfiguration();
        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();
        }

        public static void LoadConfig(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<ReadConfig.AppSettings>(Configuration.GetSection("AppSettings"));
           
        }
        public static string LogPath
        {
            get
            {
                return Configuration.GetValue<string>("AppSettings:Log4NetPathLocation");
            }
        }
    }
}
