using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Hubs
{


    public class ComicCommentHub : Hub
    {
        private IComicComment _comment;

        public ComicCommentHub(IComicComment comment)
        {
            _comment = comment;
        }

        public async Task SendChapterComment(int comicId, string userId, string message)
        {

            Entities.ComicComment chapterCommentVm = new Entities.ComicComment()
            {
                UserId = userId,
                Comment = message,
                ComicId = comicId,
                DateCreated = DateTime.UtcNow
            };

            //var comment = Mapper.Map<await >(chapterCommentVm); 

            await _comment.Create(chapterCommentVm);
            //var commentSaved = Mapper.Map<NovelCommentVm>(comment);
            await _comment.Save();
            //get comment
            var comment = await _comment.GetComment(chapterCommentVm.Id);
            await Clients.All.SendAsync("commentReceived", comment);


            //await Clients.All.SendAsync("commentReceived", chapterCommentVm);


        }
    }
}
