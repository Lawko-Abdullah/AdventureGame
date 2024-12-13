using System;
using System.Collections.Generic;

namespace AdventureGameRepo
{
    public class Game
    {
        private bool isRunning;
        private List<Player> players;

        public Game()
        {
            isRunning = true;
            players = new List<Player>();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Adventure Game!");
            InitializePlayers();
            MainGameLoop();
        }

        private void InitializePlayers()
        {
            // Example of adding players, this could be expanded with more complex logic
            players.Add(new Player("Warrior"));
            players.Add(new Player("Mage"));
        }

        private void MainGameLoop()
        {
            while (isRunning)
            {
                Console.WriteLine("Choose an action: (1) Play (2) Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Play();
                        break;
                    case "2":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void Play()
        {
            Console.WriteLine("Playing the game...");
            // Implement game logic here
            foreach (var player in players)
            {
                Console.WriteLine($"Player {player.Name} is taking action.");
                // Example of player interaction
            }
        }

        private void Exit()
        {
            Console.WriteLine("Exiting the game. Goodbye!");
            isRunning = false;
        }
    }

    public class Player
    {
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        // Additional player methods and properties can be added here
    }
}
