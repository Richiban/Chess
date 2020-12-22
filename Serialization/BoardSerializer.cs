using System;
using Richiban.Chess.Domain;

namespace Richiban.Chess.Serialization
{
    public class BoardSerializer : IChessSerializer<Board>
    {
        public string Serialize(Board item)
        {
            return "";
        }
    }
}
