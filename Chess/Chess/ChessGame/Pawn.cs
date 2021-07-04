using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;
namespace Chess.ChessGame
{
    class Pawn : Piece  
    {
        private ChessMatch match;
        public Pawn (BoarD board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool haveEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }
        private bool Free(Position pos)
        {
            return board.piece(pos) == null;
        }
        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);
            if(color == Color.White)
            {
                pos.defineValue(position.Line - 1, position.Column);
                if(board.positionValid(pos)&& Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValue(position.Line - 2, position.Column);
                if (board.positionValid(pos) && Free(pos) && qteMoviments ==0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValue(position.Line - 1, position.Column-1);
                if (board.positionValid(pos) && haveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValue(position.Line - 1, position.Column+1);
                if (board.positionValid(pos) && haveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // special move en passant
                if (position.Line == 3)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if(board.positionValid(left)&&haveEnemy(left)&& board.piece(left) == match.EnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (board.positionValid(right) && haveEnemy(right) && board.piece(right) == match.EnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }

                }
            }
            else
            {
                pos.defineValue(position.Line + 1, position.Column);
                if (board.positionValid(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValue(position.Line + 2, position.Column);
                if (board.positionValid(pos) && Free(pos) && qteMoviments == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValue(position.Line + 1, position.Column - 1);
                if (board.positionValid(pos) && haveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defineValue(position.Line + 1, position.Column + 1);
                if (board.positionValid(pos) && haveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                // special move en passant
                if (position.Line == 4)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (board.positionValid(left) && haveEnemy(left) && board.piece(left) == match.EnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (board.positionValid(right) && haveEnemy(right) && board.piece(right) == match.EnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }

                }
            }



            return mat;
        }
    }
}
