using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public sealed record Position(Rank Rank, File File)
    {
        public static Option<Position> operator +(Position position, ChessVector vector) =>
            from rank in position.Rank + vector.Ranks
            from file in position.File + vector.Files
            select new Position(rank, file);

        public static Option<Position> operator -(Position position, ChessVector vector) =>
            from rank in position.Rank - vector.Ranks
            from file in position.File - vector.Files
            select new Position(rank, file);
    }
}
