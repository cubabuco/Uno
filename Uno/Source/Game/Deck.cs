using System;
using System.Collections;

namespace Uno
{
    class Deck : ArrayList
    {
        public void CreateDeck()
        {
            BuildDeck();
        }

        public void SetCards(Cards cards)
        {
            foreach(Card card in cards)
            {
                Add(card);
            }
        }

        private void BuildDeck()
        {
            // ------------- Merging two set of decks into one

            AddOnePack();
            AddOnePack();
        }

        private void AddOnePack()
        {
            var imageListOffset = 1;
            var color = 0;

            // 2 "+4" cards
            Add(new Card(UnoCards.DrawFour, imageListOffset, (UnoColours)(color)));
            Add(new Card(UnoCards.DrawFour, imageListOffset++, (UnoColours)(color)));

            //2 Wild
            Add(new Card(UnoCards.WildCard, imageListOffset, (UnoColours)(color)));
            Add(new Card(UnoCards.WildCard, imageListOffset++, (UnoColours)(color++)));


            //blue color
            Add(new Card(UnoCards.Plus2, imageListOffset++, (UnoColours)(color))); //"+2"
            Add(new Card(UnoCards.Skip, imageListOffset++, (UnoColours)(color)));//skip
            Add(new Card(UnoCards.Reverse, imageListOffset++, (UnoColours)(color)));//Reverse

            Add(new Card(UnoCards.Zero, imageListOffset++, (UnoColours)(color))); //0
            Add(new Card(UnoCards.One, imageListOffset++, (UnoColours)(color)));    //1
            Add(new Card(UnoCards.Two, imageListOffset++, (UnoColours)(color)));  //2
            Add(new Card(UnoCards.Three, imageListOffset++, (UnoColours)(color)));//3
            Add(new Card(UnoCards.Four, imageListOffset++, (UnoColours)(color)));      //4
            Add(new Card(UnoCards.Five, imageListOffset++, (UnoColours)(color)));       //5
            Add(new Card(UnoCards.Six, imageListOffset++, (UnoColours)(color)));    //6
            Add(new Card(UnoCards.Seven, imageListOffset++, (UnoColours)(color)));    //7
            Add(new Card(UnoCards.Eight, imageListOffset++, (UnoColours)(color)));       //8
            Add(new Card(UnoCards.Nine, imageListOffset++, (UnoColours)(color++)));      //9

            //green color
            Add(new Card(UnoCards.Plus2, imageListOffset++, (UnoColours)(color))); //"+2"
            Add(new Card(UnoCards.Skip, imageListOffset++, (UnoColours)(color)));//skip
            Add(new Card(UnoCards.Reverse, imageListOffset++, (UnoColours)(color)));//Reverse

            Add(new Card(UnoCards.Zero, imageListOffset++, (UnoColours)(color))); //0
            Add(new Card(UnoCards.One, imageListOffset++, (UnoColours)(color)));    //1
            Add(new Card(UnoCards.Two, imageListOffset++, (UnoColours)(color)));  //2
            Add(new Card(UnoCards.Three, imageListOffset++, (UnoColours)(color)));//3
            Add(new Card(UnoCards.Four, imageListOffset++, (UnoColours)(color)));      //4
            Add(new Card(UnoCards.Five, imageListOffset++, (UnoColours)(color)));       //5
            Add(new Card(UnoCards.Six, imageListOffset++, (UnoColours)(color)));    //6
            Add(new Card(UnoCards.Seven, imageListOffset++, (UnoColours)(color)));    //7
            Add(new Card(UnoCards.Eight, imageListOffset++, (UnoColours)(color)));       //8
            Add(new Card(UnoCards.Nine, imageListOffset++, (UnoColours)(color++)));      //9

            //red color
            Add(new Card(UnoCards.Plus2, imageListOffset++, (UnoColours)(color))); //"+2"
            Add(new Card(UnoCards.Skip, imageListOffset++, (UnoColours)(color)));//skip
            Add(new Card(UnoCards.Reverse, imageListOffset++, (UnoColours)(color)));//Reverse

            Add(new Card(UnoCards.Zero, imageListOffset++, (UnoColours)(color))); //0
            Add(new Card(UnoCards.One, imageListOffset++, (UnoColours)(color)));    //1
            Add(new Card(UnoCards.Two, imageListOffset++, (UnoColours)(color)));  //2
            Add(new Card(UnoCards.Three, imageListOffset++, (UnoColours)(color)));//3
            Add(new Card(UnoCards.Four, imageListOffset++, (UnoColours)(color)));      //4
            Add(new Card(UnoCards.Five, imageListOffset++, (UnoColours)(color)));       //5
            Add(new Card(UnoCards.Six, imageListOffset++, (UnoColours)(color)));    //6
            Add(new Card(UnoCards.Seven, imageListOffset++, (UnoColours)(color)));    //7
            Add(new Card(UnoCards.Eight, imageListOffset++, (UnoColours)(color)));       //8
            Add(new Card(UnoCards.Nine, imageListOffset++, (UnoColours)(color++)));      //9


            //yellow color
            Add(new Card(UnoCards.Plus2, imageListOffset++, (UnoColours)(color))); //"+2"
            Add(new Card(UnoCards.Skip, imageListOffset++, (UnoColours)(color)));//skip
            Add(new Card(UnoCards.Reverse, imageListOffset++, (UnoColours)(color)));//Reverse

            Add(new Card(UnoCards.Zero, imageListOffset++, (UnoColours)(color))); //0
            Add(new Card(UnoCards.One, imageListOffset++, (UnoColours)(color)));    //1
            Add(new Card(UnoCards.Two, imageListOffset++, (UnoColours)(color)));  //2
            Add(new Card(UnoCards.Three, imageListOffset++, (UnoColours)(color)));//3
            Add(new Card(UnoCards.Four, imageListOffset++, (UnoColours)(color)));      //4
            Add(new Card(UnoCards.Five, imageListOffset++, (UnoColours)(color)));       //5
            Add(new Card(UnoCards.Six, imageListOffset++, (UnoColours)(color)));    //6
            Add(new Card(UnoCards.Seven, imageListOffset++, (UnoColours)(color)));    //7
            Add(new Card(UnoCards.Eight, imageListOffset++, (UnoColours)(color)));       //8
            Add(new Card(UnoCards.Nine, imageListOffset++, (UnoColours)(color++)));      //9
        }

        public void Shuffle()
        {
            var rand = Tools.GetRandomObject();
            for (var i = 0; i < Count; i++)
            {
                var oldPlace = rand.Next(Count);
                var newPlace = rand.Next(Count);

                //swap places
                var tempCard = this[oldPlace];
                base[oldPlace] = base[newPlace];
                base[newPlace] = tempCard;
            }
        }

        public Card GetACard()
        {
            if (Count <= 0)
            {
                throw new Exception("Deck is empty.");
            }

            var rand = Tools.GetRandomObject();

            var deckPosition = rand.Next(Count);
            var card = this[deckPosition];
            RemoveAt(deckPosition);

            return card;
        }

        public string DebugGetDeck()
        {
            var cardsDebug = "";
            foreach (Card card in this)
            {
                cardsDebug += card + "\r\n";
            }
            return cardsDebug;
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
    }
}
