using System;

namespace GameEngine
{
    public class Player
    {
        public int X { get; set; } // Add 'set' accessor to make X writable
        public int Y { get; set; } // Add 'set' accessor to make Y writable

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveUp()
        {
            Y--; // Reduce Y to move up
        }

        public void MoveDown()
        {
            Y++; // Increase Y to move down
        }

        public void MoveLeft()
        {
            X--; // Reduce X to move left
        }

        public void MoveRight()
        {
            X++; // Increase X to move right
        }
    }
}
