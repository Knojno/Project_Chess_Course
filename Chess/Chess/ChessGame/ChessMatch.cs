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
        public bool Check { get; private set; }
        public Piece EnPassant { get; private set; }

        public ChessMatch()
        {
            board = new BoarD(8, 8);
            Turn = 1;
            Player = Color.White;
            Finishe = false;
            Check = false;
            EnPassant = null;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putingPieces();

        }

        public Piece executeMoviment(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoviments();
            Piece pieceCaptured = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if (pieceCaptured != null)
            {
                captured.Add(pieceCaptured);
            }
            //small Castle
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destineT = new Position(origin.Line, origin.Column + 1);
                Piece T = board.removePiece(originT);
                T.incrementMoviments();
                board.putPiece(T, destineT);
            }
            // big Castle
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destineT = new Position(origin.Line, origin.Column -1);
                Piece T = board.removePiece(originT);
                T.incrementMoviments();
                board.putPiece(T, destineT);
            }

            // En Passant
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column&&pieceCaptured == null)
                {
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(destiny.Line - 1, destiny.Column);
                    }
                    pieceCaptured = board.removePiece(posP);
                    captured.Add(pieceCaptured);
                }
            }

            return pieceCaptured;
        }
        public void UnmakeMoviment(Position origin, Position destiny, Piece pieceCaptured)
        {
            Piece p = board.removePiece(destiny);
            p.decrementMoviments();
            if (pieceCaptured != null)
            {
                board.putPiece(pieceCaptured, destiny);
                captured.Remove(pieceCaptured);
            }
            board.putPiece(p, origin);
            //small Castle
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destineT = new Position(origin.Line, origin.Column + 1);
                Piece T = board.removePiece(originT);
                T.incrementMoviments();
                board.putPiece(T, destineT);
            }
            // big Castle
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destineT = new Position(origin.Line, origin.Column - 1);
                Piece T = board.removePiece(originT);
                T.incrementMoviments();
                board.putPiece(T, destineT);
            }

            // En Passant
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && pieceCaptured == EnPassant)
                {
                    Piece pawn = board.removePiece(destiny);
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(3, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.Column);
                    }
                    board.putPiece(pawn, posP);
                }
            }
        }
        public void makeMove(Position origin, Position destiny)
        {
            Piece pieceCaptured = executeMoviment(origin, destiny);
            if (BeInCheck(Player))
            {
                UnmakeMoviment(origin, destiny, pieceCaptured);
                throw new BoardException("You cant put yourself in check");
            }
            Piece p = board.piece(destiny);

            //Promotion
            if (p is Pawn)
            {
                if ((p.color == Color.White && destiny.Line == 0) || (p.color == Color.Black && destiny.Line == 7))
                {
                    p = board.removePiece(destiny);
                    pieces.Remove(p);
                    Piece queen = new Queen(board, p.color);
                    pieces.Add(queen);
                }
            }

            if (BeInCheck(adversary(Player)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckMate(adversary(Player)))
            {
                Finishe = true;
            }
            else
            {
                Turn++;
                changePlayer();
            }
            // En Passant
            if (p is Pawn && (destiny.Line == origin.Line -2 || destiny.Line == origin.Line + 2))
            {
                EnPassant = p;
            }
            else
            {
                EnPassant = null;
            }
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
        private Color adversary(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece king(Color color)
        {
            foreach(Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool BeInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("There is no King of color " + color + " in the board");
            }
            foreach(Piece x in piecesInGame(adversary(color)))
            {
                bool[,] mat = x.possibleMoviments();
                if (mat[K.position.Line, K.position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckMate(Color color)
        {
            if (!BeInCheck(color))
            {
                return false;
            }
            foreach(Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMoviments();
                for (int i = 0; i<board.Lines; i++)
                {
                    for(int j = 0; j<board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece piecesCaptured = executeMoviment(origin, destiny);
                            bool testCheck = BeInCheck(color);
                            UnmakeMoviment(origin, destiny, piecesCaptured);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
            public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }
        private void putingPieces()
        {
            
            //WHITE PIECES
            putNewPiece('a', 1, new Tower(board, Color.White));
            putNewPiece('b', 1, new Horse(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White));
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Horse(board, Color.White));
            putNewPiece('h', 1, new Tower(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White));
            putNewPiece('b', 2, new Pawn(board, Color.White));
            putNewPiece('c', 2, new Pawn(board, Color.White));
            putNewPiece('d', 2, new Pawn(board, Color.White));
            putNewPiece('e', 2, new Pawn(board, Color.White));
            putNewPiece('f', 2, new Pawn(board, Color.White));
            putNewPiece('g', 2, new Pawn(board, Color.White));
            putNewPiece('h', 2, new Pawn(board, Color.White));


            //BLACK PIECES
            putNewPiece('a', 8, new Tower(board, Color.Black));
            putNewPiece('b', 8, new Horse(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Horse(board, Color.Black));
            putNewPiece('h', 8, new Tower(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black));
            putNewPiece('b', 7, new Pawn(board, Color.Black));
            putNewPiece('c', 7, new Pawn(board, Color.Black));
            putNewPiece('d', 7, new Pawn(board, Color.Black));
            putNewPiece('e', 7, new Pawn(board, Color.Black));
            putNewPiece('f', 7, new Pawn(board, Color.Black));
            putNewPiece('g', 7, new Pawn(board, Color.Black));
            putNewPiece('h', 7, new Pawn(board, Color.Black));
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