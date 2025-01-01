using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
    class Painter
    {
        private static bool _isPainting;

        /// <summary>
        /// Paints the whole game board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void PaintCards(object sender, PaintEventArgs e)
        {
            if (_isPainting)
            {
                return;
            }

            _isPainting = true;
            {
                //resizing done here
                //Tools.CalculateCardRegions();

                //////////////////////////////////////////////////////////////////////////            

                if (GameData.OpenCards.Count > 0)
                    PaintSourceDeck(sender, e);
                else
                    PaintSourceDeckEmpty(sender, e);

                PaintOpponent(sender, e);
                PaintPlayer(sender, e);
                PaintOpenBoard(sender, e);
            }

            _isPainting = false;
        }

        /// <summary>
        /// Paints the deck from where the cards will be picked up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PaintSourceDeck(object sender, PaintEventArgs e)
        {
            var img = Tools.ResizedImage(CardImagesResources.CardImageList[GameData.BackFacingCard.ImageListOffset], GameData.LocSlot.Width, GameData.LocSlot.Height);

            var destRect = new Rectangle(GameData.LocSlot.Left, GameData.LocSlot.Top, img.Width, img.Height);
            destRect.Offset((GameData.LocSlot.Width - img.Width) / 2, (GameData.LocSlot.Height - img.Height) / 2);

            e.Graphics.DrawImage(img, destRect);
        }

        /// <summary>
        /// Paints the deck as empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PaintSourceDeckEmpty(object sender, PaintEventArgs e)
        {
            var r = GameData.LocSlot;
            r.Inflate(1, 1);

            var brush = new SolidBrush(GameData.Form.tableLayoutPanel.BackColor);
            e.Graphics.FillRectangle(brush, r);
        }

        /// <summary>
        /// Paints the opponent's cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PaintOpponent(object sender, PaintEventArgs e)
        {
            var gPanel = e.Graphics;

            if (GameData.Opponnent.Cards.Count > 0)
            {
                var img = Tools.ResizedImage(CardImagesResources.CardImageList[GameData.BackFacingCard.ImageListOffset], GameData.LocOpponent.Width, GameData.LocOpponent.Height);

                var overlappedWidth = img.Width / GameData.OverLappedRegionWidthRatio;

                var destRect = new Rectangle(GameData.LocOpponent.Left, GameData.LocOpponent.Top, img.Width, img.Height);
                for (var i = 0; i < GameData.Opponnent.Cards.Count; ++i)
                {
                    gPanel.DrawImage(img, destRect);
                    destRect.Offset(overlappedWidth, 0);
                }
            }
        }

        private static void _showOpponentCards(object sender, PaintEventArgs e)
        {
            var gPanel = e.Graphics;

            if (GameData.Opponnent.Cards.Count > 0)
            {
                var img = Tools.ResizedImage(CardImagesResources.CardImageList[GameData.BackFacingCard.ImageListOffset], GameData.LocOpponent.Width, GameData.LocOpponent.Height);

                var overlappedWidth = img.Width / GameData.OverLappedRegionWidthRatio;

                var destRect = new Rectangle(GameData.LocOpponent.Left, GameData.LocOpponent.Top, img.Width, img.Height);
                for (var i = 0; i < GameData.Opponnent.Cards.Count; ++i)
                {
                    var localImg = Tools.ResizedImage(CardImagesResources.CardImageList[GameData.Opponnent.Cards[i].ImageListOffset],
                                                        GameData.LocOpponent.Width, GameData.LocOpponent.Height);
                    gPanel.DrawImage(localImg, destRect);
                    destRect.Offset(overlappedWidth, 0);
                }
            }
        }

    /// <summary>
        /// Paints the player's cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PaintPlayer(object sender, PaintEventArgs e)
        {
            var gPanel = e.Graphics;

            if (GameData.Player.Cards.Count > 0)
            {
                var img = Tools.ResizedImage(CardImagesResources.CardImageList[GameData.BackFacingCard.ImageListOffset], GameData.LocPlayer.Width, GameData.LocPlayer.Height);

                var overlappedWidth = img.Width / GameData.OverLappedRegionWidthRatio;

                var destRect = new Rectangle(GameData.LocPlayer.Left, GameData.LocPlayer.Top, img.Width, img.Height);
                for (var i = 0; i < GameData.Player.Cards.Count; ++i)
                {
                    var localImg = Tools.ResizedImage(CardImagesResources.CardImageList[GameData.Player.Cards[i].ImageListOffset], GameData.LocPlayer.Width, GameData.LocPlayer.Height);
                    gPanel.DrawImage(localImg, destRect);
                    destRect.Offset(overlappedWidth, 0);
                }
            }
        }

        /// <summary>
        /// Paints the board where the cards are thrown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PaintOpenBoard(object sender, PaintEventArgs e)
        {
            if (GameData.OpenCards.Count > 0)
            {
                var card = GameData.OpenCards[GameData.OpenCards.Count - 1];

                var img = Tools.ResizedImage(CardImagesResources.CardImageList[card.ImageListOffset], GameData.LocBoard.Width, GameData.LocBoard.Height);

                var destRect = new Rectangle(GameData.LocBoard.Left, GameData.LocBoard.Top, img.Width, img.Height);
                destRect.Offset((GameData.LocBoard.Width - img.Width) / 2, (GameData.LocBoard.Height - img.Height) / 2);

                e.Graphics.DrawImage(img, destRect);
            }
        }
        
        //////////////////////////////////////////////////////////////////////////
        
    }
}
