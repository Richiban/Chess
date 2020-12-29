using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Richiban.Chess.Domain
{
    public class Game
    {
        private readonly ImmutableList<Move> _moves;

        public Game(params Move[] moves)
        {
            _moves = moves.ToImmutableList();
        }

        private Game(ImmutableList<Move> moves)
        {
            _moves = moves;
        }

        public IReadOnlyCollection<Move> Moves => _moves;

        public Game WithMove(Move move)
        {
            return new Game(_moves.Add(move));
        }
    }
}
