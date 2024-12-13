using System;

namespace EventPlannerApp
{
    public class Enemy
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private int AttackPower { get; set; }
        private static Random random = new Random();

        public Enemy(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public int Attack()
        {
            // Simulate an attack with a random factor
            int damage = random.Next(AttackPower - 5, AttackPower + 5);
            Console.WriteLine($"{Name} attacks and deals {damage} damage!");
            return damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} takes {damage} damage and now has {Health} health.");
        }

        public bool IsDefeated()
        {
            return Health <= 0;
        }
    }

    public class Goblin : Enemy
    {
        public Goblin() : base("Goblin", 50, 10)
        {
        }
    }

    public class Orc : Enemy
    {
        public Orc() : base("Orc", 80, 15)
        {
        }
    }

    public class Dragon : Enemy
    {
        public Dragon() : base("Dragon", 150, 25)
        {
        }
    }
}