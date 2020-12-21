using System;
using System.Collections.Generic;

namespace Domain
{
    public class Board
    {
        private readonly IReadOnlyCollection<Placement> _placements = new List<Placement>();

        public IReadOnlyCollection<Placement> Placements => _placements;

        internal Option<Piece> GetOccupant(Position position)
        {
            throw new NotImplementedException();
        }

        internal bool IsOccupied(Position position)
        {
            throw new NotImplementedException();
        }
    }
}
