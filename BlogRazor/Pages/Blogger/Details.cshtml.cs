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
    public class DetailsModel : PageModel
    {
        private readonly BlogRazor.Models.Data.Context _context;

        public DetailsModel(BlogRazor.Models.Data.Context context)
        {
            _context = context;
        }

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
    }
}
