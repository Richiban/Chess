using System;
using System.Linq;
using NUnit.Framework;
using Richiban.Chess.Domain;
using Shouldly;
using static Richiban.Chess.Domain.Positions;

namespace Tests
{
    [TestFixture]
    public class RookTests
    {
        [Test]
        public void UnblockedMovesInMiddleOfBoard()
        {
            var sut = new Rook(Colour.White);
            var board = new BoardState();
            var position = E4;

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new Move[] {
                new (sut, position, E1) { IsTake = false },
                new (sut, position, E2) { IsTake = false },
                new (sut, position, E3) { IsTake = false },
                new (sut, position, E5) { IsTake = false },
                new (sut, position, E6) { IsTake = false },
                new (sut, position, E7) { IsTake = false },
                new (sut, position, E8) { IsTake = false },

                new (sut, position, A4) { IsTake = false },
                new (sut, position, B4) { IsTake = false },
                new (sut, position, C4) { IsTake = false },
                new (sut, position, D4) { IsTake = false },
                new (sut, position, F4) { IsTake = false },
                new (sut, position, G4) { IsTake = false },
                new (sut, position, H4) { IsTake = false },
            }, ignoreOrder: true);
        }

        [Test]
        public void TestBlockedMove()
        {
            var sut = new Rook(Colour.White);
            var position = E4;
            var board = new BoardState(new Placement(new Rook(Colour.White), E6));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new Move[] {
                new (sut, position, E1) { IsTake = false },
                new (sut, position, E2) { IsTake = false },
                new (sut, position, E3) { IsTake = false },
                new (sut, position, E5) { IsTake = false },

                new (sut, position, A4) { IsTake = false },
                new (sut, position, B4) { IsTake = false },
                new (sut, position, C4) { IsTake = false },
                new (sut, position, D4) { IsTake = false },
                new (sut, position, F4) { IsTake = false },
                new (sut, position, G4) { IsTake = false },
                new (sut, position, H4) { IsTake = false },
            }, ignoreOrder: true);
        }

        [Test]
        public void TestTake()
        {
            var sut = new Rook(Colour.White);
            var position = E4;
            var board = new BoardState(new Placement(new Rook(Colour.Black), E6));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new Move[] {
                new (sut, position, E1) { IsTake = false },
                new (sut, position, E2) { IsTake = false },
                new (sut, position, E3) { IsTake = false },
                new (sut, position, E5) { IsTake = false },
                new (sut, position, E6) { IsTake = true },

                new (sut, position, A4) { IsTake = false },
                new (sut, position, B4) { IsTake = false },
                new (sut, position, C4) { IsTake = false },
                new (sut, position, D4) { IsTake = false },
                new (sut, position, F4) { IsTake = false },
                new (sut, position, G4) { IsTake = false },
                new (sut, position, H4) { IsTake = false },
            }, ignoreOrder: true);
        }
    }
}
