using System;
using System.Windows.Forms;

namespace Uno
{
    class Game
    {
        private static readonly Timer Timer = new Timer();

        private const int MaxBeginingCards = 7;

        public static bool Over;

        public static bool Started { get; private set; }


        public static void Init()
        {
            Timer.Interval = 200;
            Timer.Tick += timer_Tick;
        }

        static private void timer_Tick(object sender, EventArgs e)
        {
            //painting related
            if (GameData.FlagDirty)
            {
                GameData.Form.Invalidate(true);

                //BUG - When new game started, the painting was not done  Solution
                GameData.FlagDirty = false;
                //BUG - End
            }

            //Computer's move
            if (!Over && !Logic.PlayerTurn)
            {
                Logic.MakeOpponentMove();
            }
        }

        public static void StartNewGame()
        {
            Timer.Stop();

            ClearUp();
            Deal();
            DistributeCards();

            //show the cards before any move made
            GameData.FlagDirty = true;

            Timer.Start();

            //throw assembly card from the deck
            ThrowFirstCard();
        }

        public static void PauseGame()
        {
        }

        public static void ContinueGame()
        {
        }

        public static void AbortGame()
        {
        }

        private static void ClearUp()
        {
            //GameData.Deck.Clear();
            GameData.OpenCards.Clear();

            GameData.Player.Clear();
            GameData.Opponnent.Clear();

            GameData.PlayerScore = GameData.OpponentScore = 0;

            Started = true; //the game has begun

            Over = false; // game not finished
        }

        private static void Deal()
        {
            //GameData.Deck.CreateDeck();
            GameData.Deck.Shuffle();
        }

        private static void DistributeCards()
        {
            for (var i = 0; i < MaxBeginingCards; i++)
            {
                GameData.Player.AddCard(GameData.Deck.GetACard());
                GameData.Opponnent.AddCard(GameData.Deck.GetACard());
            }
        }

        private static void ThrowFirstCard()
        {
            var card = GameData.Deck.GetACard();
            GameData.OpenCards.Add(card);

            //if the card just thrown will require the player or
            //opponent to pick some cards..
            Logic.CheckIfAddCardRequired(card);

            //whose turn is it
            if (!Logic.PlayerTurn)
            {
                Logic.OpponentSelectsNewColor();
            }
            else if (card.Number == UnoCards.WildCard)
            {
                Logic.PlayerSelectsNewColor(card);
                Logic.PlayerTurn = false;
            }
        }
    }
}