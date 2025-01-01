using System;
using System.Drawing;

namespace Uno
{

    class GameData
    {
        public static Player Player = new Player();
        public static Player Opponnent = new Player();

        public static UnoDeck Deck = new UnoDeck();
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
    }
}
