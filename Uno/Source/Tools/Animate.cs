using System;
using System.Drawing;
using System.Windows.Forms;

namespace Uno
{
    class Animate
    {
        private const int Step = 30;

        private static Card _card;
        private static Rectangle _destRect;
        private static Image _cardImage;
        private static int _stepX, _stepY, _dx;
        private static Graphics _graphicsTable;
        private static Bitmap _layoutBackBmp;

        private static bool _animationFnished = true;


        public static void Move(Card card, Point source, Point dest)
        {
            Move(card, source.X, source.Y, dest.X, dest.Y);
        }

        public static void Move(Card card, Control source, Control dest)
        {
            Move(card, source.Left, source.Top, dest.Left, dest.Top);
        }

        public static void Move(Card card, int sourceX, int sourceY, int destX, int destY)
        {
            PreAnimate(card, sourceX, sourceY, destX, destY);
            DoAnimate();
            PostAnimate();
        }

        /// <summary>
        /// Sets the data useful for animation
        /// </summary>
        /// <param name="card"></param>
        /// <param name="sourceX"></param>
        /// <param name="sourceY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        private static void PreAnimate(Card card, int sourceX, int sourceY, int destX, int destY)
        {
            //set the card
            _card = card;

            //////////////////////////////////////////////////////////////////////////

            //take assembly backup of the screen
            _layoutBackBmp = new Bitmap(GameData.Form.tableLayoutPanel.ClientRectangle.Width,
                                        GameData.Form.tableLayoutPanel.ClientRectangle.Height);
            GameData.Form.tableLayoutPanel.DrawToBitmap(_layoutBackBmp,
                                                    GameData.Form.tableLayoutPanel.ClientRectangle);

            //////////////////////////////////////////////////////////////////////////

            //get the resized image of the card
            if (_cardImage != null)
            {
                _cardImage.Dispose();
                _cardImage = null;
            }

            _cardImage = Tools.ResizedImage(CardImagesResources.CardImageList[_card.ImageListOffset], GameData.LocSlot.Width, GameData.LocSlot.Height);

            //////////////////////////////////////////////////////////////////////////

            // calculate the 'm', distance and the stepping on X & Y axis
            //y = (x - x1) * m + y1;

            //Calculate the distance - here it can be negative
            _dx = destX - sourceX;

            //Calculate the slope
            var m = (double)(destY - sourceY) / _dx;

            //Stepping on X axis
            _stepX = (_dx > 0 ? Step : -Step);
            if (Math.Abs(_dx) < Step) _stepX = _dx;

            //Stepping on Y axis
            _stepY = (int)(Step * m);

            //Take the distance in positive term.
            _dx = Math.Abs(_dx);

            //////////////////////////////////////////////////////////////////////////
            _destRect = new Rectangle(sourceX, sourceY, _cardImage.Width, _cardImage.Height);

            if (_graphicsTable != null)
            {
                _graphicsTable.Dispose();
                _graphicsTable = null;
            }

            _graphicsTable = GameData.Form.tableLayoutPanel.CreateGraphics();

            //////////////////////////////////////////////////////////////////////////
            _animationFnished = false;
        }

        /// <summary>
        /// Animation routine.
        /// </summary>
        private static void DoAnimate()
        {
            while (!_animationFnished)
            {
                var tempBmp = new Bitmap(_layoutBackBmp);
                var graphicsBmp = Graphics.FromImage(tempBmp);

                //paint onto the screen the new image
                graphicsBmp.DrawImage(_cardImage, _destRect);

                //////////////////////////////////////////////////////////////////////////

                //move to new location
                _destRect.Offset(_stepX, _stepY);

                _dx -= Step;
                if (_dx < Step)
                {
                    _animationFnished = true;
                }

                //////////////////////////////////////////////////////////////////////////

                //finally, paint the whole picture
                _graphicsTable.DrawImage(tempBmp, 0, 0);

            } //while
        }

        /// <summary>
        /// Cleans up after the animation is over
        /// </summary>
        private static void PostAnimate()
        {   
            if (_graphicsTable != null)
            {
                _graphicsTable.Dispose();
                _graphicsTable = null;
            }
        }
    }
}
