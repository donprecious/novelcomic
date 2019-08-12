using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
  public  interface IAnimation
  {
      Task CreateAnimation(Entities.Animation animation);
     
      Task<List<Entities.Animation>> GetAllAnimations();
      Task<Entities.Animation> GetAnimation(int animationId);
        Task<List<Entities.Animation>> GetAuthorAnimations(int id);
      Task DeleteAnimation(int id);
   
      Task<bool> FindAnimation(int animationId);


      

      Task CreateAnimationEpisode(AnimationEpisode animationEpisode);
      Task<bool> FindAnimationEpisode(int animationEpisodeId);
        Task< ICollection<Entities.AnimationEpisode>> GetAnimationEpisodes(int animationId);
      Task<Entities.AnimationEpisode> GetAnimationEpisode(int animationEpisodeId);
   
      Task DeleteAnimationEpisode(AnimationEpisode animationEpisode);
      Task<bool> Save();
  }
}
