using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public class Game
    {
        private readonly List<Move> _moves = new List<Move>();
        public IReadOnlyCollection<Move> Moves => _moves;
    }
}
