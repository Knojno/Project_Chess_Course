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

                ChessMatch match = new ChessMatch();
                

                while (!match.Finishe)
                {
                    Console.Clear();
                    
                    Console.WriteLine("The White Pieces is the Green Pieces");
                    Console.WriteLine("The Black Pieces is the Yellow Pieces");
                    Console.WriteLine();

                    Screen.printBoard(match.board);

                    Console.WriteLine();
                    Console.Write("ORIGIN: ");
                    Position origin = Screen.readPositionChess().toPosition();
                    Console.Write("Destine: ");
                    Position destine = Screen.readPositionChess().toPosition();

                    match.executeMoviment(origin, destine);
                }
                
                
                
                
                
                Screen.printBoard(match.board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
