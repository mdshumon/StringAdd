using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace FileIO
{
    public sealed class IocFile
    {
        public static void Load(IServiceCollection services)
        {
            services.AddSingleton<IOOperation>();

        }
    }
}
