using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConfigManagerFile
{
    public class ConfigModules
    {
        public static void Load(IServiceCollection services)
        {
            services.AddSingleton<ILoggerFactory>(x => new LoggerFactory().AddFile(ReadConfig.AppSettings.Log4NetPathLocation + "Logs/numbers-{Date}.txt"));
            services.AddSingleton<ReadConfig.AppSettings, ReadConfig.AppSettings>();
        
        }
    }
}