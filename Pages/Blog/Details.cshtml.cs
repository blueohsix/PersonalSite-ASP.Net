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
    public class DetailsModel : PageModel
    {
        private readonly PersonalSite_ASP.Data.PersonalSite_ASPContext _context;

        public DetailsModel(PersonalSite_ASP.Data.PersonalSite_ASPContext context)
        {
            _context = context;
        }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Post.FirstOrDefaultAsync(m => m.Id == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
