using NUnit.Framework;
using Richiban.Chess.Serialization;

namespace Serialization.Tests.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var piece = new Queen();

            var sut = new MoveSerializer();

            sut.Serialize(new Move());
        }
    }
}