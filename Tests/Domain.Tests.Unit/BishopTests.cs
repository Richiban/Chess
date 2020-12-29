using System;
using System.Linq;
using NUnit.Framework;
using Richiban.Chess.Domain;
using Shouldly;
using static Richiban.Chess.Domain.Positions;

namespace Tests
{
    [TestFixture]
    public class BishopTests
    {
        [Test]
        public void UnblockedMovesInMiddleOfBoard()
        {
            var sut = new Bishop(Colour.White);
            var board = new BoardState();
            var position = E4;

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new[] {
                new Move(sut, position, F5) { IsTake = false },
                new Move(sut, position, G6) { IsTake = false },
                new Move(sut, position, H7) { IsTake = false },

                new Move(sut, position, F3) { IsTake = false },
                new Move(sut, position, G2) { IsTake = false },
                new Move(sut, position, H1) { IsTake = false },

                new Move(sut, position, D5) { IsTake = false },
                new Move(sut, position, C6) { IsTake = false },
                new Move(sut, position, B7) { IsTake = false },
                new Move(sut, position, A8) { IsTake = false },

                new Move(sut, position, D3) { IsTake = false },
                new Move(sut, position, C2) { IsTake = false },
                new Move(sut, position, B1) { IsTake = false }
            }, ignoreOrder: true);
        }

        [Test]
        public void TestBlockedMove()
        {
            var sut = new Bishop(Colour.White);
            var position = E4;
            var board = new BoardState(new Placement(new Bishop(Colour.White), F5));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new[] {
                new Move(sut, position, F3) { IsTake = false },
                new Move(sut, position, G2) { IsTake = false },
                new Move(sut, position, H1) { IsTake = false },

                new Move(sut, position, D5) { IsTake = false },
                new Move(sut, position, C6) { IsTake = false },
                new Move(sut, position, B7) { IsTake = false },
                new Move(sut, position, A8) { IsTake = false },

                new Move(sut, position, D3) { IsTake = false },
                new Move(sut, position, C2) { IsTake = false },
                new Move(sut, position, B1) { IsTake = false }
            }, ignoreOrder: true);
        }

        [Test]
        public void TestTake()
        {
            var sut = new Bishop(Colour.White);
            var position = E4;
            var board = new BoardState(new Placement(new Bishop(Colour.Black), F5));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new[] {
                new Move(sut, position, F5) { IsTake = true },

                new Move(sut, position, F3) { IsTake = false },
                new Move(sut, position, G2) { IsTake = false },
                new Move(sut, position, H1) { IsTake = false },

                new Move(sut, position, D5) { IsTake = false },
                new Move(sut, position, C6) { IsTake = false },
                new Move(sut, position, B7) { IsTake = false },
                new Move(sut, position, A8) { IsTake = false },

                new Move(sut, position, D3) { IsTake = false },
                new Move(sut, position, C2) { IsTake = false },
                new Move(sut, position, B1) { IsTake = false }
            }, ignoreOrder: true);
        }
    }
}
