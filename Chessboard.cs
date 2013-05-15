using System;


namespace ChessBoard
{
    public class Chessboard
    {
        //Multidemensional array of Tile objects
        //Used datastructure that best represents real life chessboard
        public Tile[,] Board;

        //The total amount of water the ChessBoard can hold
        public int Capacity { get; private set; }

        //The height of the chessboard
        //Corresponds to the x dimension on a tile
        public int Height { get; private set; }

        //The width of the chessboard
        //Corresponds to the y dimension on a tile
        public int Width { get; private set; }

        
        /**Chessboard constructor
         * Assumption: Initially the chessboard does not spill water 
         * Assumption: Initially no tiles have been visited
        **/
        public Chessboard(int h, int w)
        {
            Height = h;
            Width = w;
            Capacity = 0;
            Board = new Tile[Height, Width];
        }

        /**
         * Updates the tiles in the polygon with their new hieght after being filled
         * Marks all tiles in polygon that were visited.
         **/
        public void UpdateBoard(Polygon polygon, Tile currentTile)
        {
            foreach (Tile tile in polygon.Tiles)
            {
                //Do not change the height of a tile if no water is held
                if (polygon.Capacity > 0)
                {
                    Board[tile.XLoc, tile.YLoc].Fill(polygon.MinAdjacentHeight);
                }
            }
            currentTile.Visit();
        }

        /**
         * Calculates the capacity of the chessboard by finding a polygon (adjacent squares of the same height)
         * Calculates the capacity of the polygon and adds that to the ChessBoard's capacity
         * After visiting every (non edge) tile determines if another pass is needed
         * Stops pasisng when all nodes have been visited and water spills from board
         **/ 
        public int GetCapacity()
        {
            //A board must have at least dimensions of 3x3 to hold water
            if (Height > 2 && Width > 2)
            {
                
                    //Each pass starts with all Tiles unvisited

                    //Iterate through each tile in the board
                    for (int i = 1; i < Height - 1; i++)
                    {
                        for (int j = 1; j < Width - 1; j++)
                        {
                            //Check if visited, if member of a polygon then it has been marked as visited and will be skipped
                            if (!Board[i, j].Visited)
                            {
                                Polygon basePolygon = new Polygon();
                                basePolygon.AddTile(Board[i, j]);
                                Polygon resultPolygon = FindPolygon(basePolygon, Board[i, j]);
                                Capacity += resultPolygon.GetCapacity();
                                UpdateBoard(resultPolygon, Board[i,j]);
                            }
                        }
                    } 
                }
            else
            {
                Capacity = 0;
            }
            return Capacity;
        }


        /**Finds all tiles that are adjacent to one another with the same height
         * Uses a recursive depth first search to find the largest polygon possible each pass
         * Worst case scenario is a flat board (every tile same height), which would return the entire board as a polygon
         **/
        private Polygon FindPolygon(Polygon polygon, Tile tile)
        {
            //Don't search the adjacent tiles when it is an edge - water will spill out
            if (tile.IsEdge)
            {
                return polygon;
            }
            else
            {
                //Adjacent Bottom tile
                //For the current tile search the adjacent Bottom tile
                //If same height and not already in the polygon, add to polygon and search the Bottom tiles adjacent tiles
                if (Board[tile.XLoc + 1, tile.YLoc].Height == tile.Height && 
                    !polygon.Tiles.Contains(Board[tile.XLoc + 1, tile.YLoc]))
                {
                    polygon.AddTile(Board[tile.XLoc + 1, tile.YLoc]);
                    FindPolygon(polygon, Board[tile.XLoc + 1, tile.YLoc]);
                }
                else
                {
                    //if not the same height as the polygon, evaluate if it is the smallest neighboring tile
                    polygon.CheckAdjacent(Board[tile.XLoc + 1, tile.YLoc]);
                }
               
                //Adjacent Top tile
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
                //Adjacent Left tile
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
                //Adjacent Right tile
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
