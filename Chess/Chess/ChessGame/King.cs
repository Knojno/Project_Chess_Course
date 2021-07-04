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
        private ChessMatch match;
        public King(BoarD board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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
        private bool testForRock(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.color == color && p.qteMoviments == 0;
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

            //Especial move Castle
            if (qteMoviments==0 && !match.Check)
            {
                //small Castle
                Position posT1 = new Position(position.Line, position.Column + 3);
                if (testForRock(posT1))
                {
                    Position p1 = new Position(position.Line, position.Column + 1);
                    Position p2 = new Position(position.Line, position.Column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.Line, position.Column + 2] = true;
                    }
                }
                //big Castle
                Position posT2 = new Position(position.Line, position.Column - 4);
                if (testForRock(posT2))
                {
                    Position p1 = new Position(position.Line, position.Column - 1);
                    Position p2 = new Position(position.Line, position.Column - 2);
                    Position p3 = new Position(position.Line, position.Column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.Line, position.Column - 2] = true;
                    }
                }
            }







            return mat;

        }
    }
}
