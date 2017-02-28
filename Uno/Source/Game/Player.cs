namespace Uno
{
    class Player
    {
        public Cards Cards = new Cards();

        public void AddCard(Card c)
        {
            Cards.Add(c);
        }

        public void Clear()
        {
            Cards.Clear();
        }
    }
}
