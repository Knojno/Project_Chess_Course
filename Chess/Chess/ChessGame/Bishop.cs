using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;

namespace Chess.ChessGame
{
    class Bishop : Piece
    {
        public Bishop(BoarD board, Color color) : base(board, color)
        {
        }
            public override string ToString()
        {
            return "B";
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

            //NO
            pos.defineValue(position.Line - 1, position.Column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValue(pos.Line - 1, pos.Column - 1);
            }

            // NE
            pos.defineValue(position.Line - 1, position.Column + 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValue(pos.Line - 1, pos.Column + 1);
            }

            // SE
            pos.defineValue(position.Line + 1, position.Column + 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValue(pos.Line + 1, pos.Column + 1);
            }

            // SO
            pos.defineValue(position.Line + 1, position.Column - 1);
            while (board.positionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValue(pos.Line + 1, pos.Column - 1);
            }

            return mat;
        }



    }
    }

