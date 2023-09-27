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
    public class DeleteModel : PageModel
    {
        private readonly crud_aspnet.Data.ApplicationDbContext _context;

        public DeleteModel(crud_aspnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SubGroups == null)
            {
                return NotFound();
            }
            var subgroup = await _context.SubGroups.FindAsync(id);

            if (subgroup != null)
            {
                SubGroup = subgroup;
                _context.SubGroups.Remove(SubGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
