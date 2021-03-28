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
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write( " - " );
                    }
                    else
                    {
                        Console.Write(board.piece(i,j)+"");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
