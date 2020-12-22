using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Richiban.Chess.Bcl;
using static Richiban.Chess.Domain.Positions;

namespace Richiban.Chess.Domain
{
    public class Board
    {
        private readonly ImmutableList<Placement> _placements;

        public Board(params Placement[] startingPlacements)
        {
            _placements = startingPlacements.ToImmutableList();
        }

        public static Board StartingBoard => new Board(
            new Placement(new Pawn(Colour.White), A2),
            new Placement(new Pawn(Colour.White), B2),
            new Placement(new Pawn(Colour.White), C2),
            new Placement(new Pawn(Colour.White), D2),
            new Placement(new Pawn(Colour.White), E2),
            new Placement(new Pawn(Colour.White), F2),
            new Placement(new Pawn(Colour.White), G2),
            new Placement(new Pawn(Colour.White), H2),

            new Placement(new King(Colour.White), E1),
            new Placement(new Queen(Colour.White), D1),

            new Placement(new Bishop(Colour.White), C1),
            new Placement(new Bishop(Colour.White), F1),

            new Placement(new Knight(Colour.White), B1),
            new Placement(new Knight(Colour.White), G1),

            new Placement(new Rook(Colour.White), A1),
            new Placement(new Rook(Colour.White), H1),


            new Placement(new Pawn(Colour.Black), A7),
            new Placement(new Pawn(Colour.Black), B7),
            new Placement(new Pawn(Colour.Black), C7),
            new Placement(new Pawn(Colour.Black), D7),
            new Placement(new Pawn(Colour.Black), E7),
            new Placement(new Pawn(Colour.Black), F7),
            new Placement(new Pawn(Colour.Black), G7),
            new Placement(new Pawn(Colour.Black), H7),

            new Placement(new King(Colour.Black), E8),
            new Placement(new Queen(Colour.Black), D8),

            new Placement(new Bishop(Colour.Black), C8),
            new Placement(new Bishop(Colour.Black), F8),

            new Placement(new Knight(Colour.Black), B8),
            new Placement(new Knight(Colour.Black), G8),

            new Placement(new Rook(Colour.Black), A8),
            new Placement(new Rook(Colour.Black), H8)
        );

        public IReadOnlyCollection<Placement> Placements => _placements;

        internal Option<Piece> GetOccupant(Position position)
        {
            return Placements.FirstOrNone(pos => pos.Position.Equals(position)).Map(it => it.Piece);
        }

        internal bool IsEmpty(Position position) =>
            GetOccupant(position).HasValue == false;
    }
}
