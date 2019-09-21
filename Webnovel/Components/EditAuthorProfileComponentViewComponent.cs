using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Repository;
using  System.Linq;
using Microsoft.EntityFrameworkCore;
using Sentry.Protocol;
using Webnovel.Models;

namespace Webnovel.Components
{
	[ViewComponent(Name = "EditAuthorProfile")]
	public class EditAuthorProfileViewComponent : ViewComponent
	{
        private ApplicationDbContext _context;


        public EditAuthorProfileViewComponent (ApplicationDbContext context)
        {
            _context = context;
        }

		public async Task<IViewComponentResult> InvokeAsync(string userId)
        {

            var uservm = new EditUserVm();
            var user = await _context.Users.Where(a => a.Id == userId).SingleAsync();
            var author = await _context.Authors.Where(a => a.UserId == userId).SingleOrDefaultAsync();
            if (author != null)
            {
                uservm.AuthorTitle = author.Title;
            }

            if (user != null)
            {
                uservm.UserId = user.Id;
                uservm.FirstName = user.FirstName;
                uservm.LastName = user.LastName;
                uservm.Phone = user.PhoneNumber;
            }
            return View("EditAuthorProfile", uservm);
        }
	}
}
