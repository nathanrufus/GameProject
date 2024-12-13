using System;

namespace Utilities
{
    public static class Randomizer
    {
        private static Random random = new Random();

        public static (int X, int Y) GeneratePosition()
        {
            return (random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight));
        }
    }
}
