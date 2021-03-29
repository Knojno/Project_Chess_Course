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

        public Piece piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public bool existPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }
        
        
        
        public void movePiece(Piece p, Position pos)
        {
            if (existPiece(pos))
            {
                throw new BoardException("Already exist a Piece");
            }
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }

        public bool positionValid(Position pos)
        {
            if (pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!positionValid(pos))
            {
                throw new BoardException("Position invalid");
            }
        }
        

        
    }
}
