using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;

namespace Chess
{
    class Screen
    {
        public static void printBoard(BoarD board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8-i+" ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("["+"-"+"]" );
                    }
                    else
                    {
                        Console.Write("[");
                        printPiece(board.piece(i, j));
                        Console.Write("]");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("   A  B  C  D  E  F  G  H ");
        }

        public static void printPiece(Piece piece)
        {
            if (piece.color == Color.White)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
