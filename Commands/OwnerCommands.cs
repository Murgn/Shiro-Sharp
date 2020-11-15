using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    [RequireOwner]
    class OwnerCommands : BaseCommandModule
    {
        [Command("shutdown")]
        [Description("Murders the bot")]
        public async Task Shutdown(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Shutting Down!");
            Environment.Exit(0);
        }
        [Command("restart")]
        [Description("Restarts the bot")]
        public async Task Restart(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Restarting!");
            Process.Start("C:/Users/morga/Desktop/SHIRO/shiro-sharp/Shiro-Sharp/Shiro-Sharp/bin/Debug/netcoreapp3.1/Shiro-Sharp.exe");
            await Task.Delay(1);
            Environment.Exit(0);
        }


    }
}
