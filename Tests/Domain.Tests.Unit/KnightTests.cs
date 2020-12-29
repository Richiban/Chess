using System;
using System.Linq;
using NUnit.Framework;
using Richiban.Chess.Domain;
using Shouldly;
using static Richiban.Chess.Domain.Positions;

namespace Tests
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void UnblockedMovesInMiddleOfBoard()
        {
            var sut = new Knight(Colour.White);
            var board = new BoardState();
            var position = E4;

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new Move[] {
                new (sut, position, D6) { IsTake = false },
                new (sut, position, F6) { IsTake = false },

                new (sut, position, G5) { IsTake = false },
                new (sut, position, G3) { IsTake = false },

                new (sut, position, D2) { IsTake = false },
                new (sut, position, F2) { IsTake = false },

                new (sut, position, C5) { IsTake = false },
                new (sut, position, C3) { IsTake = false },
            }, ignoreOrder: true);
        }

        [Test]
        public void MoveBlockedByFriendlyPiece()
        {
            var sut = new Knight(Colour.White);
            var position = E4;
            var board = new BoardState(new Placement(new Pawn(Colour.White), D2));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new Move[] {
                new (sut, position, D6) { IsTake = false },
                new (sut, position, F6) { IsTake = false },

                new (sut, position, G5) { IsTake = false },
                new (sut, position, G3) { IsTake = false },

                new (sut, position, F2) { IsTake = false },

                new (sut, position, C5) { IsTake = false },
                new (sut, position, C3) { IsTake = false },
            }, ignoreOrder: true);
        }

        [Test]
        public void TakeAvailable()
        {
            var sut = new Knight(Colour.White);
            var position = E4;
            var board = new BoardState(new Placement(new Pawn(Colour.Black), D2));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new Move[] {
                new (sut, position, D6) { IsTake = false },
                new (sut, position, F6) { IsTake = false },

                new (sut, position, G5) { IsTake = false },
                new (sut, position, G3) { IsTake = false },

                new (sut, position, D2) { IsTake = true },
                new (sut, position, F2) { IsTake = false },

                new (sut, position, C5) { IsTake = false },
                new (sut, position, C3) { IsTake = false },
            }, ignoreOrder: true);
        }
    }
}
