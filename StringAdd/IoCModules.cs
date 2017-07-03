using System;
using System.Collections.Generic;
using System.Text;
using ConfigManagerFile;
using FileIO;
using Microsoft.Extensions.DependencyInjection;
using StringMathLib;

namespace StringAdd
{
    public sealed class IoCModules
    {
        public static IServiceCollection LoadAllIocModules(IServiceCollection services)
        {
            IoCString.Load(services);
            IocFile.Load(services);
            ConfigModules.Load(services);
            return services;

        }
    }
}
