using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessBoard
{
    public class Chessboard
    {
        public Tile[,] Board;
        public int Capacity { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool Spill { get; private set; }
        public bool AllVisited { get; private set; }
        
        public Chessboard(int h, int w)
        {
            Height = h;
            Width = w;
            Capacity = 0;
            Board = new Tile[Height, Width];
            Spill = false;
            AllVisited = false;
        }

        public void UpdateBoard(Polygon polygon)
        {
            foreach (Tile tile in polygon.Tiles)
            {
                if (polygon.Capacity > 0)
                {
                    Board[tile.XLoc, tile.YLoc].Fill(polygon.MinAdjacentHeight);
                }
                Board[tile.XLoc, tile.YLoc].Visit();
            }
        }

        public int GetCapacity()
        {
            if (Height > 2 && Width > 2)
            {
                while (Spill == false || AllVisited == false)
                {
                    ClearBoard();
                    for (int i = 1; i < Height - 1; i++)
                    {
                        for (int j = 1; j < Width - 1; j++)
                        {
                            if (!Board[i, j].Visited)
                            {
                                Polygon basePolygon = new Polygon();
                                basePolygon.AddTile(Board[i, j]);
                                Polygon resultPolygon = FindPolygon(basePolygon, Board[i, j]);
                                Capacity += resultPolygon.GetCapacity();
                                Spill = resultPolygon.Spill;
                                UpdateBoard(resultPolygon);
                            }
                        }
                    }
                    AllVisited = true;
                }
            }
            else
            {
                Capacity = 0;
            }
            return Capacity;
        }

        public void ClearBoard()
        {
            for (int i = 1; i < Height - 1; i++)
            {
                for (int j = 1; j < Width - 1; j++)
                {
                    Board[i, j].Visited = false;
                }
            }
            AllVisited = false;
        }

        private Polygon FindPolygon(Polygon polygon, Tile tile)
        {

            if (tile.IsEdge)
            {
                return polygon;
            }
            else
            {
                //Bottom
                if (Board[tile.XLoc + 1, tile.YLoc].Height == tile.Height && 
                    !polygon.Tiles.Contains(Board[tile.XLoc + 1, tile.YLoc]))
                {
                    polygon.AddTile(Board[tile.XLoc + 1, tile.YLoc]);
                    FindPolygon(polygon, Board[tile.XLoc + 1, tile.YLoc]);
                }
                else
                {
                    polygon.CheckAdjacent(Board[tile.XLoc + 1, tile.YLoc]);
                }
               
                //Top
                if (Board[tile.XLoc - 1, tile.YLoc].Height == tile.Height &&
                    !polygon.Tiles.Contains(Board[tile.XLoc - 1, tile.YLoc]))
                {
                    polygon.AddTile(Board[tile.XLoc - 1, tile.YLoc]);
                    FindPolygon(polygon, Board[tile.XLoc - 1, tile.YLoc]);
                }
                else
                {
                    polygon.CheckAdjacent(Board[tile.XLoc - 1, tile.YLoc]);
                }
                //Left
                if (Board[tile.XLoc, tile.YLoc - 1].Height == tile.Height &&
                    !polygon.Tiles.Contains(Board[tile.XLoc, tile.YLoc - 1]))
                {
                    polygon.AddTile(Board[tile.XLoc, tile.YLoc - 1]);
                    FindPolygon(polygon, Board[tile.XLoc, tile.YLoc - 1]);
                }
                else
                {
                    polygon.CheckAdjacent(Board[tile.XLoc, tile.YLoc - 1]);
                }
                //Right
                if (Board[tile.XLoc, tile.YLoc + 1].Height == tile.Height &&
                    !polygon.Tiles.Contains(Board[tile.XLoc, tile.YLoc + 1]))
                {
                    polygon.AddTile(Board[tile.XLoc, tile.YLoc + 1]);
                    FindPolygon(polygon, Board[tile.XLoc, tile.YLoc + 1]);
                }
                else
                {
                    polygon.CheckAdjacent(Board[tile.XLoc, tile.YLoc + 1]);
                }
                return polygon;
            }
                        
        }
    }
}
