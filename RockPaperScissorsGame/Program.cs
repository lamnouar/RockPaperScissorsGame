using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RockPaperScissorsGame.Services.Implementations;
using RockPaperScissorsGame.Services.Interfaces;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void Main()
        {
            var host = CreateHostBuilder().ConfigureServices((hostContext, services) =>
            {
                ConfigurerServices(services);
            }).Build();

            var playingService = host.Services.GetService<IPlayingService>();
            playingService.InitializePlayers();
            playingService.Play();
        }

        private static void ConfigurerServices(IServiceCollection services)
        {
            services.AddSingleton<IParameters, Parameters>();
            services.AddSingleton<IPlayingService, PlayingService>();
            services.AddSingleton<IPlayingStyleService, HumanPlayingStyleService>();
            services.AddSingleton<IPlayingStyleService, ComputerRandomPlayingStyleService>();
            services.AddSingleton<IPlayingStyleService, ComputerStandardPlayingStyle>();
            services.AddSingleton<IPlayingStyleFactory, PlayingStyleFactory>();
        }

        private static IHostBuilder CreateHostBuilder()
            => new HostBuilder().UseConsoleLifetime();
    }
}
