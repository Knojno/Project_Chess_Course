using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qteMovimentes { get; protected set; }
        public BoarD board { get; protected set; }

        public Piece(Position position, Color color, BoarD board)
        {
            this.position = position;
            this.color = color;
            this.board = board;
            this.qteMovimentes = 0;
        }
    }
}
