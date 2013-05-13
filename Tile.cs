using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessBoard
{
    public class Tile
    {
        public int XLoc { get; private set; }
        public int YLoc { get; private set; }
        public int Height { get; private set; }
        public bool Visited { get;  set; }
        public bool IsEdge { get; set; }

        public Tile(int x, int y, int h, bool edge)
        {
            XLoc = x;
            YLoc = y;
            Height = h;
            Visited = false;
            IsEdge = edge;
        }

        public void Visit()
        {
            Visited = true; 
        }

        public void Fill(int h)
        {
            Height = h; 
        }
    }
}
