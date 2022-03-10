#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogRazor.Models;
using BlogRazor.Models.Data;

namespace BlogRazor.Pages.Blogger
{
    public class CreateModel : PageModel
    {
        private readonly BlogRazor.Models.Data.Context _context;

        public CreateModel(BlogRazor.Models.Data.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BloggerModel BloggerModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BloggerModel.Add(BloggerModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
