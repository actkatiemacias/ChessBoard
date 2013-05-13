using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessBoard;

namespace ChessBoardTests
{
    [TestClass]
    public class ChessBoardTests
    {
        [TestMethod]
        public void InitializeTileDefaultVisit()
        {
            Tile testTile = new Tile(1,1,5, false) ;
            Assert.AreEqual(false, testTile.Visited);
        }

        [TestMethod]
        public void InitializeTileHeight()
        {
            Tile testTile = new Tile(1, 1, 5,false);
            Assert.AreEqual(5, testTile.Height);
        }

        [TestMethod]
        public void InitializeTilexloc()
        {
            Tile testTile = new Tile(1, 1, 5, false);
            Assert.AreEqual(1, testTile.XLoc);
        }

        [TestMethod]
        public void InitializeTileyloc()
        {
            Tile testTile = new Tile(1, 1, 5, false);
            Assert.AreEqual(1, testTile.YLoc);
        }

        [TestMethod]
        public void VisitTile()
        {
            Tile testTile = new Tile(1, 1, 5, false);
            testTile.Visit();
            Assert.AreEqual(true, testTile.Visited);
        }
        [TestMethod]
        public void FillTile()
        {
            Tile testTile = new Tile(1, 1, 5, false);
            testTile.Fill(7);
            Assert.AreEqual(7, testTile.Height);
        }

        [TestMethod]
        public void InitializePolygonDefaultBaseHeight()
        {
            Polygon testPolygon = new Polygon();
            Assert.AreEqual(0, testPolygon.BaseHeight);
        }

        [TestMethod]
        public void IntializePolygonDefaultCapacity()
        {
            Polygon testPolygon = new Polygon();
            Assert.AreEqual(0, testPolygon.Capacity);
        }

        [TestMethod]
        public void IntializePolygonDefaultMinAdjacentHeight()
        {
            Polygon testPolygon = new Polygon();
            Assert.AreEqual(Int32.MaxValue, testPolygon.MinAdjacentHeight);
        }

        [TestMethod]
        public void IntializePolygonDefaultTileCount()
        {
            Polygon testPolygon = new Polygon();
            Assert.AreEqual(0, testPolygon.TileCount);
        }
        [TestMethod]
        public void IntializePolygonDefaultTileList()
        {
            Polygon testPolygon = new Polygon();
            Assert.AreEqual(0, testPolygon.Tiles.Count);
        }

        [TestMethod]
        public void IntializeChessboardDefaultCapacity()
        {
            Chessboard testBoard = new Chessboard(3, 3);
            Assert.AreEqual(0,testBoard.Capacity);
        }
        [TestMethod]
        public void IntializeChessboardBoardHeight()
        {
            Chessboard testBoard = new Chessboard(3, 3);
            Assert.AreEqual(3,testBoard.Height);
        }

         [TestMethod]
         public void IntializeChessboardBoardWidth()
         {
             Chessboard testBoard = new Chessboard(3, 3);
             Assert.AreEqual(3,testBoard.Width);
         }

         [TestMethod]
         public void IntializeChessboardMatrixCheck()
         {
             Chessboard testBoard = new Chessboard(3, 3);
             Assert.AreEqual(3*3,testBoard.Board.Length);
         }

         [TestMethod]
         public void UnitChessboard()
         {
             Chessboard testBoard = new Chessboard(1, 1);
             Tile unitTile = new Tile(0, 0, 5,true);
             testBoard.Board[0, 0] = unitTile;
             Assert.AreEqual(0, testBoard.GetCapacity());
         }

         [TestMethod]
         public void TwobyTwoChessboard()
         {
             Chessboard testBoard = new Chessboard(2, 2);
             for (int i = 0; i < 2; i++)
             {
                 for (int j = 0; j < 2; j++)
                 {
                     if (i == 0 || i == 2 || j == 0 || j == 2)
                     {
                         Tile unitTile = new Tile(i, j, 5, true);
                         testBoard.Board[i, j] = unitTile;
                     }
                     else
                     {
                         Tile unitTile = new Tile(i, j, 5, false);
                         testBoard.Board[i, j] = unitTile;
                     }
                 }
             }
             Assert.AreEqual(0, testBoard.GetCapacity());
         }
         [TestMethod]
         public void TwobyThreeChessboard()
         {
             Chessboard testBoard = new Chessboard(2, 3);
             for (int i = 0; i < 2; i++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                     if (i == 0 || i == 2 || j == 0 || j == 3)
                     {
                         Tile unitTile = new Tile(i, j, 5, true);
                         testBoard.Board[i, j] = unitTile;
                     }
                     else
                     {
                         Tile unitTile = new Tile(i, j, 5, false);
                         testBoard.Board[i, j] = unitTile;
                     }
                 }
             }
             Assert.AreEqual(0, testBoard.GetCapacity());
         }

         [TestMethod]
         public void FlatThreebyThreeChessboard()
         {
             Chessboard testBoard = new Chessboard(3, 3);
             for (int i = 0; i < 3; i++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                     if (i == 0 || i == 2 || j == 0 || j == 2)
                     {
                         Tile unitTile = new Tile(i, j, 5, true);
                         testBoard.Board[i, j] = unitTile;
                     }
                     else
                     {
                         Tile unitTile = new Tile(i, j, 5, false);
                         testBoard.Board[i, j] = unitTile;
                     }
                 }
             }
             Assert.AreEqual(0, testBoard.GetCapacity());
         }

         [TestMethod]
         public void ShallowThreebyThreeChessboard()
         {
             Chessboard testBoard = new Chessboard(3, 3);
             for (int i = 0; i < 3; i++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                     if (i == 0 || i == 2 || j == 0 || j == 2)
                     {
                         Tile unitTile = new Tile(i, j, 5, true);
                         testBoard.Board[i, j] = unitTile;
                     }
                     else
                     {
                         Tile unitTile = new Tile(i, j, 2, false);
                         testBoard.Board[i, j] = unitTile;
                     }
                 }
             }
             Assert.AreEqual(3, testBoard.GetCapacity());
         }

         [TestMethod]
         public void PyramidThreebyThreeChessboard()
         {
             Chessboard testBoard = new Chessboard(3, 3);
             for (int i = 0; i < 3; i++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                     if (i == 0 || i == 2 || j == 0 || j == 2)
                     {
                         Tile unitTile = new Tile(i, j, 5, true);
                         testBoard.Board[i, j] = unitTile;
                     }
                     else
                     {
                         Tile unitTile = new Tile(i, j, 7, false);
                         testBoard.Board[i, j] = unitTile;
                     }
                 }
             }
             Assert.AreEqual(0, testBoard.GetCapacity());
         }
         [TestMethod]
         public void TwoPassesChessboard()
         {
             Chessboard testBoard = new Chessboard(4, 5);
             
             Tile tile00 = new Tile(0,0,4,true);
             Tile tile01 = new Tile(0, 1, 1, true);
             Tile tile02 = new Tile(0, 2, 3, true);
             Tile tile03 = new Tile(0, 3, 5, true);
             Tile tile04 = new Tile(0, 4, 1, true);
             testBoard.Board[0, 0] = tile00;
             testBoard.Board[0, 1] = tile01;
             testBoard.Board[0, 2] = tile02;
             testBoard.Board[0, 3] = tile03;
             testBoard.Board[0, 4] = tile04;


             Tile tile10 = new Tile(1, 0, 3, true);
             Tile tile11 = new Tile(1, 1, 3, false);
             Tile tile12 = new Tile(1, 2, 1, false);
             Tile tile13 = new Tile(1, 3, 2, false);
             Tile tile14 = new Tile(1, 4, 3, true);
             testBoard.Board[1, 0] = tile10;
             testBoard.Board[1, 1] = tile11;
             testBoard.Board[1, 2] = tile12;
             testBoard.Board[1, 3] = tile13;
             testBoard.Board[1, 4] = tile14;

             Tile tile20 = new Tile(2, 0, 3, true);
             Tile tile21 = new Tile(2, 1, 1, false);
             Tile tile22 = new Tile(2, 2, 1, false);
             Tile tile23 = new Tile(2, 3, 2, false);
             Tile tile24 = new Tile(2, 4, 4, true);
             testBoard.Board[2, 0] = tile20;
             testBoard.Board[2, 1] = tile21;
             testBoard.Board[2, 2] = tile22;
             testBoard.Board[2, 3] = tile23;
             testBoard.Board[2, 4] = tile24;

             Tile tile30 = new Tile(1, 0, 2, true);
             Tile tile31 = new Tile(1, 1, 3, true);
             Tile tile32 = new Tile(1, 2, 3, true);
             Tile tile33 = new Tile(1, 3, 4, true);
             Tile tile34 = new Tile(1, 4, 2, true);
             testBoard.Board[3, 0] = tile30;
             testBoard.Board[3, 1] = tile31;
             testBoard.Board[3, 2] = tile32;
             testBoard.Board[3, 3] = tile33;
             testBoard.Board[3, 4] = tile34;

             Assert.AreEqual(8, testBoard.GetCapacity());
         }

         [TestMethod]
         public void BackTwoPassesChessboard()
         {
             Chessboard testBoard = new Chessboard(4, 5);

             Tile tile00 = new Tile(0, 0, 4, true);
             Tile tile01 = new Tile(0, 1, 4, true);
             Tile tile02 = new Tile(0, 2, 3, true);
             Tile tile03 = new Tile(0, 3, 5, true);
             Tile tile04 = new Tile(0, 4, 1, true);
             testBoard.Board[0, 0] = tile00;
             testBoard.Board[0, 1] = tile01;
             testBoard.Board[0, 2] = tile02;
             testBoard.Board[0, 3] = tile03;
             testBoard.Board[0, 4] = tile04;


             Tile tile10 = new Tile(1, 0, 3, true);
             Tile tile11 = new Tile(1, 1, 2, false);
             Tile tile12 = new Tile(1, 2, 1, false);
             Tile tile13 = new Tile(1, 3, 3, false);
             Tile tile14 = new Tile(1, 4, 3, true);
             testBoard.Board[1, 0] = tile10;
             testBoard.Board[1, 1] = tile11;
             testBoard.Board[1, 2] = tile12;
             testBoard.Board[1, 3] = tile13;
             testBoard.Board[1, 4] = tile14;

             Tile tile20 = new Tile(2, 0, 3, true);
             Tile tile21 = new Tile(2, 1, 1, false);
             Tile tile22 = new Tile(2, 2, 1, false);
             Tile tile23 = new Tile(2, 3, 3, false);
             Tile tile24 = new Tile(2, 4, 4, true);
             testBoard.Board[2, 0] = tile20;
             testBoard.Board[2, 1] = tile21;
             testBoard.Board[2, 2] = tile22;
             testBoard.Board[2, 3] = tile23;
             testBoard.Board[2, 4] = tile24;

             Tile tile30 = new Tile(1, 0, 2, true);
             Tile tile31 = new Tile(1, 1, 3, true);
             Tile tile32 = new Tile(1, 2, 3, true);
             Tile tile33 = new Tile(1, 3, 4, true);
             Tile tile34 = new Tile(1, 4, 2, true);
             testBoard.Board[3, 0] = tile30;
             testBoard.Board[3, 1] = tile31;
             testBoard.Board[3, 2] = tile32;
             testBoard.Board[3, 3] = tile33;
             testBoard.Board[3, 4] = tile34;

             Assert.AreEqual(7, testBoard.GetCapacity());
         }
    }
}
