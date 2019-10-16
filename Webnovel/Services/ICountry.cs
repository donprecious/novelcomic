using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using Webnovel.Entities;

namespace Webnovel.Services
{
   public interface ICountry
   {
       [Get("/all")]
       Task< List<Country>> List();
   }

}
