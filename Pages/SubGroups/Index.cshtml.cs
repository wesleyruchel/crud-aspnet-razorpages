using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud_aspnet.Data;
using crud_aspnet.Models;

namespace crud_aspnet.Pages_SubGroups
{
    public class IndexModel : PageModel
    {
        private readonly crud_aspnet.Data.ApplicationDbContext _context;

        public IndexModel(crud_aspnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SubGroup> SubGroup { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SubGroups != null)
            {
                SubGroup = await _context.SubGroups
                .Include(s => s.Group).ToListAsync();
            }
        }
    }
}
