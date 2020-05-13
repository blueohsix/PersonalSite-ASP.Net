using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
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
            var JSON = JsonConvert.SerializeObject(PlaySurface);
            Response.Cookies.Append("PlaySurface", JSON);
        }
        public void OnPostSize(int size)
        {
            PlaySurface = new Board(size);
            var JSON = JsonConvert.SerializeObject(PlaySurface);
            Response.Cookies.Append("PlaySurface", JSON);
        }
        public void OnPostCell(string location)
        {
            JsonConvert.PopulateObject(Request.Cookies["PlaySurface"], PlaySurface = new Board());
            if (ValidateMove(PlaySurface, location))
            {
                var XorO = PlaySurface.XTurn ? "X" : "O";
                var first = (int)Char.GetNumericValue(location[0]);
                var second = (int)Char.GetNumericValue(location[1]);
                PlaySurface.Grid[first, second].Symbol = XorO;
                PlaySurface.XTurn = !PlaySurface.XTurn;
            }
            var JSON = JsonConvert.SerializeObject(PlaySurface);
            Response.Cookies.Append("PlaySurface", JSON);
        }
        public bool ValidateMove(Board PlaySurface, string move)
        {
            int size = (int)Math.Sqrt(PlaySurface.Grid.Length);
            int first, second;
            try
            {
                first = int.Parse(move[0].ToString());
                second = int.Parse(move[1].ToString());
                if ((first >= 0 && first <= size - 1) && (second >= 0 && second <= size - 1))
                {
                    if (PlaySurface.Grid[first, second].Symbol.Equals("_") &&
                        !PlaySurface.Grid[first, second].Symbol.Equals("X") &&
                        !PlaySurface.Grid[first, second].Symbol.Equals("O"))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
