using System;
using Spectre.Console;
using Figgle;
using System.Drawing;

namespace AdventureGameRepo
{
    public class UserInterface
    {
        private bool isRunning;

        public UserInterface()
        {
            isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                DisplayMainMenu();
                HandleUserInput();
            }
        }

        private void DisplayMainMenu()
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Adventure Game").Centered().Color(Color.Cyan1));
            AnsiConsole.Write(
                new Panel("[bold]Main Menu[/]")
                    .Expand()
                    .BorderColor(Color.Green)
                    .Header("[yellow]Choose an option[/]")
                    .HeaderAlignment(Justify.Center)
            );

            AnsiConsole.MarkupLine("[bold](1)[/] Start Game");
            AnsiConsole.MarkupLine("[bold](2)[/] Exit");
        }

        private void HandleUserInput()
        {
            var choice = Console.ReadKey(true).Key;
            switch (choice)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    StartGame();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Exit();
                    break;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid choice. Please try again.[/]");
                    break;
            }
        }

        private void StartGame()
        {
            AnsiConsole.MarkupLine("[green]Starting the game...[/]");
            // Here you would integrate with the Game class to start the game logic
            // For example: new Game().Start();
        }

        private void Exit()
        {
            AnsiConsole.MarkupLine("[yellow]Exiting the game. Goodbye![/]");
            isRunning = false;
        }
    }
}
