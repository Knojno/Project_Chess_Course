using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;

namespace Chess.ChessGame
{
    class Horse : Piece 
    {
        public Horse(BoarD tab, Color cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "H";
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

            pos.defineValue(position.Line - 1, position.Column - 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(position.Line - 2, position.Column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //
            pos.defineValue(position.Line - 2, position.Column +1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //
            pos.defineValue(position.Line - 1, position.Column + 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //
            pos.defineValue(position.Line + 1, position.Column + 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //
            pos.defineValue(position.Line +2, position.Column +1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //
            pos.defineValue(position.Line +2, position.Column - 1);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //
            pos.defineValue(position.Line +1, position.Column - 2);
            if (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
                

            return mat;
        }
    }
}

