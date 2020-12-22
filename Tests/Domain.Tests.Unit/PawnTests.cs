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
    public class PawnTests
    {
        [Test]
        public void TestBasicMove()
        {
            var sut = new Pawn(Colour.White);
            var board = new Board();
            var position = new Position(Rank.Rank2, File.E);

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldHaveSingleItem();
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual[0].Destination.Rank.ShouldBe(Rank.Rank3);
            actual[0].Destination.File.ShouldBe(File.E);
        }

        [Test]
        public void TestBlockedMove()
        {
            var sut = new Pawn(Colour.White);
            var position = new Position(Rank.Rank2, File.E);
            var board = new Board(new Placement(new Pawn(Colour.Black), new Position(Rank.Rank3, File.E)));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBeEmpty();
        }

        [Test]
        public void TestPassThroughBlock()
        {
            var sut = new Pawn(Colour.White);
            var position = new Position(Rank.Rank2, File.E);
            var board = new Board(new Placement(new Pawn(Colour.Black), new Position(Rank.Rank3, File.E)));

            var actual = sut.GetLegalMoves(board, position, isFirstMove: true).ToList();

            actual.ShouldBeEmpty();
        }

        [Test]
        public void TestTwoPlaceFirstMove()
        {
            var sut = new Pawn(Colour.White);
            var position = new Position(Rank.Rank2, File.E);
            var board = new Board(new Placement(sut, position));

            var actual = sut.GetLegalMoves(board, position, isFirstMove: true).ToList();

            actual.Count.ShouldBe(2);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual[0].Destination.Rank.ShouldBe(Rank.Rank3);
            actual[0].Destination.File.ShouldBe(File.E);

            actual[1].Destination.Rank.ShouldBe(Rank.Rank4);
            actual[1].Destination.File.ShouldBe(File.E);
        }

        [Test]
        public void TestTakeMoveAndStraightMove()
        {
            var sut = new Pawn(Colour.White);
            var board = new Board(new Placement(new Pawn(Colour.Black), new Position(Rank.Rank3, File.F)));
            var position = new Position(Rank.Rank2, File.E);

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.Count.ShouldBe(2);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual.ShouldContain(mv => mv.Destination.Rank == (Rank3) && mv.Destination.File == (E));

            actual[0].Destination.Rank.ShouldBe(Rank.Rank3);
            actual[0].Destination.File.ShouldBe(File.F);
            actual[0].IsTake.ShouldBe(true);
        }
    }
}
