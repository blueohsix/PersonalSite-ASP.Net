using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalSite_ASP.Data.XoModels;

namespace PersonalSite_ASP.Pages
{
    public class TicTacToeModel : PageModel
    {

        public Board PlaySurface { get; set; }
        public void OnGet()
        {
            PlaySurface = new Board(0, 0);
        }

        public void OnPostSize(int size)
        {
            Console.WriteLine(size);
            PlaySurface = new Board(size, size);
        }
    }
}
