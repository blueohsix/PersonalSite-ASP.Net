using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PersonalSite_ASP.Data.XoModels;

namespace PersonalSite_ASP.Pages
{
    public class TicTacToeModel : PageModel
    {
        public Board PlaySurface { get; set; }
        public void OnGet()
        {
            PlaySurface = new Board(3);
            Response.Cookies.Append("BoardState", JsonConvert.SerializeObject(PlaySurface));
        }
        public void OnPostReset()
        {
            PlaySurface = new Board(3);
            Response.Cookies.Append("BoardState", JsonConvert.SerializeObject(PlaySurface));
        }
        public void OnPostCell(string location)
        {
            JsonConvert.PopulateObject(Request.Cookies["BoardState"], PlaySurface = new Board());
            PlaySurface.Move(PlaySurface, location);
            Response.Cookies.Append("BoardState", JsonConvert.SerializeObject(PlaySurface));
        }


    }
}
