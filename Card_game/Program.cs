using Card_game.Games;
using Cards;
using System;
using System.Collections.Generic;

namespace Card_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which type of game do you want to play ?");
            string gameType = (Console.ReadLine());

            if (gameType=="razboi")
            {
                IGame _gameType = new RazboiFactory().CreateGame();
                CardDeck cardDeck= _gameType.GetCardDeck();
                List<Player> playerList = _gameType.GetPlayerList();
                _gameType.play(cardDeck, playerList);
            }
            if (gameType == "septica")
            {
                IGame _gameType = new SepticaFactory().CreateGame();
                CardDeck cardDeck = _gameType.GetCardDeck();
                List<Player> playerList = _gameType.GetPlayerList();
                _gameType.play(cardDeck, playerList);
            }
            if (gameType == "macaoua")
            {
                IGame _gameType = new MacaouaFactory().CreateGame();
                CardDeck cardDeck = _gameType.GetCardDeck();
                List<Player> playerList = _gameType.GetPlayerList();
                _gameType.play(cardDeck, playerList);
            }


          //  Macaoua game = new Macaoua(cardsDeck,playerList);
           // game.PlayGame();














        }
    }
}
