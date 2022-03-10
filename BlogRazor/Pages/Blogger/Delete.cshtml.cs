#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogRazor.Models;
using BlogRazor.Models.Data;

namespace BlogRazor.Pages.Blogger
{
    public class DeleteModel : PageModel
    {
        private readonly BlogRazor.Models.Data.Context _context;

        public DeleteModel(BlogRazor.Models.Data.Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BloggerModel = await _context.BloggerModel.FindAsync(id);

            if (BloggerModel != null)
            {
                _context.BloggerModel.Remove(BloggerModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
