namespace Uno
{
    using System.Drawing;

    public class Card
    {
        public UnoCards Number;
        // 0-noColor 1-B 2-G 3-R 4-Y
        public UnoColours Color; 
        // pointer to image in imageList
        public int ImageListOffset; 
        public Image CardImage;

        public Card(UnoCards num, int off, UnoColours col)
        {
            Number = num;
            ImageListOffset = off;
            Color = col;
            CardImage = GameData.CardImageList[off];
        }

        public override string ToString()
        {
            return Number + " of " + Color;
        }
    }
}