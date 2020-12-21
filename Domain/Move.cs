namespace Domain
{
    public sealed record Move(Piece piece, Position origin, Position destination);
}
