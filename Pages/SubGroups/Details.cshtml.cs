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
    public class DetailsModel : PageModel
    {
        private readonly crud_aspnet.Data.ApplicationDbContext _context;

        public DetailsModel(crud_aspnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public SubGroup SubGroup { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SubGroups == null)
            {
                return NotFound();
            }

            var subgroup = await _context.SubGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (subgroup == null)
            {
                return NotFound();
            }
            else 
            {
                SubGroup = subgroup;
            }
            return Page();
        }
    }
}
