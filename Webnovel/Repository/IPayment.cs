using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;


namespace Webnovel.Repository
{
  public   interface IPayment
  {
      Task AddPayment(PaymentHistory paymentHistory);
      Task<ICollection<PaymentHistory>> GetPaymentHistory();
      Task<ICollection<PaymentHistory>> GetPaymentHistory(string userId);
      Task AddCowriesPurchasedHistory(CowriesPurchasedHistory cowriesPurchasedHistory);
      Task<ICollection<CowriesPurchasedHistory>> GetCowriesPurchasedHistory();

      Task<ICollection<CowriesPurchasedHistory>>   GetCowriesPurchasedHistory(string userId);

      Task<bool> AddOrUpdateUserCowries(UserCowries userCowries);
      Task<UserCowries> GetUserCowries(string userId);
      Task AddSubsriptionPaymentHistory(SubscriptionPaidHistory subscriptionPaidHistory);
      Task<ICollection<SubscriptionPaidHistory>> GetSubscriptionPaidHistory();
      Task<ICollection<SubscriptionPaidHistory>> GetSubscriptionPaidHistory(string userId);
      Task<UserSubscription> GetUserSubscription(string userId);
      Task<bool> AddOrUpdateUserSubscription(UserSubscription subscription);
      Task CreateSubscription(Subscription subscription);
      Task<ICollection<Subscription>> GetSubcriptions();
      Task<Subscription> GetSubcriptions(int id);
      Task<RaveVerificationResponseModel> RavePaymentVerification(string txtId);
      Task<UserSubscription> GetFreeSubscription(string userId);
      Task<bool> HasFreeSubscription(string userId); 
      Task<bool> UserHasActiveSubscription(string userId); 
      Task<bool> PaymentReferenceExist(string referenceNo);
      Task AddFundWalletHistory(WalletFundHistory fundHistory);
      Task FundWallet(UserWallet userWallet);
      Task<bool> HasWallet(string userId);
      Task<UserWallet> GetUserWallet(string userId);
      Task<bool> Save();
  }
}
