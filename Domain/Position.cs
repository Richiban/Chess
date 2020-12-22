using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public sealed record Position(Rank Rank, File File)
    {
        public static Option<Position> operator +(Position position, ChessVector vector)
        {
            return
                from rank in position.Rank + vector.Y
                from file in position.File + vector.X
                select new Position(rank, file);
        }
    }
}
