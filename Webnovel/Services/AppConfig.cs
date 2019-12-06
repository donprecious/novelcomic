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

        public async Task<bool> SeedPages()
        {
            var pages = await _context.Pages.AnyAsync();
            if (!pages)
            {
                await _context.Pages.AddRangeAsync(new List<Page>()
                {
                    new Page()
                    {
                        Name = "FAQ",
                        Content = "<h1>Frequently asked questions</h1>"
                    },
                    new Page()
                    {
                        Name = "About",
                        Content = "<h1>About Us </h1>"
                    },
                    new Page()
                    {
                        Name = "Privacy and Policy",
                        Content = "<h1>Privacy and Policy</h1>"
                    },
                    new Page()
                    {
                        Name = "Terms and Condition",
                        Content = "<h1>Terms and Condition</h1>"
                    },
            
                });
                await  _context.SaveChangesAsync(); 
            }
        
            return true;
        } 
        public async Task<bool> SeedRateType()
        {
            var pages = await _context.RatingTypes.AnyAsync();
            if (!pages)
            {
                await _context.RatingTypes.AddRangeAsync(new List<RatingType>()
                {
                    new RatingType()
                    {
                        Name = "Translation Quality"
                    },
                    new RatingType()
                    {
                        Name = "Stability of Updates"
                    },
                    new RatingType()
                    {
                        Name = "Story Development"
                    },
                    new RatingType()
                    {
                        Name = "Character Design"
                    },
                    new RatingType()
                    {
                        Name = "World Background"
                    },
                });
                await  _context.SaveChangesAsync(); 
            }
        
            return true;
        }

     
    }
}
