using AoC.Days._1;
using AoC.Days._2;
using AoC.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AoC
{
    public static class ConfigureServices
    {
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            services.AddSingleton<IMain, AdventOfCode>();
            services.AddSingleton<IDayPuzzle, SlåIhopMöget>();
            services.AddSingleton<IDayPuzzle, SpelaFörFasen>();
            return services;
        }
    }
}
