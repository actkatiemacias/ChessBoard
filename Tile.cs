using System;

namespace ChessBoard
{
    public class Tile
    {
        //x location on the chessboard
        public int XLoc { get; private set; }
        
        //y location on the chessboard
        public int YLoc { get; private set; }
        
        //height, including water if filled
        public int Height { get; private set; }

        //indicator to check if object has been visited
        public bool Visited { get;  set; }

        //indicator for edgecase tiles
        public bool IsEdge { get; set; }

        /**Constructor for Object Tile
        Assumption: tile has not been visited when created
        Assumption: tile is not an edge unless specified**/
        public Tile(int x, int y, int h, bool edge)
        {
            XLoc = x;
            YLoc = y;
            Height = h;
            Visited = false;
            IsEdge = edge;
        }

        /**Setter for the property Visited **/
        public void Visit()
        {
            Visited = true; 
        }

        /**Setter for the property Height
        Conceptually this fills the tile with water increasing its height**/
        public void Fill(int h)
        {
            Height = h; 
        }
    }
}
