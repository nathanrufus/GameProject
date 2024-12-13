using System;

namespace GameEngine
{
    public class Hazard
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private Random random = new Random();

        public Hazard(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveRandomly(int frameWidth, int frameHeight)
{
    int newX = X + random.Next(-1, 2); // Move left, stay, or right
    int newY = Y + random.Next(-1, 2); // Move up, stay, or down

    // Ensure hazards stay within bounds
    X = Math.Clamp(newX, 1, frameWidth - 2);
    Y = Math.Clamp(newY, 1, frameHeight - 2);
}

    }
}
