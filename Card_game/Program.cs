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
            CardDeck cardsDeck = new CardDeck();
            List<Card> DiscardPile = new List<Card>();
            cardsDeck.Shuffle();

           
            Console.WriteLine("Which type of game do you want to play ?");
            string gameType = (Console.ReadLine());

            Console.WriteLine("How many players are you ?");
            int numPlayers = Convert.ToInt32(Console.ReadLine());

            List<Player> playerList = new List<Player>();
            //Create the players
            for (int i = 1; i <= numPlayers; i++)
            {
                playerList.Add(new Player()
                {
                    Position = i
                });
            }

            if (gameType=="razboi")
            {
                IGame _gameType = new RazboiFactory().CreateGame(cardsDeck, playerList);
                _gameType.Play();
            }
            if (gameType == "septica")
            {
                IGame _gameType = new SepticaFactory().CreateGame(cardsDeck, playerList);
                _gameType.Play();
            }
            if (gameType == "macaoua")
            {
                IGame _gameType = new MacaouaFactory().CreateGame(cardsDeck, playerList);
                _gameType.Play();
            }



          //  Macaoua game = new Macaoua(cardsDeck,playerList);
           // game.PlayGame();














        }
    }
}
