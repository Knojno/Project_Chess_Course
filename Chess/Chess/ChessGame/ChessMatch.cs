using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;
using Chess.ChessGame;

namespace Chess.ChessGame
{
    class ChessMatch
    {
        public BoarD board { get;private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Finishe { get;private set; }

        public ChessMatch()
        {
            board = new BoarD(8, 8);
            Turn = 1;
            Player = Color.White;
            Finishe = false;
            putingPieces();

        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoviments();
            Piece pieceCaptured = board.removePiece(destiny);
            board.putPiece(p, destiny);
        }

        public void makeMove(Position origin, Position destiny)
        {
            executeMoviment(origin, destiny);
            Turn++;
            changePlayer();
        }

        public void validPositionOrigin(Position position)
        {
            if (board.piece(position) == null)
            {
                throw new BoardException(" There is no piece in the chosen position ");
            }
            if (Player != board.piece(position).color)
            {
                throw new BoardException("The origin piece is not yours");
            }
            if (!board.piece(position).havePossibleMoviment())
            {
                throw new BoardException("There is no possible moviments to the chosen piece");
            }
        }

        public void validPositionDestiny(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Destination position invalid");

            }
        }
        private void changePlayer()
        {
            if (Player == Color.White)
            {
                Player = Color.Black;
            }
            else
            {
                Player = Color.White;
            }
        }

        private void putingPieces()
        {
            //WHITE PIECES
            board.putPiece(new Tower(board, Color.White), new PositionChess('a', 1).toPosition());
            board.putPiece(new Tower(board, Color.White), new PositionChess('h', 1).toPosition());
            board.putPiece(new King(board, Color.White), new PositionChess('e', 1).toPosition());
            
            //BLACK PIECES
            board.putPiece(new Tower(board, Color.Black), new PositionChess('a', 8).toPosition());
            board.putPiece(new Tower(board, Color.Black), new PositionChess('h', 8).toPosition());
            board.putPiece(new King(board, Color.Black), new PositionChess('e', 8).toPosition());
            
            /*board.putPiece(new Tower(board, Color.Black), new Position(0, 7));
            board.putPiece(new King(board, Color.Black), new Position(0, 4));
            board.putPiece(new Tower(board, Color.White), new Position(7, 0));
            board.putPiece(new King(board, Color.White), new Position(7, 4));
            board.putPiece(new Tower(board, Color.White), new Position(7, 7));*/
        }


    }
}
