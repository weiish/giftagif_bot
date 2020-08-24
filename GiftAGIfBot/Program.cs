using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GiftAGIfBot.Services;
using System.Net.Http;

namespace GiftAGIfBot
{
    //TO DO
    /*
     * Add table for pending tags, create UI to easily hit Y or N for accepting tags
     * 
     * 
     * 
     * 1. On login, 
     *      connect to SQL database 
     *      validate gifs folder path
     * 2. Commands 
     *      !g - randomly spits out a gif with ID
     *      !t[id] [tag] - Adds tag to 'pending gif tags' // OR adds +1 to 'pending gif tags' counter if already in pending gifs // OR adds to 'endorsements' if tag already exists in 'gif tags'
     *      Enable/Disable channel tag spawning
     *      Enable/Disable channel context spawning
     *      
     * 3. Spawning
     *      ? Toggle Auto Gif Spawn - randomly spits out a gif every X messages to ask for tags
     *             Idea for implementation: Spits out a gif every X points, messages add points and so does time since last message. Keeps track of last 50 messages in channel?
     *      Toggle Context Gif Spawn - If there is a match on a message sent, it will use the context and send a related gif
     *      
     */


    public class Program
    {
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            using (var services = ConfigureServices()) {
                var client = services.GetRequiredService<DiscordSocketClient>();

                client.Log += Log;
                services.GetRequiredService<CommandService>().Log += Log;

                await client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("GiftAGifBotToken", EnvironmentVariableTarget.User));
                await client.StartAsync();

                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();

                // Block this task until the program is closed.
                await Task.Delay(Timeout.Infinite);
            }
        }

        private ServiceProvider ConfigureServices() {
            return new ServiceCollection()                
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .AddSingleton<PictureService>()
                .BuildServiceProvider();
        }

        private Task Log(LogMessage message)
        {
            switch (message.Severity) {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message} {message.Exception}");
            Console.ResetColor();

            // If you get an error saying 'CompletedTask' doesn't exist,
            // your project is targeting .NET 4.5.2 or lower. You'll need
            // to adjust your project's target framework to 4.6 or higher
            // (instructions for this are easily Googled).
            // If you *need* to run on .NET 4.5 for compat/other reasons,
            // the alternative is to 'return Task.Delay(0);' instead.
            return Task.CompletedTask;
        }


    }


}
