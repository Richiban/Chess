using System;
using System.Linq;
using NUnit.Framework;
using Richiban.Chess.Domain;
using Shouldly;
using static Richiban.Chess.Domain.Positions;

namespace Tests
{
    [TestFixture]
    public class QueenTests
    {
        [Test]
        public void UnblockedMovesInMiddleOfBoard()
        {
            var sut = new Queen(Colour.White);
            var board = new Board();
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

                new (sut, position, F5) { IsTake = false },
                new (sut, position, G6) { IsTake = false },
                new (sut, position, H7) { IsTake = false },

                new (sut, position, F3) { IsTake = false },
                new (sut, position, G2) { IsTake = false },
                new (sut, position, H1) { IsTake = false },

                new (sut, position, D5) { IsTake = false },
                new (sut, position, C6) { IsTake = false },
                new (sut, position, B7) { IsTake = false },
                new (sut, position, A8) { IsTake = false },

                new (sut, position, D3) { IsTake = false },
                new (sut, position, C2) { IsTake = false },
                new (sut, position, B1) { IsTake = false }
            }, ignoreOrder: true);
        }

        [Test]
        public void MoveBlockedByFriendlyPiece()
        {
            var sut = new Queen(Colour.White);
            var position = E4;
            var board = new Board(new Placement(new Pawn(Colour.White), D3));

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

                new (sut, position, F5) { IsTake = false },
                new (sut, position, G6) { IsTake = false },
                new (sut, position, H7) { IsTake = false },

                new (sut, position, F3) { IsTake = false },
                new (sut, position, G2) { IsTake = false },
                new (sut, position, H1) { IsTake = false },

                new (sut, position, D5) { IsTake = false },
                new (sut, position, C6) { IsTake = false },
                new (sut, position, B7) { IsTake = false },
                new (sut, position, A8) { IsTake = false },
            }, ignoreOrder: true);
        }

        [Test]
        public void TakeAvailable()
        {
            var sut = new Queen(Colour.White);
            var position = E4;
            var board = new Board(new Placement(new Pawn(Colour.Black), D3));

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

                new (sut, position, F5) { IsTake = false },
                new (sut, position, G6) { IsTake = false },
                new (sut, position, H7) { IsTake = false },

                new (sut, position, F3) { IsTake = false },
                new (sut, position, G2) { IsTake = false },
                new (sut, position, H1) { IsTake = false },

                new (sut, position, D5) { IsTake = false },
                new (sut, position, C6) { IsTake = false },
                new (sut, position, B7) { IsTake = false },
                new (sut, position, A8) { IsTake = false },

                new (sut, position, D3) { IsTake = true },
            }, ignoreOrder: true);
        }
    }
}
