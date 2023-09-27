using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud_aspnet.Data;
using crud_aspnet.Models;

namespace crud_aspnet.Pages_SubGroups
{
    public class EditModel : PageModel
    {
        private readonly crud_aspnet.Data.ApplicationDbContext _context;

        public EditModel(crud_aspnet.Data.ApplicationDbContext context)
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

            var subgroup =  await _context.SubGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (subgroup == null)
            {
                return NotFound();
            }
            SubGroup = subgroup;
           ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SubGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubGroupExists(SubGroup.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubGroupExists(int id)
        {
          return (_context.SubGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
