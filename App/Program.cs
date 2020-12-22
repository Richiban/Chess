using System;
using Richiban.Chess.Domain;
using static Richiban.Chess.Domain.Positions;
using System.Linq;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var piece = new Queen(Colour.White);
            var board = new Board(new Placement(new Pawn(Colour.Black), E6));
            var currentPosition = E4;

            var moves = piece.GetLegalMoves(board, currentPosition).ToList();

            Console.WriteLine($"{piece} moves ({moves.Count}) from {currentPosition}:");

            foreach (var move in moves)
            {
                Console.WriteLine(move);
            }
        }
    }
}
