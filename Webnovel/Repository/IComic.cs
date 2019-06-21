using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
  public  interface IComic
  {
      Task CreateComic(Entities.Comic comic);
      Task<List<Entities.Comic>> GetAllComics();
      Task<Entities.Comic> GetComic(int comicId);
        Task<List<Entities.Comic>> GetAuthorComics(int id);
      Task DeleteComic(int id);
      Task EditComic(Entities.Comic comic);
      Task<bool> FindComic(int comicId);


        Task CreateComicScene(ComicScene comicScene);
      Task<ICollection<Entities.ComicScene>> GetComicScenes(int comicId);
      Task GetComicScene(int sectionId);
      Task EditComicScene(ComicScene comicScene);
      Task DeleteComicScene();


      Task CreateEpisode(Episode episode);
      Task<bool> FindEpisode(int episodeId);
        Task GetEpisodes(int novelId);
      Task<Entities.Episode> GetEpisode(int episodeId);
      Task EditEpisode(EpisodeVm episode );
      Task DeleteEpisode(Episode episode);
      Task<bool> Save();
  }
}
