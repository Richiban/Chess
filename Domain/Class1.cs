using System;

namespace Domain
{
    public sealed class Rank
    {
        private Rank() { }

        public static Rank Rank1 { get; } = new Rank();
        public static Rank Rank2 { get; } = new Rank();
        public static Rank Rank3 { get; } = new Rank();
        public static Rank Rank4 { get; } = new Rank();
        public static Rank Rank5 { get; } = new Rank();
        public static Rank Rank6 { get; } = new Rank();
        public static Rank Rank7 { get; } = new Rank();
        public static Rank Rank8 { get; } = new Rank();
    }

    public sealed class File
    {
        private File() { }

        public static File A { get; } = new File();
        public static File B { get; } = new File();
        public static File C { get; } = new File();
        public static File D { get; } = new File();
        public static File E { get; } = new File();
        public static File F { get; } = new File();
        public static File G { get; } = new File();
        public static File H { get; } = new File();
    }

    public sealed record Position(Rank rank, File file);

    public sealed record Move(Piece piece, Position origin, Position destination);

    public abstract class Piece
    {
        public abstract string Name { get; }
    }

    public sealed class Pawn : Piece
    {
        public override string Name => nameof(Pawn);
    }

    public sealed class Bishop : Piece
    {
        public override string Name => nameof(Bishop);
    }

    public sealed class Knight : Piece
    {
        public override string Name => nameof(Knight);
    }

    public sealed class Rook : Piece
    {
        public override string Name => nameof(Rook);
    }

    public sealed class Queen : Piece
    {
        public override string Name => nameof(Queen);
    }

    public sealed class King : Piece
    {
        public override string Name => nameof(King);
    }
}
