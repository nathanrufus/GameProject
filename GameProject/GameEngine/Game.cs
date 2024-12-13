using System;
using System.Collections.Generic;
using System.Threading;
using Utilities;

namespace GameEngine
{
    public class Game
    {
        private Player player;
        private List<Item> items;
        private List<Hazard> hazards;
        private int score = 0;
        private int lives = 3;
        private int timeLeft = 30; // Game duration in seconds
        private bool running = true;

        private int FrameWidth;  // Dynamic frame width
        private int FrameHeight; // Dynamic frame height

        public Game()
        {
            // Dynamically set frame dimensions based on console size
            FrameWidth = Console.WindowWidth;
            FrameHeight = Console.WindowHeight - 2; // Reserve space for score and timer

            // Ensure player starts inside the frame
            player = new Player(2, 2);

            // Generate items and hazards within the frame
            items = LevelManager.GenerateItems(5, FrameWidth, FrameHeight);
            hazards = LevelManager.GenerateHazards(3, FrameWidth, FrameHeight);
        }

       public void Run()
{
    Console.Clear();
    Console.CursorVisible = false;

    // Draw the static frame once
    DrawFrame();

    // Start the timer thread
    Thread timerThread = new Thread(Timer);
    timerThread.Start();

    // Main game loop
    while (running)
    {
        Update();
        Draw(); // Only update dynamic elements
        Thread.Sleep(100); // Game updates every 100ms
    }

    Console.Clear();
    Console.WriteLine("Game Over!");
    Console.WriteLine($"Final Score: {score}");
}

        private void Timer()
        {
            while (timeLeft > 0 && running)
            {
                timeLeft--;
                Thread.Sleep(1000); // Reduce time every second
            }

            if (timeLeft == 0)
            {
                running = false;
                Console.Clear();
                Console.WriteLine("Time's up! Game Over!");
                Console.WriteLine($"Final Score: {score}");
            }
        }

        private void Update()
        {
            // Handle player input
            InputHandler.HandleInput(player);

            // Prevent player from leaving the frame
            player.X = Math.Clamp(player.X, 1, FrameWidth - 2);
            player.Y = Math.Clamp(player.Y, 1, FrameHeight - 2);

            // Check item collisions
            foreach (var item in items)
            {
                if (!item.Collected && player.X == item.X && player.Y == item.Y)
                {
                    item.Collected = true;
                    score += 10; // Increase score
                }
            }

            // Check hazard collisions
            foreach (var hazard in hazards)
            {
                if (player.X == hazard.X && player.Y == hazard.Y)
                {
                    lives--; // Decrease lives
                    if (lives <= 0)
                    {
                        running = false; // End game
                    }
                }
            }

            // Move hazards randomly
            foreach (var hazard in hazards)
            {
                hazard.MoveRandomly(FrameWidth, FrameHeight);
            }
        }

        private void Draw()
        {
            Console.Clear();

            // Draw the frame
            DrawFrame();

            // Display score, lives, and time
            Console.SetCursorPosition(0, FrameHeight + 1); // Position below the frame
            Console.WriteLine($"Score: {score}  Lives: {lives}  Time Left: {timeLeft}s");

            // Draw items
            foreach (var item in items)
            {
                if (!item.Collected)
                {
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.Write("🧀"); // Cheese
                }
            }

            // Draw hazards
            foreach (var hazard in hazards)
            {
                Console.SetCursorPosition(hazard.X, hazard.Y);
                Console.Write("🔥"); // Fire
            }

            // Draw player
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write("🧍"); // Player
        }

        private void DrawFrame()
        {
            // Draw top and bottom borders
            for (int x = 0; x < FrameWidth; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#"); // Top border
                Console.SetCursorPosition(x, FrameHeight - 1);
                Console.Write("#"); // Bottom border
            }

            // Draw left and right borders
            for (int y = 0; y < FrameHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#"); // Left border
                Console.SetCursorPosition(FrameWidth - 1, y);
                Console.Write("#"); // Right border
            }
        }
    }
}
