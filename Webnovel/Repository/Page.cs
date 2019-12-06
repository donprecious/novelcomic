using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;

namespace Webnovel.Repository
{
    public class Page :IPage
    {
        private ApplicationDbContext _context;

        public Page(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePage(Entities.Page page)
        {
          await  _context.Pages.AddAsync(page);
        }

        public async Task<Entities.Page> GetPage(int pageId)
        {
            return await _context.Pages.FindAsync(pageId);
        }
        public async Task<ICollection<Entities.Page>> GetPages()
        {
            return await _context.Pages.ToListAsync();
        }
        public async Task EditPage(Entities.Page page)
        {
            var pag = await _context.Pages.AnyAsync(a => a.Id == page.Id);
            if (pag)
            {
                _context.Entry(page).State = EntityState.Modified; 

            }
        }
        public async Task<bool> Save()
        {
            return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
        }
    }
}
