using System;
using Chess.Board;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            BoarD board = new BoarD(8, 8);
            Screen.printBoard(board);

        }
    }
}
