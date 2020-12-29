using System;
using Richiban.Chess.Domain;
using static Richiban.Chess.Domain.Positions;
using System.Linq;
using Richiban.Chess.Serialization;


var q = new Queen(Colour.White);
var q2 = new Queen(Colour.Black);

var board = new BoardState(
    new(q, E6),
    new(q2, F7));

var move1 = q.GetLegalMoves(board, E6).First();

var game = new Game(move1);

var move2 = q2.GetLegalMoves(board, H7).First();

game = game.WithMove(move2);

var s = new GameSerializer(new MoveSerializer(new PieceSerializer()));

Console.WriteLine(s.Serialize(game));
