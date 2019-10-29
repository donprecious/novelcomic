using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Services
{
    [Headers("Authorization: Bearer d3ddebb8b9d0e74cede5484b31f6ae63d6c70b95")]
  public  interface IBitly
  {
  //    string accessToken = "d3ddebb8b9d0e74cede5484b31f6ae63d6c70b95";

         [Post("/bitlinks")]
         Task<CreatedLinkResponse> ShortUrl([Body] CreateLink user); 

         [Get("/bitlinks/{bitlink}/clicks")] 
         Task<BitClicks> ClickCount([AliasAs("bitlink")] string bitlink);
  }

  public class Bitly
  {

  }
}
