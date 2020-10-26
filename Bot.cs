using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;


namespace Shiro_Sharp
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);



            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
                
            };

            Client = new DiscordClient(config);

            Client.Ready += OnReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                CaseSensitive = false,
            }; 

            Commands = Client.UseCommandsNext(commandsConfig);

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
