using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public sealed record Position(File File, Rank Rank)
    {
        public override string ToString() => $"{File}{Rank}";

        public static Option<Position> operator +(Position position, ChessVector vector) =>
            from rank in position.Rank + vector.Ranks
            from file in position.File + vector.Files
            select new Position(file, rank);

        public static Option<Position> operator -(Position position, ChessVector vector) =>
            from rank in position.Rank - vector.Ranks
            from file in position.File - vector.Files
            select new Position(file, rank);
    }
}
