using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalSite_ASP.Data.Blog;

namespace PersonalSite_ASP.Data
{
    public class PersonalSite_ASPContext : IdentityDbContext<ApplicationUser>
    {
        public PersonalSite_ASPContext (DbContextOptions<PersonalSite_ASPContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
    }
}
