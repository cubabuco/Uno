using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
    class Logic
    {
        private static int _numberOfDrawnCards;
        private static bool _thinking;

        private static bool _bPlaying;

        private static bool _playerTurn = true;
        public static bool PlayerTurn
        {
            get
            {
                return _playerTurn;
            }
            set
            {
                _playerTurn = value;
                _numberOfDrawnCards = 0;
            }
        }

        private static Card NextCardToThrow(Cards cards)
        {
            Logger.FuncInit("Logic.nextCardToThrow");
            Card nextMoveCard = null;

            var topCard = GameData.OpenCards.LastCard();
            if (topCard != null)
            {
                var sameColor = new Cards();
                var sameNumber = new Cards();
                var wilds = new Cards();

                foreach (Card card in cards)
                {
                    if (card.Color == UnoColours.NoColor) //must be some wild
                    {
                        wilds.Add(card);
                    }
                    else
                    {
                        if (GameData.RunningColor == card.Color)
                        {
                            sameColor.Add(card);
                        }

                        if (topCard.Number == card.Number)
                        {
                            sameNumber.Add(card);
                        }
                    }
                }

                //if there is no wild card open...
                if (GameData.RunningColor != UnoColours.NoColor)
                {
                    //if same colors are there
                    if (sameColor.Count > 0)
                    {
                        nextMoveCard = Tools.GetBiggestCard(sameColor);
                    }
                    else
                    {
                        //if not colors, but there are same numbers...
                        if (sameNumber.Count > 0)
                        {
                            // even then play the wild (for minimal score)
                            if (wilds.Count > 0)
                            {
                                nextMoveCard = Tools.GetBiggestCard(wilds);
                            }
                            else //if there are no wilds, play the number
                            {
                                //choose assembly random number card
                                var rand = Tools.GetRandomObject();
                                nextMoveCard = sameNumber[rand.Next(sameNumber.Count)];
                            }
                        }
                        else //there were no colours and no same numbers,
                        // we have to choose from the wild cards
                        {
                            if (wilds.Count > 0)
                                nextMoveCard = Tools.GetBiggestCard(wilds);
                        }
                    }
                }
                else //we can play any card!!
                {
                    //for simplicity now,
                    //lets play the biggest card available to opponent.
                    nextMoveCard = Tools.GetBiggestCard(cards);
                }

            }

            Logger.FuncExit("Logic.nextCardToThrow");
            return nextMoveCard;
        }

        public static void CheckIfAddCardRequired(Card card)
        {
            Logger.FuncInit("Logic.CheckIfAddCardRequired");
            switch (card.Number)
            {
                case UnoCards.Plus2:
                case UnoCards.DrawTwo:
                    if (!PlayerTurn)
                    {
                        AddCardToPlayer();
                        AddCardToPlayer();
                    }
                    else
                    {
                        AddCardToOpponent();
                        AddCardToOpponent();
                    }
                    break;
                case UnoCards.DrawFour:
                    if (!PlayerTurn)
                    {
                        AddCardToPlayer();
                        AddCardToPlayer();
                        AddCardToPlayer();
                        AddCardToPlayer();
                    }
                    else
                    {
                        AddCardToOpponent();
                        AddCardToOpponent();
                        AddCardToOpponent();
                        AddCardToOpponent();
                    }
                    break;
            }
            Logger.FuncExit("Logic.CheckIfAddCardRequired");
        }

        private static void CalculateTotalScore()
        {
            GameData.TotalPlayerScore += GameData.PlayerScore;
            GameData.TotalOpponentScore += GameData.OpponentScore;
        }


        //////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Opponent's functions
        /// </summary>
        public static void MakeOpponentMove()
        {
            Logger.FuncInit("Logic.MakeOpponentMove");
            if (!_thinking)
            {
                _thinking = true;
                MoveOpponent();

                _thinking = false;

                PlayerTurn = true;
            }
            Logger.FuncExit("Logic.MakeOpponentMove");
        }

        private static void CheckOpponentWin()
        {
            if (GameData.Opponnent.Cards.Count == 0 && !Game.Over)
            {
                Game.Over = true;

                GameData.PlayerScore = 0;
                foreach (Card card in GameData.Player.Cards)
                {
                    GameData.PlayerScore += Tools.GetPoint(card);
                }
                CalculateTotalScore();
                MessageBox.Show("You lose by " + GameData.PlayerScore + ".", "Sorry!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static void MoveOpponent()
        {
            Logger.FuncInit("Logic.moveOpponent");
            var nextCard = NextCardToThrow(GameData.Opponnent.Cards);
            if (nextCard == null) //no valid card with opponent, must pick from pile.
            {
                if (_numberOfDrawnCards <= 0) //if no card has been picked from stock yet...
                {
                    AddCardToOpponent();
                    _numberOfDrawnCards++; //mark this pick.

                    MoveOpponent(); //is any possible move yet?
                    _numberOfDrawnCards = 0; //reset the picking mark.
                }
            }
            else //there is assembly valid card!!
            {
                PutDownOpponentCard(nextCard);

                //where should I put it???
                CheckOpponentWin();

                //play continuously?
                if (nextCard.Number > UnoCards.Nine && nextCard.Number <= UnoCards.DrawFour)
                {
                    CheckIfAddCardRequired(nextCard);

                    if (nextCard.Number >= UnoCards.WildCard && nextCard.Number <= UnoCards.DrawFour)
                    {
                        OpponentSelectsNewColor();
                    }

                    if (nextCard.Number != UnoCards.WildCard)
                    {
                        _numberOfDrawnCards = 0; //reset it, bcoz player can pick the card again.

                        MoveOpponent(); //play again!
                    }
                }
            }
            Logger.FuncExit("Logic.moveOpponent");
        }

        public static void OpponentSelectsNewColor()
        {
            var rand = Tools.GetRandomObject();
            GameData.RunningColor = (UnoColours)(rand.Next(4) + 1);
        }

        private static void PutDownOpponentCard(Card nextCard)
        {
            Logger.FuncInit("Logic.putDownOpponentCard");
            GameData.Opponnent.Cards.Remove(nextCard);

            Animate.Move(nextCard,
                        GameData.LocOpponent.Left, GameData.LocOpponent.Top,
                        GameData.LocBoard.Left + (GameData.LocBoard.Width - CardImagesResources.CardImageList[nextCard.ImageListOffset].Width) / 2, GameData.LocBoard.Top);

            GameData.OpenCards.Add(nextCard);

            GameData.FlagDirty = true;
            Logger.FuncExit("Logic.putDownOpponentCard");
        }

        private static void AddCardToOpponent()
        {
            if (!GameData.Deck.IsDeckEmpty())
            {
                Animate.Move(GameData.BackFacingCard,
                             new Point(GameData.LocSlot.Location.X + (GameData.LocSlot.Width - CardImagesResources.CardImageList[GameData.BackFacingCard.ImageListOffset].Width) / 2,
                                                      GameData.LocSlot.Location.Y),
                             GameData.LocOpponent.Location);

                GameData.Opponnent.AddCard(GameData.Deck.GetACard());
            }
            else
            {
                ReloadDeckFromOpenCards();
            }

            GameData.FlagDirty = true;
        }

        /// <summary>
        /// Loads the cards which were thrown on the desk, except for the top most
        /// open card.
        /// </summary>
        private static void ReloadDeckFromOpenCards()
        {
            Logger.FuncInit("Logic.reloadDeckFromOpenCards");
            //if there are cards open on the deck, and they should be more than 1!!
            if (GameData.OpenCards.Count > 1)
            {
                //GameData.Deck.SetCards(GameData.OpenCards.GetCards());
                GameData.Deck.Shuffle();
                GameData.OpenCards.Clear();
                GameData.OpenCards.Add(GameData.Deck.GetACard());
            }
            Logger.FuncExit("Logic.reloadDeckFromOpenCards");
        }

        //////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Plays the player's turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Play(object sender, MouseEventArgs e)
        {
            Logger.FuncInit("Logic.Play");
            if (_bPlaying == false)
            {
                _bPlaying = true;
                //if player wants to draw assembly card
                if (GameData.LocSlot.Contains(e.Location))
                {
                    if (_numberOfDrawnCards < 1) //if not drawn yet
                    {
                        AddCardToPlayer();
                        _numberOfDrawnCards++; //mark this pick.
                        GameData.Form.btnPass.Enabled = true; //can pass now or must throw assembly card
                    }
                }
                else if (GameData.LocPlayer.Contains(e.Location)) //he clicked his cards
                {
                    GameData.Form.btnPass.Enabled = false;

                    var canContinue = PlayTheCard(sender, e);
                    if (!canContinue)
                    {
                        PlayerTurn = false; //change the role and reset the data
                        GameData.Form.btnPass.Enabled = false;
                    }
                    else
                    {
                        _numberOfDrawnCards = 0;
                    }
                }
                _bPlaying = false;
            }
            Logger.FuncExit("Logic.Play");
        }

        private static int GetPlayerCardIndex(MouseEventArgs e)
        {
            var num = -1;

            var fitSize = Tools.BestFitSize(CardImagesResources.CardImageList[GameData.BackFacingCard.ImageListOffset].Size, GameData.LocPlayer.Size);
            var overlappedWidth = fitSize.Width / GameData.OverLappedRegionWidthRatio;

            var maxWidthOfCards = (GameData.Player.Cards.Count - 1) * overlappedWidth + fitSize.Width;
            var distance = e.X - GameData.LocPlayer.X;
            if (distance <= maxWidthOfCards)
            {
                num = distance / overlappedWidth;
                if (distance % overlappedWidth > 0)
                {
                    num++;
                }

                if (num > GameData.Player.Cards.Count)
                {
                    num = GameData.Player.Cards.Count;
                }
            }

            return num;
        }

        /// <summary>
        /// Player's functions
        /// </summary>
        private static bool PlayTheCard(object sender, MouseEventArgs e)
        {
            Logger.FuncInit("Logic.playTheCard");
            var canContinue = true;

            var num = GetPlayerCardIndex(e);
            if (num > -1)
            {
                var card = GameData.Player.Cards[num - 1];
                if (CanThrow(card))
                {
                    PutDownCardOfPlayer(card);

                    CheckIfAddCardRequired(card);

                    CheckpointPlayerWin();

                    PlayerSelectsNewColor(card);

                    if (card.Number <= UnoCards.Nine || card.Number == UnoCards.WildCard)
                    {
                        canContinue = false;
                    }
                }
                else
                {
                    //MessageBox.Show("Invalid move", "Err..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Tools.FlashError();
                }
            }

            Logger.FuncExit("Logic.playTheCard");
            return canContinue;
        }

        public static void PlayerSelectsNewColor(Card card)
        {
            if (card.Number == UnoCards.WildCard)
            {
                var frmcolors = new FrmColorSelection();
                frmcolors.ShowDialog();
                GameData.RunningColor = frmcolors.SelectedColor;
                frmcolors.Dispose();
            }
        }

        private static void CheckpointPlayerWin()
        {
            if (GameData.Player.Cards.Count == 0)
            {
                Game.Over = true;

                GameData.OpponentScore = 0;
                foreach (Card card in GameData.Opponnent.Cards)
                {
                    GameData.OpponentScore += Tools.GetPoint(card);
                }
                CalculateTotalScore();

                //////////////////////////////////////////////////////////////////////////
                //Painter.ShowOpponentCards();
                //////////////////////////////////////////////////////////////////////////

                MessageBox.Show("You win by " + GameData.OpponentScore + "!!", "Wow!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static bool CanThrow(Card card)
        {
            var valid = false;

            var topCard = GameData.OpenCards.LastCard();

            if (topCard != null)
            {
                if (GameData.RunningColor == UnoColours.NoColor ||
                    GameData.RunningColor == card.Color
                    || topCard.Number == card.Number
                    || card.Color == UnoColours.NoColor)
                {
                    valid = true;
                }
            }

            return valid;
        }

        private static void PutDownCardOfPlayer(Card nextCard)
        {
            GameData.Player.Cards.Remove(nextCard);

            Animate.Move(nextCard,
                        GameData.LocPlayer.Left, GameData.LocPlayer.Top,
                        GameData.LocBoard.Left + (GameData.LocBoard.Width - CardImagesResources.CardImageList[nextCard.ImageListOffset].Width) / 2, GameData.LocBoard.Top);

            GameData.OpenCards.Add(nextCard);

            GameData.FlagDirty = true;
        }

        public static void AddCardToPlayer()
        {
            if (!GameData.Deck.IsDeckEmpty())
            {
                Animate.Move(GameData.BackFacingCard,
                            new Point(GameData.LocSlot.Location.X + (GameData.LocSlot.Width - CardImagesResources.CardImageList[GameData.BackFacingCard.ImageListOffset].Width) / 2,
                                                     GameData.LocSlot.Location.Y),
                            GameData.LocPlayer.Location);

                GameData.Player.AddCard(GameData.Deck.GetACard());
            }
            else
            {
                ReloadDeckFromOpenCards();
                //    else
                //    {
                //        System.Windows.Forms.MessageBox.Show("I am confused now!\r\nPlease contact the developer!!", "Err..",
                //                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                //    }
            }

            GameData.FlagDirty = true;
        }

        //////////////////////////////////////////////////////////////////////////
    }
}
