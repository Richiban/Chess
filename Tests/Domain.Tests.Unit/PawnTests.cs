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
            var board = new BoardState();
            var position = new Position(E, _2);

            var actual = sut.GetLegalMoves(board, position).ToList();

            var move = actual.ShouldHaveSingleItem();
            move.Piece.ShouldBe(sut);
            move.Origin.ShouldBe(position);

            move.Destination.Rank.ShouldBe(Rank._3);
            move.Destination.File.ShouldBe(File.E);
        }

        [Test]
        public void TestBlockedMove()
        {
            var sut = new Pawn(Colour.White);
            var position = new Position(E, _2);
            var board = new BoardState(new Placement(new Pawn(Colour.Black), new Position(E, _3)));

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.ShouldBeEmpty();
        }

        [Test]
        public void TestPassThroughBlock()
        {
            var sut = new Pawn(Colour.White);
            var position = new Position(E, _2);
            var board = new BoardState(new Placement(new Pawn(Colour.Black), new Position(E, _3)));

            var actual = sut.GetLegalMoves(board, position, isFirstMove: true).ToList();

            actual.ShouldBeEmpty();
        }

        [Test]
        public void TestTwoPlaceFirstMove()
        {
            var sut = new Pawn(Colour.White);
            var position = new Position(E, _2);
            var board = new BoardState(new Placement(sut, position));

            var actual = sut.GetLegalMoves(board, position, isFirstMove: true).ToList();

            actual.Count.ShouldBe(2);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual[0].Destination.Rank.ShouldBe(Rank._3);
            actual[0].Destination.File.ShouldBe(File.E);

            actual[1].Destination.Rank.ShouldBe(Rank._4);
            actual[1].Destination.File.ShouldBe(File.E);
        }

        [Test]
        public void TestTakeMoveAndStraightMove()
        {
            var sut = new Pawn(Colour.White);
            var board = new BoardState(new Placement(new Pawn(Colour.Black), new Position(F, _3)));
            var position = new Position(E, _2);

            var actual = sut.GetLegalMoves(board, position).ToList();

            actual.Count.ShouldBe(2);
            actual.ShouldAllBe(mv => mv.Piece == sut);
            actual.ShouldAllBe(mv => mv.Origin == position);

            actual.ShouldContain(mv => mv.Destination.Rank == (_3) && mv.Destination.File == (E));

            actual[0].Destination.Rank.ShouldBe(Rank._3);
            actual[0].Destination.File.ShouldBe(File.F);
            actual[0].IsTake.ShouldBe(true);
        }
    }
}
