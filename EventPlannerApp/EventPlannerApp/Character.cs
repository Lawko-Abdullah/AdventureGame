using System;
using System.Collections.Generic;

namespace EventPlannerApp
{
    public class Character
    {
        public int Health { get; private set; }
        public int Shield { get; private set; }
        public int Armor { get; private set; }
        private List<string> Inventory { get; set; }

        private static Random random = new Random();

        public Character()
        {
            Health = 100;
            Shield = 50;
            Armor = 0; // Assuming armor is a separate attribute that can be upgraded
            Inventory = new List<string>();
        }

        public int NormalAttack()
        {
            return 10; // Fixed damage for normal attack
        }

        public int SuperAttack()
        {
            return random.Next(10, 100); // Random damage between 10 and 99
        }

        public void DisplayArmor()
        {
            Console.WriteLine($"Armor: {Armor}");
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("  Inventory is empty.");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"  - {item}");
                }
            }
        }

        public void AddToInventory(string item)
        {
            Inventory.Add(item);
        }
    }
}