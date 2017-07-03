using System;
using Microsoft.Extensions.DependencyInjection;
using StringMathLib;
using Xunit;

namespace StringAdd.Test
{
    public class StringNumberTest
    {
        static IServiceCollection services = new ServiceCollection();
        static IServiceProvider IoC { get; set; }

        [Fact]
        public void AddOrSubTest()
        {

            IoCString.Load(services);
            IoC = services.BuildServiceProvider();
            var sum = IoC.GetService<StringNumber>();

            Assert.Equal("2", sum.AddOrSubNumber("1", "1"));
            Assert.Equal("0", sum.AddOrSubNumber("1", "-1"));         
            Assert.Equal("-1", sum.AddOrSubNumber("-1", "0"));
            Assert.Equal("-2", sum.AddOrSubNumber("-1", "-1"));
            Assert.Equal("-2", sum.AddOrSubNumber("--1", "-1"));
            Assert.Equal("-20", sum.AddOrSubNumber("--1", "-19"));
        }
    }
}
