using System.Collections;

namespace Uno
{
    //A sorted list of cards by number and grouped by the color
    class Cards : ArrayList
    {
        //Adds the card sorted by the number and grouped by the color
        public void Add(Card card)
        {
            var pos = GetFirstPositionOfColor(card);
            if (pos == -1)
            {
                base.Add(card);
            }
            else
            {
                pos = GetPositionByNumberGroupedByColor(card, pos);
                if (pos == Count)
                {
                    base.Add(card);
                }
                else
                {
                    Insert(pos, card);
                }
            }

        }

        private int GetFirstPositionOfColor(Card card)
        {
            var found = false;
            var pos = 0;
            foreach (Card c in this)
            {
                if (c.Color == card.Color)
                {
                    found = true;
                    break;
                }
                pos++;
            }
            if (found)
                return pos;
            return -1;
        }

        private int GetPositionByNumberGroupedByColor(Card card, int startIndex)
        {
            var pos = startIndex;
            for (var index = startIndex; index < Count; index++)
            {
                if (this[index].Color == card.Color)
                {
                    if (this[index].Number < card.Number)
                    {
                        pos++;
                    }
                }
                else
                {
                    break;
                }
            }
            return pos;
        }

        new public Card this[int index]
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
