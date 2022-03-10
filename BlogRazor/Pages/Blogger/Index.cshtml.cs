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
    public class IndexModel : PageModel
    {
        private readonly BlogRazor.Models.Data.Context _context;

        public IndexModel(BlogRazor.Models.Data.Context context)
        {
            _context = context;
        }

        public IList<BloggerModel> BloggerModel { get; set; }

        public async Task OnGetAsync()
        {
            BloggerModel = await _context.BloggerModel.ToListAsync();
        }
    }
}
