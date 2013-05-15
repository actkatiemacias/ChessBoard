using System;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("File path: ");
            String path = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(path);

            var dimensions = lines[0].Split(',');
            Chessboard chessBoard = new Chessboard(Int32.Parse(dimensions[0]), Int32.Parse(dimensions[1]));
            for (int i = 0; i < chessBoard.Height; i++)
            {
                var row = lines[i + 1].Split(',');
                for (int j = 0; j < chessBoard.Width; j++)
                {
                    if (i == chessBoard.Height - 1 || j == chessBoard.Width - 1 || i == 0 || j == 0)
                    {
                        chessBoard.Board[i, j] = new Tile(i, j, Int32.Parse(row[j]), true);
                    }
                    else
                    {
                        chessBoard.Board[i, j] = new Tile(i, j, Int32.Parse(row[j]), false);
                    }
                }
            }
            Console.WriteLine(chessBoard.GetCapacity());
            Console.ReadLine();
        }
    }
}
