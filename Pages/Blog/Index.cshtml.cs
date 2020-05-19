using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalSite_ASP.Data;
using PersonalSite_ASP.Data.Blog;

namespace PersonalSite_ASP.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly PersonalSite_ASP.Data.PersonalSite_ASPContext _context;

        public IndexModel(PersonalSite_ASP.Data.PersonalSite_ASPContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Post.ToListAsync();
        }
    }
}
