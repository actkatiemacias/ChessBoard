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

        /**
         * A polygon is a group of n tiles that are adjacent to one another
         **/
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

        /**
         ** Need to determine if the given adjacent tile is the smallest adjacent tile for capacity calculation
         * 
         */
        public void CheckAdjacent(Tile tile)
        {
            //Dont want to check tiles in the polygon
            if (!Tiles.Contains(tile))
            {
                if (tile.Height <= MinAdjacentHeight)
                {
                    //Set the new smallest adjacent height
                    MinAdjacentHeight = tile.Height;
                    if (tile.Height == BaseHeight)
                    {
                        AddTile(tile);
                    }
                }
            }
        }

        /**
         * Method that updates important class properties when Tile list is changed
         * Ensures all properties reflect the Tile list
        **/
        public void AddTile(Tile tile)
        {
            //Default condition, changes when first tile is added
            if (BaseHeight == 0)
            {
                BaseHeight = tile.Height;
            }
            Tiles.Add(tile);
            TileCount = Tiles.Count;

        }

        /**
         ** Calculates the capacity a polygon holds based on surrounding Tiles
         */
        public int GetCapacity()
        {
            //If the polygon is taller than some adjacent Tile
            if (MinAdjacentHeight < BaseHeight)
            {
                Spill = true;
                return Capacity = 0;
            }

            //If polygon touches an edge it will spill
            foreach (Tile tile in Tiles)
            {
                if (tile.IsEdge)
                {
                    ContainsEdge = true;
                    Spill = true;
                    return Capacity = 0;
                }
            }

            //If reach this point the polygon does not spill water and can calc its capacity
            //When a polygon is filled to a height of the adjacent tile with minimum height it will begin to spill over to adjacent tile
            //Therefore capacity is only to the adjacent tile with minimum height
            //Polygont tiles height will be adjusted with the filled water and a new pass begins
            Capacity = TileCount * Math.Max((MinAdjacentHeight - BaseHeight), 0);
            return Capacity;
        }


    }
}
