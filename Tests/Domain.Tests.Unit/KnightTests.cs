using System;
using System.Linq;
using NUnit.Framework;
using Richiban.Chess.Domain;
using Shouldly;
using static Richiban.Chess.Domain.File;
using static Richiban.Chess.Domain.Rank;

namespace Tests
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void UnblockedMovesInMiddleOfBoard()
        {
            var sut = new Knight(Colour.White);
            var board = new Board();
            var position = new Position(E, _4);

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.Count.ShouldBe(8);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);
            actual.ShouldAllBe(mv => mv.IsTake == false);

            actual.ShouldContain(mv => mv.Destination.Rank == _6 && mv.Destination.File == D);
            actual.ShouldContain(mv => mv.Destination.Rank == _6 && mv.Destination.File == F);

            actual.ShouldContain(mv => mv.Destination.Rank == _5 && mv.Destination.File == G);
            actual.ShouldContain(mv => mv.Destination.Rank == _3 && mv.Destination.File == G);

            actual.ShouldContain(mv => mv.Destination.Rank == _2 && mv.Destination.File == D);
            actual.ShouldContain(mv => mv.Destination.Rank == _2 && mv.Destination.File == F);

            actual.ShouldContain(mv => mv.Destination.Rank == _5 && mv.Destination.File == C);
            actual.ShouldContain(mv => mv.Destination.Rank == _3 && mv.Destination.File == C);
        }

        [Test]
        public void MoveBlockedByFriendlyPiece()
        {
            var sut = new Knight(Colour.White);
            var position = new Position(E, _4);
            var board = new Board(new Placement(new Pawn(Colour.White), new Position(D, _2)));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.Count.ShouldBe(7);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);
            actual.ShouldAllBe(mv => mv.IsTake == false);

            actual.ShouldContain(mv => mv.Destination.Rank == _6 && mv.Destination.File == D);
            actual.ShouldContain(mv => mv.Destination.Rank == _6 && mv.Destination.File == F);

            actual.ShouldContain(mv => mv.Destination.Rank == _5 && mv.Destination.File == G);
            actual.ShouldContain(mv => mv.Destination.Rank == _3 && mv.Destination.File == G);

            actual.ShouldContain(mv => mv.Destination.Rank == _2 && mv.Destination.File == F);

            actual.ShouldContain(mv => mv.Destination.Rank == _5 && mv.Destination.File == C);
            actual.ShouldContain(mv => mv.Destination.Rank == _3 && mv.Destination.File == C);
        }

        [Test]
        public void TakeAvailable()
        {
            var sut = new Knight(Colour.White);
            var position = new Position(E, _4);
            var board = new Board(new Placement(new Pawn(Colour.Black), new Position(D, _2)));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.Count.ShouldBe(8);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual.ShouldContain(mv => mv.Destination.Rank == _6 && mv.Destination.File == D && mv.IsTake == false);
            actual.ShouldContain(mv => mv.Destination.Rank == _6 && mv.Destination.File == F && mv.IsTake == false);

            actual.ShouldContain(mv => mv.Destination.Rank == _5 && mv.Destination.File == G && mv.IsTake == false);
            actual.ShouldContain(mv => mv.Destination.Rank == _3 && mv.Destination.File == G && mv.IsTake == false);

            actual.ShouldContain(mv => mv.Destination.Rank == _2 && mv.Destination.File == D && mv.IsTake == true);
            actual.ShouldContain(mv => mv.Destination.Rank == _2 && mv.Destination.File == F && mv.IsTake == false);

            actual.ShouldContain(mv => mv.Destination.Rank == _5 && mv.Destination.File == C && mv.IsTake == false);
            actual.ShouldContain(mv => mv.Destination.Rank == _3 && mv.Destination.File == C && mv.IsTake == false);
        }
    }
}
