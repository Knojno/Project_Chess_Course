using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Board
{
    class BoarD
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public BoarD(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public void movePiece(Piece p, Position pos)
        {
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }
    }
}
