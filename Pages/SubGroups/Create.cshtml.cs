using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crud_aspnet.Data;
using crud_aspnet.Models;

namespace crud_aspnet.Pages_SubGroups
{
    public class CreateModel : PageModel
    {
        private readonly crud_aspnet.Data.ApplicationDbContext _context;

        public CreateModel(crud_aspnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SubGroup SubGroup { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SubGroups == null || SubGroup == null)
            {
                return Page();
            }

            _context.SubGroups.Add(SubGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
