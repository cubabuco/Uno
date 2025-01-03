using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;

namespace Uno
{
    class Tools
    {
        private static Timer _timer = new Timer();
        static long _start;

        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        //Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6,
        //Seven = 7, Eight = 8, Nine = 9,
        //Plus2 = 20, Skip = 20, Reverse = 20,
        //WildCard = 50, DrawTwo = 50, DrawFour = 50
        public static int GetPoint(Card card)
        {
            if(card.Number > UnoCards.Zero && card.Number <= UnoCards.Nine)
                return card.Number - UnoCards.Zero;
            if(card.Number > UnoCards.Nine && card.Number < UnoCards.WildCard)
                return 20;
            if(card.Number >= UnoCards.WildCard && card.Number <= UnoCards.DrawFour)
                return 50;

            return 0;
        }

        public static Size BestFitSize(Size origSize, Size newSize)
        {
            int w = origSize.Width, h = origSize.Height;

            if (w > newSize.Width || h > newSize.Height) //resizing required
            {
                //if pic is too huge..
                if (w > newSize.Width && h > newSize.Height)
                {
                    var r1 = (double)w / newSize.Width;
                    var r2 = (double)h / newSize.Height;
                    if (r1 > r2)
                    {
                        h = (h * newSize.Width) / w;
                        w = newSize.Width;
                    }
                    if (r1 <= r2)
                    {
                        w = (w * newSize.Height) / h;
                        h = newSize.Height;
                    }
                }
                else if (w > newSize.Width)
                {
                    h = (h * newSize.Width) / w;
                    w = newSize.Width;
                }

                else //(h > newSize.Height)
                {
                    w = (w * newSize.Height) / h;
                    h = newSize.Height;
                }

                return new Size(w, h);
            }

            return origSize;
        }

        /// <summary>
        /// Resizes the image according to the new dimension
        /// </summary>
        /// <param name="img"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ResizedImage(Image img, int width, int height)
        {
            var fitSize = BestFitSize(img.Size, new Size(width, height));
            return new Bitmap(img, fitSize);
        }

        /// <summary>
        /// Calculates the dimensions of the 4 places where the cards are shown on the screen.
        /// </summary>
        public static void CalculateCardRegions()
        {
            Logger.FuncInit("Tools.CalculateCardRegions");
            if (GameData.Form != null)
            {
                var colStyles = GameData.Form.tableLayoutPanel.ColumnStyles;
                var rowStyles = GameData.Form.tableLayoutPanel.RowStyles;

                //////////////////////////////////////////////////////////////////////////            

                var width = (int)(colStyles[1].Width * GameData.Form.tableLayoutPanel.ClientRectangle.Width / 100.0f);
                var height = (int)(rowStyles[0].Height * GameData.Form.tableLayoutPanel.ClientRectangle.Height / 100.0f);

                GameData.LocOpponent.Location = new Point(GameData.Form.tableLayoutPanel.ClientRectangle.Width - width, 0);
                GameData.LocOpponent.Width = width;
                GameData.LocOpponent.Height = height;

                //////////////////////////////////////////////////////////////////////////

                height = (int)(rowStyles[0].Height * GameData.Form.tableLayoutPanel.ClientRectangle.Height / 100.0f);

                GameData.LocBoard.Location = new Point(GameData.Form.tableLayoutPanel.ClientRectangle.Width - width,
                                       GameData.LocOpponent.Height);
                GameData.LocBoard.Width = width;
                GameData.LocBoard.Height = height;

                //////////////////////////////////////////////////////////////////////////
                height = (int)(rowStyles[2].Height * GameData.Form.tableLayoutPanel.ClientRectangle.Height / 100.0f);

                GameData.LocPlayer.Location = new Point(GameData.Form.tableLayoutPanel.ClientRectangle.Width - width, GameData.Form.tableLayoutPanel.ClientRectangle.Height - height);
                GameData.LocPlayer.Width = width;
                GameData.LocPlayer.Height = height;

                //////////////////////////////////////////////////////////////////////////

                width = (int)(colStyles[0].Width * GameData.Form.tableLayoutPanel.ClientRectangle.Width / 100.0f);
                height = (int)(rowStyles[1].Height * GameData.Form.tableLayoutPanel.ClientRectangle.Height / 100.0f);

                GameData.LocSlot.Location = new Point(0, GameData.LocOpponent.Height);
                GameData.LocSlot.Width = width;
                GameData.LocSlot.Height = height;
            }

            Logger.FuncExit("Tools.CalculateCardRegions");
        }

        public static Card[] GetBiggestCard(Cards cards)
        {
            if (cards == null || cards.Count == 0)
                return new Card[0];

            Card biggestCard = cards[0];

            foreach (Card card in cards)
            {
                if (card.Number > biggestCard.Number)
                {
                    biggestCard = card;
                }
            }

            return new[] { biggestCard };
        }

        public static Random GetRandomObject()
        {
            var seed = (int)(DateTime.Now.Ticks ^ int.MaxValue);
            var rand = new Random(seed);
            return rand;
        }

        public static void FlashError()
        {
            _timer.Interval = 500;
            _timer.Tick += timer_Tick;
            _start = DateTime.Now.Ticks;
            _timer.Start();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            var current = DateTime.Now.Ticks;
            if ((current - _start)/10000000L > 2)
            {
                _timer.Stop();
                _timer.Tick -= timer_Tick;
            }
            FlashWindow(GameData.Form.Handle, true);
        }
        //////////////////////////////////////////////////////////////////////////        
    }
}
