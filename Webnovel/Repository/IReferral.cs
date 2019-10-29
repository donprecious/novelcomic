using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
      Task<bool> Save();
  }
}
