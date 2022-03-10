#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogRazor.Models;
using BlogRazor.Models.Data;

namespace BlogRazor.Pages.Blogger
{
    public class EditModel : PageModel
    {
        private readonly BlogRazor.Models.Data.Context _context;

        public EditModel(BlogRazor.Models.Data.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public BloggerModel BloggerModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BloggerModel = await _context.BloggerModel.FirstOrDefaultAsync(m => m.ID == id);

            if (BloggerModel == null)
            {
                return NotFound();
            }
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

            _context.Attach(BloggerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloggerModelExists(BloggerModel.ID))
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

        private bool BloggerModelExists(int id)
        {
            return _context.BloggerModel.Any(e => e.ID == id);
        }
    }
}
