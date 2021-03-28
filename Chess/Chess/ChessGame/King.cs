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
        public King(BoarD board, Color color) : base(board ,color )
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
