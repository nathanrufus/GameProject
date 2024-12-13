using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Console Game!");
        Console.WriteLine("Navigate with the arrow keys to collect items (🧀) and avoid hazards (🔥).");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();

        GameEngine.Game game = new GameEngine.Game();
        game.Run();
    }
}
