using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
//////////////////////////////////////////
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Interactivity;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
//////////////////////////////////////////
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Shiro_Sharp.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Pong!")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong! " + ctx.Client.Ping + "ms").ConfigureAwait(false);
        }


        [Command("echo")]
        [Aliases(new string[2]{ "respond", "say"})]
        public async Task Echo(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(message.Result.Content);
        }


        [Command("echoreaction")]
        [Aliases(new string[2] { "respondreaction", "sayreaction" })]
        public async Task EchoReaction(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var reacthere = await ctx.Channel.SendMessageAsync("React Here");
            var message = await interactivity.WaitForReactionAsync(x => x.Message == reacthere &&  x.User == ctx.User).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(message.Result.Emoji);
        }

        [Command("emojipoll")]
        public async Task EmojiPoll(CommandContext ctx, TimeSpan duration, params DiscordEmoji[] emojiOptions)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var options = emojiOptions.Select(x => x.ToString());
            var pollEmbed = new DiscordEmbedBuilder
            {
                Title = "Poll",
                Description = string.Join(" ", options)
            };

            var pollMessage = await ctx.Channel.SendMessageAsync(embed: pollEmbed).ConfigureAwait(false);

            foreach(var option in emojiOptions)
            {
                await pollMessage.CreateReactionAsync(option).ConfigureAwait(false);
            }

            var result = await interactivity.CollectReactionsAsync(pollMessage, duration).ConfigureAwait(false);
            var distinctResult = result.Distinct();
            var results = distinctResult.Select(x => $"{x.Emoji}: {x.Total}");
            await ctx.Channel.SendMessageAsync(string.Join("\n", results)).ConfigureAwait(false);
        }

        [Command("poll")]
        public async Task Poll(CommandContext ctx, params string[] description)
        {
            var afterdesc = description.Select(x => x.ToString());
            var interactivity = ctx.Client.GetInteractivity();
            var pollEmbed = new DiscordEmbedBuilder
            {
                Description = afterdesc.ToString(),
                Timestamp = DateTime.UtcNow,
                Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    Name = ctx.Member.Nickname + "• Poll",
                    IconUrl = ctx.Message.Author.AvatarUrl
                }

            };
            var pollMessage = await ctx.Channel.SendMessageAsync(embed: pollEmbed).ConfigureAwait(false);
            await pollMessage.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":yes:")).ConfigureAwait(false);
            await pollMessage.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":no:")).ConfigureAwait(false);
        }

    }
}
