using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalSite_ASP.Data.XoModels
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string [,] Grid { get; set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            InitializeBoardValues();
        }

    public void InitializeBoardValues()
        {
            Grid = new string[Width, Height];
            var count = 1;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Grid[i, j] = count.ToString();
                    count++;
                }
            }
        }
    }
}
