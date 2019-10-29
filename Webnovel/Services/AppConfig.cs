using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Refit;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Services
{
    public class AppConfig : IAppConfig
    {
        private ApplicationDbContext _context;

        public AppConfig(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SeedCountry()
        {
            var hasCountries = await _context.Countries.AnyAsync();
            if (hasCountries)
            {
                return false;
            }

           List<Country> countries = await RestService.For<ICountry>("https://restcountries.eu/rest/v2").List();
            if (countries != null)
            {
               await _context.Countries.AddRangeAsync(countries);
               await _context.SaveChangesAsync();
               return true;
            }

            return false;
        }

        
    }
}
