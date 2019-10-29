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
    public class NovelCommentHub : Hub
    {
        private INovelComment _comment; 
        public NovelCommentHub(INovelComment comment)
        {
            _comment = comment;
        }

        public async Task SendChapterComment(int chapterId, string userId, string message)
        {
          
                NovelChapterCommentVm chapterCommentVm = new NovelChapterCommentVm()
                {
                    UserId =  userId,
                    Comment = message,
                    ChapterId = chapterId,
                    DateTime =  DateTime.UtcNow
                }; 
             
                var comment = Mapper.Map<ChapterComment>(chapterCommentVm); 
             
               await _comment.CreateChapterComment(comment);
               //var commentSaved = Mapper.Map<NovelCommentVm>(comment);
             await   _comment.Save();
             var newComment = await _comment.GetChapterComment(comment.Id);
            await Clients.All.SendAsync("commentReceived", newComment);

            
            //await Clients.All.SendAsync("commentReceived", chapterCommentVm);


        }
    }
}
