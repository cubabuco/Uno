using System;

namespace Uno
{
    class UnoDeck : MyArray<Card>
    {

        private readonly int[] _shuffledFacade = new int[108];
        private int _shufflePointer = 0;

        public UnoDeck() : base(108)
        {
            var deckCounter = 0;
            var doTwice = 0;

            do 
            {
                // 2 "+4" cards
                // 2 "+4" cards
                this[deckCounter++] = new Card(UnoCards.DrawFour, CardImages.draw4, UnoColours.NoColor);
                this[deckCounter++] = (new Card(UnoCards.DrawFour, CardImages.draw4, UnoColours.NoColor));

                //2 Wild
                this[deckCounter++] = new Card(UnoCards.WildCard, CardImages.wild, UnoColours.NoColor);
                this[deckCounter++] = new Card(UnoCards.WildCard, CardImages.wild, UnoColours.NoColor);
                
                //blue 
                this[deckCounter++] = new Card(UnoCards.Plus2, CardImages.draw2b, (UnoColours.Blue)); //"+2"
                this[deckCounter++] = new Card(UnoCards.Skip, CardImages.skipb, (UnoColours.Blue));//skip
                this[deckCounter++] = new Card(UnoCards.Reverse, CardImages.revb, (UnoColours.Blue));//Reverse

                if(doTwice == 0)
                    this[deckCounter++] = new Card(UnoCards.Zero, CardImages.b0, (UnoColours.Blue)); //0

                this[deckCounter++] = new Card(UnoCards.One, CardImages.b1, (UnoColours.Blue));    //1
                this[deckCounter++] = new Card(UnoCards.Two, CardImages.b2, (UnoColours.Blue));  //2
                this[deckCounter++] = new Card(UnoCards.Three, CardImages.b3, (UnoColours.Blue));//3
                this[deckCounter++] = new Card(UnoCards.Four, CardImages.b4, (UnoColours.Blue));      //4
                this[deckCounter++] = new Card(UnoCards.Five, CardImages.b5, (UnoColours.Blue));       //5
                this[deckCounter++] = new Card(UnoCards.Six, CardImages.b6, (UnoColours.Blue));    //6
                this[deckCounter++] = new Card(UnoCards.Seven, CardImages.b7, (UnoColours.Blue));    //7
                this[deckCounter++] = new Card(UnoCards.Eight, CardImages.b8, (UnoColours.Blue));       //8
                this[deckCounter++] = new Card(UnoCards.Nine, CardImages.b9, (UnoColours.Blue));      //9

                //green
                this[deckCounter++] = new Card(UnoCards.Plus2, CardImages.draw2g, (UnoColours.Green)); //"+2"
                this[deckCounter++] = new Card(UnoCards.Skip, CardImages.skipg, (UnoColours.Green));//skip
                this[deckCounter++] = new Card(UnoCards.Reverse, CardImages.revg, (UnoColours.Green));//Reverse

                if (doTwice == 0)
                    this[deckCounter++] = new Card(UnoCards.Zero, CardImages.g0, (UnoColours.Green)); //0

                this[deckCounter++] = new Card(UnoCards.One, CardImages.g1, (UnoColours.Green));    //1
                this[deckCounter++] = new Card(UnoCards.Two, CardImages.g2, (UnoColours.Green));  //2
                this[deckCounter++] = new Card(UnoCards.Three, CardImages.g3, (UnoColours.Green));//3
                this[deckCounter++] = new Card(UnoCards.Four, CardImages.g4, (UnoColours.Green));      //4
                this[deckCounter++] = new Card(UnoCards.Five, CardImages.g5, (UnoColours.Green));       //5
                this[deckCounter++] = new Card(UnoCards.Six, CardImages.g6, (UnoColours.Green));    //6
                this[deckCounter++] = new Card(UnoCards.Seven, CardImages.g7, (UnoColours.Green));    //7
                this[deckCounter++] = new Card(UnoCards.Eight, CardImages.g8, (UnoColours.Green));       //8
                this[deckCounter++] = new Card(UnoCards.Nine, CardImages.g9, (UnoColours.Green));      //9

                //red 
                this[deckCounter++] = new Card(UnoCards.Plus2, CardImages.draw2r, (UnoColours.Red)); //"+2"
                this[deckCounter++] = new Card(UnoCards.Skip, CardImages.skipr, (UnoColours.Red));//skip
                this[deckCounter++] = new Card(UnoCards.Reverse, CardImages.revr, (UnoColours.Red));//Reverse

                if (doTwice == 0)
                    this[deckCounter++] = new Card(UnoCards.Zero, CardImages.r0, (UnoColours.Red)); //0

                this[deckCounter++] = new Card(UnoCards.One, CardImages.r1, (UnoColours.Red));    //1
                this[deckCounter++] = new Card(UnoCards.Two, CardImages.r2, (UnoColours.Red));  //2
                this[deckCounter++] = new Card(UnoCards.Three, CardImages.r3, (UnoColours.Red));//3
                this[deckCounter++] = new Card(UnoCards.Four, CardImages.r4, (UnoColours.Red));      //4
                this[deckCounter++] = new Card(UnoCards.Five, CardImages.r5, (UnoColours.Red));       //5
                this[deckCounter++] = new Card(UnoCards.Six, CardImages.r6, (UnoColours.Red));    //6
                this[deckCounter++] = new Card(UnoCards.Seven, CardImages.r7, (UnoColours.Red));    //7
                this[deckCounter++] = new Card(UnoCards.Eight, CardImages.r8, (UnoColours.Red));       //8
                this[deckCounter++] = new Card(UnoCards.Nine, CardImages.r9, (UnoColours.Red));      //9


                //yellow 
                this[deckCounter++] = new Card(UnoCards.Plus2, CardImages.draw2y, (UnoColours.Yellow)); //"+2"
                this[deckCounter++] = new Card(UnoCards.Skip, CardImages.skipy, (UnoColours.Yellow));//skip
                this[deckCounter++] = new Card(UnoCards.Reverse, CardImages.revy, (UnoColours.Yellow));//Reverse

                if (doTwice == 0)
                    this[deckCounter++] = new Card(UnoCards.Zero, CardImages.y0, (UnoColours.Yellow)); //0

                this[deckCounter++] = new Card(UnoCards.One, CardImages.y1, (UnoColours.Yellow));    //1
                this[deckCounter++] = new Card(UnoCards.Two, CardImages.y2, (UnoColours.Yellow));  //2
                this[deckCounter++] = new Card(UnoCards.Three, CardImages.y3, (UnoColours.Yellow));//3
                this[deckCounter++] = new Card(UnoCards.Four, CardImages.y4, (UnoColours.Yellow));      //4
                this[deckCounter++] = new Card(UnoCards.Five, CardImages.y5, (UnoColours.Yellow));       //5
                this[deckCounter++] = new Card(UnoCards.Six, CardImages.y6, (UnoColours.Yellow));    //6
                this[deckCounter++] = new Card(UnoCards.Seven, CardImages.y7, (UnoColours.Yellow));    //7
                this[deckCounter++] = new Card(UnoCards.Eight, CardImages.y8, (UnoColours.Yellow));       //8
                this[deckCounter++] = new Card(UnoCards.Nine, CardImages.y9, (UnoColours.Yellow));      //9

                doTwice++;
            } while (doTwice < 2);

            for (int i = 0; i < _shuffledFacade.Length; i++)
            {
                _shuffledFacade[i] = i;
            }
        }

        
        public void Shuffle()
        {
            var rand = Tools.GetRandomObject();
            
            for (var i = 0; i < _shuffledFacade.Length; i++)
            {
                var oldPlace = rand.Next(_shuffledFacade.Length);
                var newPlace = rand.Next(_shuffledFacade.Length);

                //swap places
                var tempCard = _shuffledFacade[oldPlace];
                _shuffledFacade[oldPlace] = _shuffledFacade[newPlace];
                _shuffledFacade[newPlace] = tempCard;
            }

            _shufflePointer = 0;
        }

        public bool IsDeckEmpty()
        {
            return _shufflePointer >= _shuffledFacade.Length;
            
        }

        public Card GetACard()
        {
            if (IsDeckEmpty())
            {
                throw new Exception("Deck is empty.");
            }

            return this[_shuffledFacade[_shufflePointer++]];
        }

        
        public string DebugGetDeck()
        {
            var cardsDebug = "";
            foreach (int card in _shuffledFacade)
            {
                cardsDebug += $"{this[card]}\r\n";
            }
            return cardsDebug;
        }
    }
}
