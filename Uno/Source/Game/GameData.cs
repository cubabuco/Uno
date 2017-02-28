using System;
using System.Collections.Generic;
using System.Drawing;

namespace Uno
{
    class GameData
    {
        //public static string[] CardImageList = new String[55];
        public static Dictionary<int, Image> CardImageList = new Dictionary<int, Image>(55);

        public static Player Player = new Player();
        public static Player Opponnent = new Player();

        public static Deck Deck = new Deck();
        public static OpenDeck OpenCards = new OpenDeck();

        public static Card BackFacingCard;
        public static FrmUno Form;

        private static int _totalPlayerScore;
        public static int TotalPlayerScore
        {
            get
            {
                return _totalPlayerScore;
            }
            set
            {
                _totalPlayerScore = value;
                Form.lblPlayerScore.Text = _totalPlayerScore.ToString();
            }
        }

        private static int _totalOpponentScore;
        public static int TotalOpponentScore
        {
            get
            {
                return _totalOpponentScore;
            }
            set
            {
                _totalOpponentScore = value;
                Form.lblOpponentScore.Text = _totalOpponentScore.ToString();
            }
        }

        public static int PlayerScore = 0;
        public static int OpponentScore = 0;

        public static string PlayerName = string.Empty;

        public static bool FlagDirty = true;

        public static Rectangle LocOpponent = new Rectangle();
        public static Rectangle LocPlayer = new Rectangle();
        public static Rectangle LocBoard = new Rectangle();
        public static Rectangle LocSlot = new Rectangle();

        public const int OverLappedRegionWidthRatio = 4;

        private static UnoColours _runningColor = UnoColours.NoColor;

        public static UnoColours RunningColor
        {
            get
            {
                return _runningColor;
            }

            set
            {
                _runningColor = value;

                if (_runningColor == UnoColours.NoColor)
                {
                    Form.lblColorRunning.Text = "Any color";
                }
                else
                {
                    Form.lblColorRunning.Text = _runningColor.ToString();
                }
            }
        }


        public static void InitData(FrmUno frm)
        {
            Logger.FuncInit("GameData.InitData");

            Form = frm;

            ReadConfig();

            Logger.Write(LoggingLevel.LogDebug, "form = " + Form + " ; NULL? " + (Form == null? "yes": "no"));

            BuildImageList();
            BackFacingCard = new Card(UnoCards.Back, 0, UnoColours.NoColor);

            Logger.FuncInit("GameData.InitData");
        }

        private static void ReadConfig()
        {
            Logger.FuncInit("GameData.readConfig");
            if (Form.Args.Length > 0)
            {
                var commandLine = new Arguments(Form.Args);

                if (commandLine["debug"] != null)
                {
                    var v = Convert.ToInt32(commandLine["debug"]);
                    if (!(v < LoggingLevel.LogGeneral || v > LoggingLevel.LogDebug))
                    {
                        Data.LogLevel = v;
                    }
                    else
                    {
                        Data.LogLevel = LoggingLevel.LogGeneral;
                    }
                }
                else
                {
                    Data.LogLevel = LoggingLevel.LogGeneral;
                }
            }
            else
            {
                Data.LogLevel = LoggingLevel.LogGeneral;
            }
            Logger.Write(LoggingLevel.LogGeneral, "The log level set is = " + Data.LogLevel);
            Logger.FuncExit("GameData.readConfig");
        }

        private static void BuildImageList()
        {
            using (var imageHelper = new ImageHelpers())
            {
                var i = 0;
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.back.png")); //0

                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.+4.png")); //1

                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.wild.png")); //2


                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.+2b.png"));  //3
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.skipb.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.revb.png"));

                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.0b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.1b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.2b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.3b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.4b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.5b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.6b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.7b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.8b.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.9b.png")); //15


                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.+2g.png")); //16
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.skipg.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.revg.png"));

                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.0g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.1g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.2g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.3g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.4g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.5g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.6g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.7g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.8g.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.9g.png")); //28


                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.+2r.png")); //29
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.skipr.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.revr.png"));

                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.0r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.1r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.2r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.3r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.4r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.5r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.6r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.7r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.8r.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.9r.png")); //41


                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.+2y.png")); //42
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.skipy.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.revy.png"));

                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.0y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.1y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.2y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.3y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.4y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.5y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.6y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.7y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.8y.png"));
                CardImageList.Add(i++, imageHelper.LoadEmbededImage("Uno.Images.9y.png")); //54
            }
        }
    }
}
