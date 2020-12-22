using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Richiban.Chess.Bcl;

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
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.A)),
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.B)),
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.C)),
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.D)),
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.E)),
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.F)),
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.G)),
            new Placement(new Pawn(Colour.White), new Position(Rank.Rank2, File.H)),

            new Placement(new King(Colour.White), new Position(Rank.Rank1, File.E)),
            new Placement(new Queen(Colour.White), new Position(Rank.Rank1, File.D)),

            new Placement(new Bishop(Colour.White), new Position(Rank.Rank1, File.C)),
            new Placement(new Bishop(Colour.White), new Position(Rank.Rank1, File.F)),

            new Placement(new Knight(Colour.White), new Position(Rank.Rank1, File.B)),
            new Placement(new Knight(Colour.White), new Position(Rank.Rank1, File.G)),

            new Placement(new Rook(Colour.White), new Position(Rank.Rank1, File.A)),
            new Placement(new Rook(Colour.White), new Position(Rank.Rank1, File.H)),


            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.A)),
            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.B)),
            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.C)),
            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.D)),
            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.E)),
            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.F)),
            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.G)),
            new Placement(new Pawn(Colour.Black), new Position(Rank.Rank7, File.H)),

            new Placement(new King(Colour.Black), new Position(Rank.Rank8, File.E)),
            new Placement(new Queen(Colour.Black), new Position(Rank.Rank8, File.D)),

            new Placement(new Bishop(Colour.Black), new Position(Rank.Rank8, File.C)),
            new Placement(new Bishop(Colour.Black), new Position(Rank.Rank8, File.F)),

            new Placement(new Knight(Colour.Black), new Position(Rank.Rank8, File.B)),
            new Placement(new Knight(Colour.Black), new Position(Rank.Rank8, File.G)),

            new Placement(new Rook(Colour.Black), new Position(Rank.Rank8, File.A)),
            new Placement(new Rook(Colour.Black), new Position(Rank.Rank8, File.H))
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
