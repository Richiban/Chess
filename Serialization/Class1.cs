using System;
using Domain;

namespace Serialization
{
    public class BoardSerializer : IChessSerializer<Board>
    {
        public string Serialize(Board item)
        {
            return "";
        }
    }
}
