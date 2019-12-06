using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Refit;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Helpers;
using Webnovel.Models;
using Webnovel.Services;

namespace Webnovel.Repository
{
    public class Payment : IPayment
    {
        private ApplicationDbContext _context;
        private HttpClient httpClient = new HttpClient(new HttpLoggingHandler()){ BaseAddress = new Uri(Constants.RaveApiUrl)};
        public Payment(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPayment(PaymentHistory paymentHistory)
        {
           await _context.PaymentHistories.AddAsync(paymentHistory);
        }

        public async Task<ICollection<PaymentHistory>> GetPaymentHistory()
        {
            return await _context.PaymentHistories.Include(a => a.User).ToListAsync();
        }

        public async Task<ICollection<PaymentHistory>> GetPaymentHistory(string userId)
        {
            return await _context.PaymentHistories.Include(a => a.User).Where(a=>a.UserId == userId).ToListAsync();
        }

        public async Task AddCowriesPurchasedHistory(CowriesPurchasedHistory cowriesPurchasedHistory)
        {
            await _context.CowriesPurchasedHistories.AddAsync(cowriesPurchasedHistory);
        }

        public async Task<ICollection<CowriesPurchasedHistory>> GetCowriesPurchasedHistory()
        {
            return await _context.CowriesPurchasedHistories
                .Include(a=>a.PaymentHistory)
                .Include(a=>a.User)
                .ToListAsync();
        }

        public async Task<ICollection<CowriesPurchasedHistory>>  GetCowriesPurchasedHistory(string userId)
        {
            return await _context.CowriesPurchasedHistories
                .Include(a=>a.PaymentHistory)
                .Include(a=>a.User)
                .Where(a=>a.UserId == userId).ToListAsync();
        }

        public async Task<bool> AddOrUpdateUserCowries(UserCowries userCowries)
        {

            var cowries = await GetUserCowries(userCowries.UserId);
            if (cowries != null)
            {
                //update  
                cowries.Cowries += userCowries.Cowries;
                _context.Entry(cowries).State = EntityState.Modified;
            }
            else
            {
                //add new 
           await     _context.UserCowrieses.AddAsync(userCowries);
            }

           return await Save();
        }

        public async Task<UserCowries> GetUserCowries(string userId)
        {
            return await _context.UserCowrieses.Where(a => a.UserId == userId).Include(a => a.User).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Subscription
        /// </summary>
        /// <returns></returns>

        public async Task AddSubsriptionPaymentHistory(SubscriptionPaidHistory subscriptionPaidHistory)
        {
            await _context.SubscriptionPaidHistories.AddAsync(subscriptionPaidHistory);
        }

        public async Task<ICollection<SubscriptionPaidHistory>> GetSubscriptionPaidHistory()
        {
            return await _context.SubscriptionPaidHistories
                .Include(a => a.User)
                .Include(a => a.PaymentHistory)
                .ToListAsync();
        }
        
        public async Task<ICollection<SubscriptionPaidHistory>> GetSubscriptionPaidHistory(string userId)
        {
            return await _context.SubscriptionPaidHistories
                .Include(a => a.User)
                .Include(a => a.PaymentHistory)
                .Where(a=>a.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserSubscription> GetUserSubscription(string userId)
        {
         return await   _context.UserSubscriptions.Where(a => a.UserId == userId).SingleOrDefaultAsync();
        }
        public async Task<bool> AddOrUpdateUserSubscription(UserSubscription subscription)
        {

            var userSub = await GetUserSubscription(subscription.UserId);
            if (userSub != null)
            {
                //update  
                userSub.Amount = subscription.Amount;
                userSub.DueDate = subscription.DueDate;
                userSub.SubscriptionId = subscription.SubscriptionId;
                userSub.Description = subscription.Description;
                _context.Entry(userSub).State = EntityState.Modified;
            }
            else
            {
                //add new 
                await     _context.UserSubscriptions.AddAsync(subscription);
            }

            return await Save();
        }

        public async Task CreateSubscription(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }

        public async  Task<ICollection<Subscription>> GetSubcriptions()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async  Task<Subscription> GetSubcriptions(int Id)
        {
            return await _context.Subscriptions.FindAsync(Id);
        }
        public async  Task<UserSubscription> GetFreeSubscription(string userId)
        {
            return await _context.UserSubscriptions.Where(a=>Math.Abs(a.Amount)  < 0.00 && a.UserId == userId).FirstOrDefaultAsync();
        }
        public async  Task<bool> HasFreeSubscription(string userId)
        {
            return await _context.UserSubscriptions.Where(a=>Math.Abs(a.Amount)  < 0.00 && a.UserId == userId).AnyAsync();
        }

        public async Task<bool> UserHasActiveSubscription(string userId)
        {
            var userSub = await GetUserSubscription(userId);
            if (userSub == null) return false;

          if(Utilities.CalculateDaysRemainingFromToday(userSub.DueDate) > 0) return true
              ;
            return false;
        }

        public async Task<RaveVerificationResponseModel> RavePaymentVerification(string txtId)
        {
            try
            {
              
                var payment = await RestService.For<IRavePayment>(httpClient).Verify(new RaveVerificationData()
                {
                    SECKEY = Constants.Wave_test_SecretKey,
                    txref = txtId
                });
                return payment;
            }
            catch (ValidationApiException validationException)
            {
                Console.WriteLine(validationException);
              var x =  new RaveVerificationResponseModel()
                {
                    message = validationException.Content.Detail,
                    status = validationException.Content.Status.ToString()
                };
              return x;
            }
            catch (ApiException exception)
            { 

                // other exception handling
                var x =  new RaveVerificationResponseModel()
                {
                    message = exception.Content,
                    status = exception.StatusCode.ToString()
                };
                return x;
            }
        
        } 
        public async Task<bool> PaymentReferenceExist(string referenceNo)
        {
            return await _context.PaymentHistories.AnyAsync(a => a.Id == referenceNo);
        }

        public async Task AddFundWalletHistory(WalletFundHistory fundHistory)
        {
            await _context.WalletFundHistories.AddAsync(fundHistory);

        }

        public async Task FundWallet(UserWallet userWallet)
        {
            var wallet = await _context.UserWallets.Where(a => a.UserId == userWallet.UserId).SingleOrDefaultAsync();
            if (wallet != null)
            {
                //update balance 
                wallet.Amount += userWallet.Amount;
               await _context.SaveChangesAsync();
            }
            else
            {
                //create a new wallet 
                await _context.UserWallets.AddAsync(userWallet);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<bool> HasWallet(string userId)
        {
            return await _context.UserWallets.AnyAsync(a => a.UserId == userId);
        }

        public async Task<UserWallet> GetUserWallet(string userId)
        {
            return await _context.UserWallets.SingleOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task<bool> Save()
        {
            return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
        }

      
    }
}

