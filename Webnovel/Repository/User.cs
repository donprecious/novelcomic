using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Models;

namespace Webnovel.Repository
{
    public class User : IUser
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public User(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //public async Task AddRole(string userId, string roleId)
        //{
        //   return   NotImplementedException();
        // //await _context.UserRoles.AddAsync(new UserRoles
        // //   {
        // //       UserId =userId,
        // //       RoleId = roleId
        // //   });
        //}

        public async Task<bool> HasPhoneNumber(string phone)
        {
           return await _context.Users.AnyAsync(a => a.PhoneNumber == phone);
        }

        public async Task<bool> Create(ApplicationUser user)
        {
            //var mappedUser = Mapper.Map<Users>(user);
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task Delete(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            _context.Users.Remove(user);
        }
        
        public async Task<ApplicationUser> GetUser(string id)
        {
            var user = await Task.Run(() => _context.Users.SingleOrDefault(a => a.Id.ToString() == id));
            return user;
        }
       

        public async Task<bool> Find(string userId)
        {
           // Guid id = Guid.Parse(userId);

           var user = await _context.Users.SingleOrDefaultAsync(a => a.Id == userId);
            if (user != null)
            {
                return true;
            }
            return false;

        }
        public  async Task<IEnumerable<ApplicationUser>> List()
        {

            return await _context.Users.ToListAsync();
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {

            return await _context.Users.Where(a => a.Email == email).SingleOrDefaultAsync();
        }

        public async Task<bool> RemoveRole(string userId, string RoleName)
        {
          
            var user = await _userManager.FindByIdAsync(userId);

            var remove = await _userManager.RemoveFromRoleAsync(user, RoleName);
            if (remove.Succeeded)
            {
                return true;
            }
            return false;
        }

    

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            if (saved >= 0)
            {
               
                return true;
            }

            return false;
        }

        public async Task<bool> AddRole(string UserId, string RoleName)
        {
           var user = await _userManager.FindByIdAsync(UserId);
          
           var added = await _userManager.AddToRoleAsync(user,RoleName);
            if (added.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
