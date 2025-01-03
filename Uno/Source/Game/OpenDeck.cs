using System.Collections;

namespace Uno
{
    class OpenDeck : ArrayList
    {
        public OpenDeck() : base(108) { }

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

        public Card[] LastCard()
        {
            if (Count > 0)
            {
                return new[] { (Card)(base[Count - 1]) };
            }
            return new Card[0];
        }

    }
}
