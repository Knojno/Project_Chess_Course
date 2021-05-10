using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;
using Chess.ChessGame;

namespace Chess
{
    class Screen
    {
        public static void printBoard(BoarD board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    Console.Write("[");
                    printPiece(board.piece(i, j));
                    Console.Write("]");
                }
                Console.WriteLine();
            }
                    
            Console.WriteLine("   A  B  C  D  E  F  G  H ");        
        }

        public static void printBoard(BoarD board, bool[,] positionsPossibles)
        {
            ConsoleColor backgroundOriginal = Console.BackgroundColor;
            ConsoleColor backgroundChanged = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (positionsPossibles[i, j])
                    {
                        Console.BackgroundColor = backgroundChanged;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOriginal;
                    }
                    Console.Write("[");
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = backgroundOriginal;
                    Console.Write("]");
                }
                Console.WriteLine();
            }

            Console.WriteLine("   A  B  C  D  E  F  G  H ");
            Console.BackgroundColor = backgroundOriginal;
        }




        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-");
            }
            else
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
                Console.Write("");
            }
        }
    }
}
