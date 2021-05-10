using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;

namespace Chess.ChessGame
{
    class King : Piece
    {
        public King(BoarD board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "R";
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
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //top right
            pos.defineValue(position.Line - 1, position.Column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //right
            pos.defineValue(position.Line, position.Column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //bottom right
            pos.defineValue(position.Line + 1, position.Column + 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //bottom
            pos.defineValue(position.Line + 1, position.Column);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //top left
            pos.defineValue(position.Line - 1, position.Column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //left
            pos.defineValue(position.Line, position.Column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //bottom left
            pos.defineValue(position.Line + 1, position.Column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;

        }
    }
}
