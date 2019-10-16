using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
   public interface IUser
    {
        
        Task<bool> Create(ApplicationUser applicationUser);
        Task<bool> AddRole(string UserId, string RoleId);
        Task<bool> RemoveRole(string UserId, string RoleId);
        Task<bool> Find(string UserId);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> GetUser(string userId);
        Task<IEnumerable<ApplicationUser>> List();
        Task<bool> HasPhoneNumber(string phone);
        Task Delete(string userId);
        Task<bool> AddUserToRole(string UserId, string RoleName);
        Task CreateDefaultAdminUser();
        Task<bool> CreateRole(string role);

        Task<string> CreateUser(string email, string password);
        Task<ICollection<Country>> Countries();

        Task<bool> UpdateUser(ApplicationUser user);
        Task<bool> Save();
    }
}
