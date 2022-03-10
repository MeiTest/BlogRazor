#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogRazor.Models;

namespace BlogRazor.Models.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<BlogRazor.Models.BloggerModel> BloggerModel { get; set; }
    }
}
