using System;

namespace PersonalSite_ASP.Data.XoModels
{
    public class Cell
    {
        public string Symbol { get; set; } = "_";
        public string Location { get; set; }

    }

    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool XTurn { get; set; } = true;
        public Cell [,] Grid { get; set; }

        public Board()
        {

        }
        public Board(Board board)
        {
            Width = board.Width;
            Height = board.Height;
            Grid = board.Grid;
        }
        public Board(int size)
        {
            Width = size;
            Height = size;
            InitializeBoardValues(size);
        }

    public void InitializeBoardValues(int size)
        {
            Grid = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Grid[i, j] = new Cell();
                    Grid[i, j].Location = String.Format("{0}{1}", i, j);
                }
            }
        }
    }
}
