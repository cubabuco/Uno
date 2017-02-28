using System.Collections;

namespace Uno
{
    class OpenDeck : ArrayList
    {
        public void Add(Card c)
        {
            base.Add(c);
            GameData.RunningColor = c.Color;
        }

        public override void Clear()
        {
            base.Clear();
            GameData.Form.lblColorRunning.Text = "";
        }

        //public string GetDeck()
        //{
        //    string cards_debug = "";
        //    foreach (Card card in this)
        //    {
        //        cards_debug += card.ToString() + "\r\n";
        //    }
        //    return cards_debug;
        //}

        public Cards GetCards()
        {
            var cards = new Cards();
            foreach (Card card in this)
            {
                cards.Add(card);
            }
            return cards;
        }

        public new Card this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return (Card)(base[index]);
                }
                return null;
            }
        }

        public Card LastCard()
        {
            if (Count > 0)
            {
                return (Card)(base[Count - 1]);
            }
            return null;
        }

    }
}
