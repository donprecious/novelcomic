using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Refit;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Services;

namespace Webnovel.Repository
{
    public class Referral : IReferral
    {
        private ApplicationDbContext _context;

        public Referral(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task Create(Entities.Referral referral)
        {
            await _context.Referrals.AddAsync(referral);
        }

        public async Task AddReferred(Entities.Referred referred)
        {
            await _context.Referreds.AddAsync(referred);
        }

        public async Task<ICollection<Entities.Referral>> Referrals()
        {
            return await _context.Referrals
                .Include(a=>a.User)
                .Include(a=>a.referreds)
                .ToListAsync();
        }

        public async Task<bool> Update(Entities.Referral referral)
        {
            _context.Entry(referral).State = EntityState.Modified;
            return await Save();
        }

        public async Task<Entities.Referral> GetReferral(int referralId)
        {
            return await _context.Referrals
                .Where(a=>a.Id == referralId)
                .Include(a=>a.User)
                .Include(a=>a.Country)
                .Include(a=>a.referreds)
              
                .SingleOrDefaultAsync();
        }

        public async Task<Entities.Referral> GetReferral(string userId)
        {
            return await _context.Referrals
                .Where(a=>a.UserId == userId)
                .Include(a=>a.User)
                .Include(a=>a.Country)
                .Include(a=>a.referreds)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AddUniqueNormalBasicReferredUser(NormalReferredUser normalReferredUser)
        {
            var refreedUser = await GetNormalReferredUsers(normalReferredUser.UserId);
            if (refreedUser != null)
            {
                //add 
              await  _context.NormalReferredUsers.AddAsync(normalReferredUser);
              return true;
            }
            return false;

        }

        public async Task<ICollection<NormalReferredUser>> GetNormalReferredUsers()
        {
            return await _context.NormalReferredUsers.ToListAsync();
        }

        public async Task<ICollection<NormalReferredUser>> GetNormalReferredUsers(string userId)
        {
            return await _context.NormalReferredUsers.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<ICollection<NormalReferredUser>> GetNormalReferredUsersReferredBy(string refrreedByUserId)
        {
            return await _context.NormalReferredUsers.Where(a => a.ReferredUserId ==refrreedByUserId).Include(a=>a.User).ToListAsync();

        }

        public async Task<bool> GenerateBasicReferralUrl(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {

                try
                {
                    var shortUrl = await RestService.For<IBitly>("https://api-ssl.bitly.com/v4/").ShortUrl(
                        new CreateLink()
                        {
                            long_url = "http://alkebulania.com/account/register/?email=" + user.Email,

                            tags = new List<string>()
                            {
                                "alkebulania", "Novel", "Comics", "Animations", user.FirstName, user.LastName
                            },
                            title = "alkebulania " + user.Email + "- Sign up link"
                        });
                    if (shortUrl != null)
                    {
                        user.BasicReferralLink = shortUrl.link;
                    }
                    _context.Entry(user).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (ValidationApiException validationException)
                {
                    // handle validation here by using validationException.Content, 
                    // which is type of ProblemDetails according to RFC 7807
                    Console.WriteLine(validationException);
                }
                catch (ApiException exception)
                {
                    // other exception handling
                    Console.WriteLine(exception);
                }

           
            }

            return false;
        }

        public async Task<bool> DeleteReferal(int id)
        {
           var r = await _context.Referrals.FindAsync(id);
           _context.Referrals.Remove(r);
           return await Save();
        }
        public async Task<ICollection<Entities.Referred>> Refers()
        {
            return await _context.Referreds.Include(a=>a.Referral)
                .Include(a=>a.User)
                .ToListAsync();
        } 
        public async Task<ICollection<Entities.Referred>> Refers(string userId)
        {
            return await _context.Referreds
                .Where(a=>a.Referral.UserId== userId)
                .Include(a=>a.User)
                .Include(a=>a.Referral)
                .ToListAsync();
        } 

        public async Task<bool> Save()
        {
            return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
        }
    }
}
