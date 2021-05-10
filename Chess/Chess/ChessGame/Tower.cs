using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;

namespace Chess.ChessGame
{
    class Tower : Piece
    {
        public Tower(BoarD board, Color color) : base (board, color)
        {

        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }
        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            //top
            pos.defineValue(position.Line - 1, position.Column);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.piece(pos)!= null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            //right
            pos.defineValue(position.Line , position.Column +1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //bottom
            pos.defineValue(position.Line + 1, position.Column);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }


            //left
            pos.defineValue(position.Line , position.Column -1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            return mat;

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
