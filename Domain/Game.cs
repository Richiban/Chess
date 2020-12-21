using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        private readonly List<Move> _moves = new List<Move>();
        public IReadOnlyCollection<Move> Moves => _moves;
    }
}
