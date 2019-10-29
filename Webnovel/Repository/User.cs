using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;
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

        public async Task<bool> AddRole(string UserId, string RoleId)
        {
            throw new NotImplementedException();
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

        public async Task<bool> AddToRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var add = await _userManager.AddToRoleAsync(user, role);
            if (add.Succeeded)
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

        public async Task<bool> UpdateUser(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return await Save();
        }

        public async Task<bool> AddUserToRole(string UserId, string RoleName)
        {
           var user = await _userManager.FindByIdAsync(UserId);
           if (!(await _userManager.IsInRoleAsync(user, RoleName)))
           {
               var added = await _userManager.AddToRoleAsync(user,RoleName);
               if (added.Succeeded)
               {
                   return true;
               }
           }
           return false;
        }


        string superRole = "SuperAdmin";
        string adminRole = "Admin";
        public async Task CreateDefaultAdminUser()
        {
            //create role 
          await  CreateRole(adminRole);
          var userId = await CreateUser("Don0@gmail.com", "Don0@gmail.com");

          if (userId != null)
          {
              await AddUserToRole(userId, adminRole);
          }
        }

        public async Task<bool> CreateRole(string role)
        {
            if (! await _roleManager.RoleExistsAsync(role))
            {
                // first we create Admin rool   
              var create =  await _roleManager.CreateAsync(new IdentityRole(role));
              if (create.Succeeded)
              {
                  return true;
              }
            }

            return false;
        }

        public async Task<string> CreateUser(string email, string password)
        {
            var user = new ApplicationUser()
            {
                Email = email,
                UserName = email, 
                
            };
            var user1 = await _userManager.FindByEmailAsync(email);
            if (user1== null)
            {
                var create = await _userManager.CreateAsync(user, password);
                if (create.Succeeded)
                {
                    return user.Id;
                }
            }
            return null;
        }

        public async Task<ICollection<Country>> Countries()
        {
            return await _context.Countries.ToListAsync();
        } 
    }
}
