using System;
using Chess.Board;
using Chess.ChessGame;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BoarD board = new BoarD(8, 8);
                board.movePiece(new Tower(board, Color.Black), new Position(0, 0));
                board.movePiece(new Tower(board, Color.Black), new Position(0, 7));
                board.movePiece(new King(board, Color.Black), new Position(0, 4));




                Screen.printBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
