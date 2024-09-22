using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using _6LetterWords.Config;
using _6LetterWords.Dal.Interfaces;
using _6LetterWords.Dal;
using _6LetterWords.Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var wordProcessor = host.Services.GetRequiredService<WordProcessor>();
        await wordProcessor.ProcessWordsAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) => config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
            .ConfigureServices((context, services) =>
            {
                services.Configure<AppConfig>(context.Configuration.GetSection("AppConfig"));
                services.AddScoped<IDataReaderWriter<IEnumerable<string>>, FileReaderWriter>();

                services.AddScoped<WordProcessor>();
            });
}
