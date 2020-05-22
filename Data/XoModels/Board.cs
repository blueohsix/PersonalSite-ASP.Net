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
        public int Size { get; set; }
        public bool XTurn { get; set; } = true;
        
        public Cell[,] Grid { get; set; }

        public Board()
        {

        }
        public Board(Board board)
        {
            Size = board.Size;
            Grid = board.Grid;
        }
        public Board(int size)
        {
            Size = size;
            InitializeBoardValues(size);
        }

        private void InitializeBoardValues(int size)
        {
            Grid = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Grid[i, j] = new Cell();
                    Grid[i, j].Location = string.Format("{0}{1}", i, j);
                }
            }
        }
        public void Move(Board PlaySurface, string location)
        {
            if (PlaySurface.ValidateMove(PlaySurface, location))
            {
                var XorO = PlaySurface.XTurn ? "X" : "O";
                var first = (int)Char.GetNumericValue(location[0]);
                var second = (int)Char.GetNumericValue(location[1]);
                PlaySurface.Grid[first, second].Symbol = XorO;
                PlaySurface.XTurn = !PlaySurface.XTurn;
            }
        }
        private bool ValidateMove(Board PlaySurface, string move)
        {
            int size = PlaySurface.Size;
            int first, second;
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
    }
}
