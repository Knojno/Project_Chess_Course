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
                board.movePiece(new Tower(board, Color.White), new Position(7, 0));
                board.movePiece(new King(board, Color.White), new Position(7, 4));
                board.movePiece(new Tower(board, Color.White), new Position(7, 7));
                
                
                
                Console.WriteLine("The White Pieces is the Green Pieces");
                Console.WriteLine("The Black Pieces is the Yellow Pieces");
                Screen.printBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
