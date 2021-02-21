﻿using System;
using Discord.Commands;
using Discord;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Discord.Gateway;

namespace RamokSelfbot.Commands.Fun
{
    [Command("fun", "This command is fun. - FUN")]
    class Fun : CommandBase
    {
        public override void Execute()
        {
            if (Message.Author.User.Id == Program.id)
            {
                EmbedMaker embed = new EmbedMaker()
                {
                    Title = "Fun help menu",
                    Description = "A list of funs commands",
                    Color = RamokSelfbot.Utils.EmbedColor(),
                    Footer = RamokSelfbot.Utils.footer(Message.Author.User)
                };

                EmbedMaker send1 = embed;
                EmbedMaker send2 = embed;
                int a = 0;

                foreach (var cmd in Client.CommandHandler.Commands.Values)
                {
                    a++;
                    StringBuilder args = new StringBuilder();
                    foreach (var arg in cmd.Parameters)
                    {
                        if (arg.Optional)
                            args.Append($" <{arg.Name}>");
                        else
                            args.Append($" [{arg.Name}]");
                    }


                    if (cmd.Description.Contains("- FUN"))
                    {
                        args.Append($"```\n{cmd.Description.Remove(cmd.Description.Length - 6, 6)}```");
                        if(a > 15)
                        {
                            send1.AddField(Client.CommandHandler.Prefix + cmd.Name, $"{args}");
                        } else
                        {
                            send2.AddField(Client.CommandHandler.Prefix + cmd.Name, $"{args}");
                        }
                        
                    }


                }


                


                RamokSelfbot.Utils.SendEmbed(Message, send1);
                RamokSelfbot.Utils.SendEmbedRsendIdget(Message, send2);
            }
        
              


            }
        

        public override void HandleError(string parameterName, string providedValue, Exception exception)
        {
            base.HandleError(parameterName, providedValue, exception);
            if(Message.Author.User.Id == Client.User.Id)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
