namespace GameEngine
{
    public class Item
    {
        public int X { get; set; } // Add 'set' accessor to make X writable
        public int Y { get; set; } // Add 'set' accessor to make Y writable
        public bool Collected { get; set; }

        public Item(int x, int y)
        {
            X = x;
            Y = y;
            Collected = false;
        }
    }
}
