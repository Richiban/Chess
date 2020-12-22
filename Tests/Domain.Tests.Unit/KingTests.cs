using System;
using System.Linq;
using NUnit.Framework;
using Richiban.Chess.Domain;
using Shouldly;
using static Richiban.Chess.Domain.Rank;
using static Richiban.Chess.Domain.File;

namespace Tests
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void UnblockedMovesInMiddleOfBoard()
        {
            var sut = new King(Colour.White);
            var board = new Board();
            var position = new Position(E, _4);

            var actual = sut.GetLegalMoves(board, position, isFirstMove: false).ToList();

            actual.Count.ShouldBe(8);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual.ShouldContain(pos => pos.Destination.Rank == _3 && pos.Destination.File == D);
            actual.ShouldContain(pos => pos.Destination.Rank == _3 && pos.Destination.File == E);
            actual.ShouldContain(pos => pos.Destination.Rank == _3 && pos.Destination.File == F);

            actual.ShouldContain(pos => pos.Destination.Rank == _4 && pos.Destination.File == D);
            actual.ShouldContain(pos => pos.Destination.Rank == _4 && pos.Destination.File == F);

            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == D);
            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == E);
            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == F);
        }

        [Test]
        public void UnblockedMovesAtEdgeOfBoard()
        {
            var sut = new King(Colour.White);
            var board = new Board();
            var position = new Position(A, _4);

            var actual = sut.GetLegalMoves(board, position, isFirstMove: false).ToList();

            Console.WriteLine(String.Join($",{Environment.NewLine}", actual));

            actual.Count.ShouldBe(5);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual.ShouldContain(pos => pos.Destination.Rank == _3 && pos.Destination.File == A);
            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == A);

            actual.ShouldContain(pos => pos.Destination.Rank == _3 && pos.Destination.File == B);
            actual.ShouldContain(pos => pos.Destination.Rank == _4 && pos.Destination.File == B);
            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == B);
        }

        [Test]
        public void BlockedMoveInMiddleOfBoard()
        {
            var sut = new King(Colour.White);
            var position = new Position(E, _4);
            var board = new Board(new Placement(new Pawn(Colour.White), new(E, _3)));

            var actual = sut.GetLegalMoves(board, position, isFirstMove: false).ToList();

            actual.Count.ShouldBe(7);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual.ShouldContain(pos => pos.Destination.Rank == _3 && pos.Destination.File == D);
            actual.ShouldContain(pos => pos.Destination.Rank == _3 && pos.Destination.File == F);

            actual.ShouldContain(pos => pos.Destination.Rank == _4 && pos.Destination.File == D);
            actual.ShouldContain(pos => pos.Destination.Rank == _4 && pos.Destination.File == F);

            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == D);
            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == E);
            actual.ShouldContain(pos => pos.Destination.Rank == _5 && pos.Destination.File == F);
        }
    }
}
