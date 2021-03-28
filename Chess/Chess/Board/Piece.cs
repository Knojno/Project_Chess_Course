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

        public Piece(BoarD board,Color color )
        {
            this.position = null;        
            this.board = board;
            this.color = color;
            this.qteMovimentes = 0;
        }
    }
}
