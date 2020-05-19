using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalSite_ASP.Data;
using PersonalSite_ASP.Data.Blog;

namespace PersonalSite_ASP.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly PersonalSite_ASP.Data.PersonalSite_ASPContext _context;

        public CreateModel(PersonalSite_ASP.Data.PersonalSite_ASPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Post.TimePosted = DateTime.Now;
            _context.Post.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
