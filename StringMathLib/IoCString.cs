using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace StringMathLib
{
    public sealed class IoCString
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<NumberHelper>();
            services.AddTransient<StringNumber>();
        }
    }
}
