﻿using Discord;
using Discord.Commands;
using GiftAGifBot.DAL;
using GiftAGifBot.DAL.Models;
using GiftAGIfBot.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGIfBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        public PictureService PictureService { get; set; }

        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder] [Summary("The text to echo")] string echo) {
            return ReplyAsync(echo);
        }

        [Command("cat")]
        public async Task CatAsync() {
            // Get a stream containing an image of a cat
            var stream = await PictureService.GetCatPictureAsync();
            // Streams must be seeked to their beginning before being uploaded!
            stream.Seek(0, SeekOrigin.Begin);
            await Context.Channel.SendFileAsync(stream, "cat.png");
        }

        // Get info on a user, or the user who invoked the command if one is not specified
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null) {
            user = user ?? Context.User;

            await ReplyAsync(user.ToString());
        }

        //[Command("gif")]
        //public async Task GifAsync() {
        //    using (var gifContext = new GifContext()) {
        //        List<Gif> gifs = gifContext.Gifs.ToList();
        //        Random rand = new Random();
        //        int num = rand.Next(0, gifs.Count);
        //        string fileName = gifs[num].FileName;
        //        string fullPath = Gif.TargetDirectory + '\\' + fileName;
        //        await Context.Channel.SendFileAsync(fullPath, "Sending random gif #" + num.ToString());
        //    }
        //}

        [Command("gif")]
        public async Task GifAsync([Summary("Gets Specific Gif By Identifier Number")] int num = -1) {
            var watch = new System.Diagnostics.Stopwatch();            
            string comment = "";
            using (var gifContext = new GifContext()) {

                if (num == -1) {
                    //Get random gif
                    Random rand = new Random();
                    num = rand.Next(0, gifContext.Gifs.Count());
                    comment = "random ";
                }

                Gif gif = gifContext.Gifs.First(g => g.Identifier == num);
                if (gif == null) {
                    await Context.Channel.SendMessageAsync("Gif Not Found");
                    return;
                }
                string fileName = gif.FileName;
                string fullPath = Gif.TargetDirectory + '\\' + fileName;
                gif.DisplayCount++;
                watch.Start();
                await gifContext.SaveChangesAsync();
                watch.Stop();
                await Context.Channel.SendFileAsync(fullPath, "Sending " + comment + "gif #" + num.ToString() + " took " + watch.ElapsedMilliseconds.ToString() + " ms to save");
            }
        }

    }
}
