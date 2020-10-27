using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
//////////////////////////////////////////
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Interactivity;
using DSharpPlus.EventArgs;
//////////////////////////////////////////
using Newtonsoft.Json;

namespace Shiro_Sharp.Commands
{
    public class MathCommands : BaseCommandModule
    {

        [Command("add")]
        [Description("Adds two numbers")]
        public async Task Add(CommandContext ctx, [Description("First Number")]int numberOne, [Description("Second Number")]int numberTwo)
        {
            await ctx.Channel.SendMessageAsync((numberOne + numberTwo).ToString()).ConfigureAwait(false);
        }

        [Command("subtract")]
        [Description("Subtracts two numbers")]
        public async Task Subtract(CommandContext ctx, [Description("First Number")]int numberOne, [Description("Second Number")]int numberTwo)
        {
            await ctx.Channel.SendMessageAsync((numberOne - numberTwo).ToString()).ConfigureAwait(false);
        }

        [Command("random")]
        [Description("Gets a random number between two numbers")]
        public async Task Random(CommandContext ctx, [Description("First Number")]int numberOne, [Description("Second Number")]int numberTwo)
        {
            await ctx.Channel.SendMessageAsync((new Random().Next(numberOne, numberTwo)).ToString()).ConfigureAwait(false);
        }

    }
}
