using System;
using System.Linq;
using Richiban.Chess.Domain;

namespace Richiban.Chess.Serialization
{
    public class GameSerializer : IChessSerializer<Game>
    {
        private readonly IChessSerializer<Move> _moveSerializer;

        public GameSerializer(IChessSerializer<Move> moveSerializer)
        {
            _moveSerializer = moveSerializer;
        }

        public string Serialize(Game game)
        {
            var moves = game.Moves.Select(_moveSerializer.Serialize);

            return string.Join(Environment.NewLine, moves);
        }
    }
}
