using System;
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

         [TestMethod]
         public void SmileyFace()
         {
             Chessboard testBoard = new Chessboard(5, 10);

             //row 1
             Tile tile00 = new Tile(0, 0, 8, true);
             Tile tile01 = new Tile(0, 1, 8, true);
             Tile tile02 = new Tile(0, 2, 8, true);
             Tile tile03 = new Tile(0, 3, 8, true);
             Tile tile04 = new Tile(0, 4, 8, true);
             Tile tile05 = new Tile(0, 5, 8, true);
             Tile tile06 = new Tile(0, 6, 8, true);
             Tile tile07 = new Tile(0, 7, 8, true);
             Tile tile08 = new Tile(0, 8, 8, true);
             Tile tile09 = new Tile(0, 9, 8, true);
             testBoard.Board[0,0] = tile00;
             testBoard.Board[0, 1] = tile01;
             testBoard.Board[0, 2] = tile02;
             testBoard.Board[0, 3] = tile03;
             testBoard.Board[0, 4] = tile04;
             testBoard.Board[0, 5] = tile05;
             testBoard.Board[0, 6] = tile06;
             testBoard.Board[0, 7] = tile07;
             testBoard.Board[0, 8] = tile08;
             testBoard.Board[0, 9] = tile09;

             //row 2
             Tile tile10 = new Tile(1, 0, 8, true);
             Tile tile11 = new Tile(1, 1, 2, false);
             Tile tile12 = new Tile(1, 2, 2, false);
             Tile tile13 = new Tile(1, 3, 2, false);
             Tile tile14 = new Tile(1, 4, 8, false);
             Tile tile15 = new Tile(1, 5, 8, false);
             Tile tile16 = new Tile(1, 6, 2, false);
             Tile tile17 = new Tile(1, 7, 2, false);
             Tile tile18 = new Tile(1, 8, 2, false);
             Tile tile19 = new Tile(1, 9, 8, true);
             testBoard.Board[1, 0] = tile10;
             testBoard.Board[1, 1] = tile11;
             testBoard.Board[1, 2] = tile12;
             testBoard.Board[1, 3] = tile13;
             testBoard.Board[1, 4] = tile14;
             testBoard.Board[1, 5] = tile15;
             testBoard.Board[1, 6] = tile16;
             testBoard.Board[1, 7] = tile17;
             testBoard.Board[1, 8] = tile18;
             testBoard.Board[1, 9] = tile19;

             //row 3
             Tile tile20 = new Tile(2, 0, 8, true);
             Tile tile21 = new Tile(2, 1, 2, false);
             Tile tile22 = new Tile(2, 2, 1, false);
             Tile tile23 = new Tile(2, 3, 2, false);
             Tile tile24 = new Tile(2, 4, 8, false);
             Tile tile25 = new Tile(2, 5, 8, false);
             Tile tile26 = new Tile(2, 6, 2, false);
             Tile tile27 = new Tile(2, 7, 1, false);
             Tile tile28 = new Tile(2, 8, 2, false);
             Tile tile29 = new Tile(2, 9, 8, true);
             testBoard.Board[2, 0] = tile20;
             testBoard.Board[2, 1] = tile21;
             testBoard.Board[2, 2] = tile22;
             testBoard.Board[2, 3] = tile23;
             testBoard.Board[2, 4] = tile24;
             testBoard.Board[2, 5] = tile25;
             testBoard.Board[2, 6] = tile26;
             testBoard.Board[2, 7] = tile27;
             testBoard.Board[2, 8] = tile28;
             testBoard.Board[2, 9] = tile29;

             //row 4
             Tile tile30 = new Tile(3, 0, 8, true);
             Tile tile31 = new Tile(3, 1, 2, false);
             Tile tile32 = new Tile(3, 2, 2, false);
             Tile tile33 = new Tile(3, 3, 2, false);
             Tile tile34 = new Tile(3, 4, 8, false);
             Tile tile35 = new Tile(3, 5, 8, false);
             Tile tile36 = new Tile(3, 6, 2, false);
             Tile tile37 = new Tile(3, 7, 2, false);
             Tile tile38 = new Tile(3, 8, 2, false);
             Tile tile39 = new Tile(3, 9, 8, true);
             testBoard.Board[3, 0] = tile30;
             testBoard.Board[3, 1] = tile31;
             testBoard.Board[3, 2] = tile32;
             testBoard.Board[3, 3] = tile33;
             testBoard.Board[3, 4] = tile34;
             testBoard.Board[3, 5] = tile35;
             testBoard.Board[3, 6] = tile36;
             testBoard.Board[3, 7] = tile37;
             testBoard.Board[3, 8] = tile38;
             testBoard.Board[3, 9] = tile39;

             //row 5
             Tile tile40 = new Tile(4, 0, 8, true);
             Tile tile41 = new Tile(4, 1, 8, true);
             Tile tile42 = new Tile(4, 2, 8, true);
             Tile tile43 = new Tile(4, 3, 8, true);
             Tile tile44 = new Tile(4, 4, 8, true);
             Tile tile45 = new Tile(4, 5, 8, true);
             Tile tile46 = new Tile(4, 6, 8, true);
             Tile tile47 = new Tile(4, 7, 8, true);
             Tile tile48 = new Tile(4, 8, 8, true);
             Tile tile49 = new Tile(4, 9, 8, true);
             testBoard.Board[4, 0] = tile40;
             testBoard.Board[4, 1] = tile41;
             testBoard.Board[4, 2] = tile42;
             testBoard.Board[4, 3] = tile43;
             testBoard.Board[4, 4] = tile44;
             testBoard.Board[4, 5] = tile45;
             testBoard.Board[4, 6] = tile46;
             testBoard.Board[4, 7] = tile47;
             testBoard.Board[4, 8] = tile48;
             testBoard.Board[4, 9] = tile49;

             Assert.AreEqual(110, testBoard.GetCapacity());
         }
    }
}
