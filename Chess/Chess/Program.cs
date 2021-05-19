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
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);











                        Console.WriteLine();
                        Console.Write("ORIGIN: ");
                        Position origin = Screen.readPositionChess().toPosition();
                        match.validPositionOrigin(origin);
                        bool[,] positionsPossibles = match.board.piece(origin).possibleMoviments();

                        Console.Clear();
                        Screen.printBoard(match.board, positionsPossibles);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readPositionChess().toPosition();
                        match.validPositionDestiny(origin, destiny);

                        match.makeMove(origin, destiny);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
