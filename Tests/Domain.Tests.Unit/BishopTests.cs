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
    public class BishopTests
    {
        [Test]
        public void UnblockedMovesInMiddleOfBoard()
        {
            var sut = new Bishop(Colour.White);
            var board = new Board();
            var position = new Position(E, _4);

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new[] {
                new Move(sut, position, new Position(F, _5)) { IsTake = false },
                new Move(sut, position, new Position(G, _6)) { IsTake = false },
                new Move(sut, position, new Position(H, _7)) { IsTake = false },

                new Move(sut, position, new Position(F, _3)) { IsTake = false },
                new Move(sut, position, new Position(G, _2)) { IsTake = false },
                new Move(sut, position, new Position(H, _1)) { IsTake = false },

                new Move(sut, position, new Position(D, _5)) { IsTake = false },
                new Move(sut, position, new Position(C, _6)) { IsTake = false },
                new Move(sut, position, new Position(B, _7)) { IsTake = false },
                new Move(sut, position, new Position(A, _8)) { IsTake = false },

                new Move(sut, position, new Position(D, _3)) { IsTake = false },
                new Move(sut, position, new Position(C, _2)) { IsTake = false },
                new Move(sut, position, new Position(B, _1)) { IsTake = false }
            }, ignoreOrder: true);
        }

        [Test]
        public void TestBlockedMove()
        {
            var sut = new Bishop(Colour.White);
            var position = new Position(E, _4);
            var board = new Board(new Placement(new Bishop(Colour.White), new Position(F, _5)));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new[] {
                new Move(sut, position, new Position(F, _3)) { IsTake = false },
                new Move(sut, position, new Position(G, _2)) { IsTake = false },
                new Move(sut, position, new Position(H, _1)) { IsTake = false },

                new Move(sut, position, new Position(D, _5)) { IsTake = false },
                new Move(sut, position, new Position(C, _6)) { IsTake = false },
                new Move(sut, position, new Position(B, _7)) { IsTake = false },
                new Move(sut, position, new Position(A, _8)) { IsTake = false },

                new Move(sut, position, new Position(D, _3)) { IsTake = false },
                new Move(sut, position, new Position(C, _2)) { IsTake = false },
                new Move(sut, position, new Position(B, _1)) { IsTake = false }
            }, ignoreOrder: true);
        }

        [Test]
        public void TestTake()
        {
            var sut = new Bishop(Colour.White);
            var position = new Position(E, _4);
            var board = new Board(new Placement(new Bishop(Colour.Black), new Position(F, _5)));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBe(new[] {
                new Move(sut, position, new Position(F, _5)) { IsTake = true },

                new Move(sut, position, new Position(F, _3)) { IsTake = false },
                new Move(sut, position, new Position(G, _2)) { IsTake = false },
                new Move(sut, position, new Position(H, _1)) { IsTake = false },

                new Move(sut, position, new Position(D, _5)) { IsTake = false },
                new Move(sut, position, new Position(C, _6)) { IsTake = false },
                new Move(sut, position, new Position(B, _7)) { IsTake = false },
                new Move(sut, position, new Position(A, _8)) { IsTake = false },

                new Move(sut, position, new Position(D, _3)) { IsTake = false },
                new Move(sut, position, new Position(C, _2)) { IsTake = false },
                new Move(sut, position, new Position(B, _1)) { IsTake = false }
            }, ignoreOrder: true);
        }
    }
}
