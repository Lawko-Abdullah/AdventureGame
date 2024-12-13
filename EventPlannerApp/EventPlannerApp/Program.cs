using System;
using System.Collections.Generic;
using System.IO;

namespace EventPlannerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Event Planner App and Battle Game!");
            List<Event> events = new List<Event>();

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("(1) Add Event");
                Console.WriteLine("(2) View Events");
                Console.WriteLine("(3) Start Battle");
                Console.WriteLine("(4) View Character Stats");
                Console.WriteLine("(5) Check Inventory");
                Console.WriteLine("(6) Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEvent(events);
                        break;
                    case "2":
                        ViewEvents(events);
                        break;
                    case "3":
                        StartBattle();
                        break;
                    case "4":
                        ViewCharacterStats();
                        break;
                    case "5":
                        CheckInventory();
                        break;
                    case "6":
                        isRunning = false;
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddEvent(List<Event> events)
        {
            Console.WriteLine("Enter event name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter event date (yyyy-mm-dd):");
            string dateInput = Console.ReadLine();
            DateTime date;
            if (!DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                return;
            }

            Event newEvent = new Event(name, date);
            events.Add(newEvent);
            Console.WriteLine("Event added successfully!");

            // Logging statement
            Console.WriteLine($"[LOG] Event added: {newEvent.Name} on {newEvent.Date}");
        }

        static void ViewEvents(List<Event> events)
        {
            Console.WriteLine("Upcoming Events:");
            foreach (var ev in events)
            {
                Console.WriteLine($"{ev.Name} on {ev.Date.ToShortDateString()}");
            }

            // Logging statement
            Console.WriteLine($"[LOG] Viewed {events.Count} events.");
        }
        static void StartBattle()
        {
            Character player = new Character();
            Enemy enemy = new Goblin(); // Example enemy, can be changed to Orc or Dragon
            Battle battle = new Battle(player, enemy);
            battle.StartBattle();
        }

        static void ViewCharacterStats()
        {
            Character player = new Character();
            Console.WriteLine("Character Stats:");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Shield: {player.Shield}");
            player.DisplayArmor();
        }

        static void CheckInventory()
        {
            Character player = new Character();
            Console.WriteLine("Inventory:");
            player.DisplayInventory();
        }
    }

    class Event
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public Event(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
}