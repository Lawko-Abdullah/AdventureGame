using System;

namespace AdventureGameRepo
{
    // Base class for game events
    public abstract class GameEvent
    {
        public string EventName { get; protected set; }

        public GameEvent(string eventName)
        {
            EventName = eventName;
        }

        // Method to process the event
        public abstract void ProcessEvent();
    }

    // Class for handling battle events
    public class BattleEvent : GameEvent
    {
        public BattleEvent() : base("Battle Event")
        {
        }

        public override void ProcessEvent()
        {
            try
            {
                Console.WriteLine($"Processing {EventName}...");
                // Simulate battle logic
                Console.WriteLine("Battle between players is happening...");
                // Example of potential exception
                if (new Random().Next(0, 2) == 0)
                {
                    throw new Exception("An error occurred during the battle!");
                }
                Console.WriteLine("Battle concluded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {EventName}: {ex.Message}");
            }
        }
    }

    // Class for handling story events
    public class StoryEvent : GameEvent
    {
        public StoryEvent() : base("Story Event")
        {
        }

        public override void ProcessEvent()
        {
            try
            {
                Console.WriteLine($"Processing {EventName}...");
                // Simulate story logic
                Console.WriteLine("Story unfolds with intriguing events...");
                // Example of potential exception
                if (new Random().Next(0, 2) == 0)
                {
                    throw new Exception("An error occurred during the story event!");
                }
                Console.WriteLine("Story event completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {EventName}: {ex.Message}");
            }
        }
    }
}
