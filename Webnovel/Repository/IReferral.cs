using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
  public   interface IReferral
  {
      Task Create(Entities.Referral referral);
      Task AddReferred(Entities.Referred referred);
      Task<ICollection<Entities.Referral>> Referrals();
      Task<ICollection<Entities.Referred>> Refers();
      Task<bool> DeleteReferal(int id);
      Task<ICollection<Entities.Referred>> Refers(string userId);
      Task<bool> Update(Entities.Referral referral);
      Task<Entities.Referral> GetReferral(int referralId);
      Task<Entities.Referral> GetReferral(string userId);

      Task<bool> AddUniqueNormalBasicReferredUser(NormalReferredUser normalReferredUser);

      Task<ICollection<Entities.NormalReferredUser>> GetNormalReferredUsers();
      Task<ICollection<Entities.NormalReferredUser>> GetNormalReferredUsers(string referredUserId);
      Task<ICollection<Entities.NormalReferredUser>> GetNormalReferredUsersReferredBy(string refrreedByUserId);

      Task<bool> GenerateBasicReferralUrl(string userId);
 
      Task<bool> Save();
  }
}
