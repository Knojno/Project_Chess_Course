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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new BoarD(8, 8);
            Turn = 1;
            Player = Color.White;
            Finishe = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putingPieces();

        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoviments();
            Piece pieceCaptured = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if (pieceCaptured != null)
            {
                captured.Add(pieceCaptured);
            }
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

        public HashSet<Piece> piecesCaptured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(piecesCaptured(color));
            return aux;
        }
            public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }
        private void putingPieces()
        {
            
            //WHITE PIECES
            putNewPiece('c', 1, new Tower(board, Color.White));
            putNewPiece('c', 2, new Tower(board, Color.White));
            putNewPiece('d', 2, new Tower(board, Color.White));
            putNewPiece('e', 2, new Tower(board, Color.White));
            putNewPiece('e', 1, new Tower(board, Color.White));
            putNewPiece('d', 1, new King(board, Color.White));



            //BLACK PIECES
            putNewPiece('c', 7, new Tower(board, Color.Black));
            putNewPiece('c', 8, new Tower(board, Color.Black));
            putNewPiece('d', 7, new Tower(board, Color.Black));
            putNewPiece('e', 7, new Tower(board, Color.Black));
            putNewPiece('e', 8, new Tower(board, Color.Black));
            putNewPiece('d', 8, new King(board, Color.Black));


        }


    }
}
          /*board.putPiece(new Tower(board, Color.Black), new PositionChess('a', 8).toPosition());
            board.putPiece(new Tower(board, Color.Black), new PositionChess('h', 8).toPosition());
            board.putPiece(new King(board, Color.Black), new PositionChess('e', 8).toPosition());
            board.putPiece(new Tower(board, Color.White), new PositionChess('a', 1).toPosition());
            board.putPiece(new Tower(board, Color.White), new PositionChess('h', 1).toPosition());
            board.putPiece(new King(board, Color.White), new PositionChess('e', 1).toPosition());
            board.putPiece(new Tower(board, Color.Black), new Position(0, 7));
            board.putPiece(new King(board, Color.Black), new Position(0, 4));
            board.putPiece(new Tower(board, Color.White), new Position(7, 0));
            board.putPiece(new King(board, Color.White), new Position(7, 4));
            board.putPiece(new Tower(board, Color.White), new Position(7, 7));*/