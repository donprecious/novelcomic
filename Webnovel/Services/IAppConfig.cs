using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Services
{
  public  interface IAppConfig
    {
        Task<bool> SeedCountry();
        Task<bool> SeedPages();
        Task<bool> SeedRateType();
    }
}
