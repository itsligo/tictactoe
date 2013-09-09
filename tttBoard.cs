using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace tictactoe
{
    class tttBoard
    {
        public enum boardState {empty, x, o};
        private boardState [,]board;

        public tttBoard(int rank)
        {
            board =  new boardState[rank,rank];

        }   // end constructor


        public boardState this[int i, int j]
        {
            get
            {
                return board[i, j];
            }
            set
            {
                board[i, j] = value;
            }
        }

        public boardState testWin()
        {
            int noX=0, noO=0;
            int rank = board.GetLength(0);

            #region // test rows
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    if (board[i, j] == boardState.x) ++noX;
                    if (board[i, j] == boardState.o) ++noO;
                }   // across a row
                if (noX != rank) noX = 0; else break;
                if (noO != rank) noO = 0; else break;
            }   // down through rows on board
            
            // test if any winners in the rows
            if (noX == rank) return boardState.x;
            if (noO == rank) return boardState.o;
            #endregion

            #region // test columns
            noX = noO = 0;
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    if (board[j, i] == boardState.x) ++noX;
                    if (board[j, i] == boardState.o) ++noO;
                }   // across a cols
                if (noX != rank) noX = 0; else break;
                if (noO != rank) noO = 0; else break;
            }   // down through cols on board

            // test if any winners in the cols
            if (noX == rank) return boardState.x;
            if (noO == rank) return boardState.o;
            #endregion

            #region // test diagonal top left to bottom right
            noX = noO = 0;
            for (int i = 0; i < rank; i++)
            {
                if (board[i, i] == boardState.x) ++noX;
                if (board[i, i] == boardState.o) ++noO;
            }

            // test if any winners in this diagonal
            if (noX == rank) return boardState.x;
            if (noO == rank) return boardState.o;
            #endregion

            #region //Test diagonal bottom left to top right
            noX = noO = 0;
            for (int i = rank-1; i > 0; i--)
            {
                if (board[i, i] == boardState.x) ++noX;
                if (board[i, i] == boardState.o) ++noO;
            }

            // test if any winners in this diagonal
            if (noX == rank) return boardState.x;
            if (noO == rank) return boardState.o;
            #endregion

            return boardState.empty;
        }   // end testWin()
    }   // end class tttBoard
}   // end namespace
