using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessBoard
{
    public class Polygon
    {
        public int TileCount { get; private set; }
        public int BaseHeight { get; private set; }
        public int MinAdjacentHeight { get; private set; }
        public int Capacity { get; private set; }
        public bool ContainsEdge { get; set; }
        public bool Spill { get; set; }
        public List<Tile> Tiles;

        public Polygon()
        {
            Tiles = new List<Tile>();
            TileCount = 0;
            BaseHeight = 0;
            MinAdjacentHeight = Int32.MaxValue;
            Capacity = 0;
            ContainsEdge = false;
            Spill = false;
        }

        public void CheckAdjacent(Tile tile)
        {
            if (!Tiles.Contains(tile))
            {
                if (tile.Height <= MinAdjacentHeight)
                {
                    MinAdjacentHeight = tile.Height;
                    if (tile.Height == BaseHeight)
                    {
                        AddTile(tile);
                    }
                }
            }
        }

        public void AddTile(Tile tile)
        {
            
            
                if (BaseHeight == 0)
                {
                    BaseHeight = tile.Height;
                }
                Tiles.Add(tile);
                TileCount = Tiles.Count;
            
        }

        public int GetCapacity()
        {
            if(MinAdjacentHeight < BaseHeight)
            {
                Spill = true;
                return Capacity = 0;
                
            }
            else{
                foreach (Tile tile in Tiles)
                {
                if(tile.IsEdge)
                {
                    ContainsEdge = true;
                    Spill = true;
                    return Capacity = 0;
                    }
                }
            }
            Capacity = TileCount * Math.Max((MinAdjacentHeight - BaseHeight),0);
            return Capacity;
        }


    }
}
