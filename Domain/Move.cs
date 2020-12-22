namespace Richiban.Chess.Domain
{
    public sealed record Move(Piece Piece, Position Origin, Position Destination)
    {
        public bool IsTake { get; init; }
    }
}
