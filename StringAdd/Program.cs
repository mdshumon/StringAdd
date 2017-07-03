using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StringMathLib;

namespace StringAdd
{
    class Program
    {
        static IServiceCollection services = new ServiceCollection();
        static IServiceProvider IoC { get; set; }
        readonly ILogger iLog;
        public Program(ILoggerFactory logf)
        {
            iLog = logf.CreateLogger<Program>();
        }
        static void Main(string[] args)
        {
            services.AddLogging();
            services = IoCModules.LoadAllIocModules(services);
            IoC = services.BuildServiceProvider();
            var sum = IoC.GetService<StringNumber>();

            Console.WriteLine(sum.AddOrSubNumber("6", "-7"));

            Console.ReadKey();
        }
    }
}