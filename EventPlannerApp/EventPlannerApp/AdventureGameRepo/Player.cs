using System;

namespace AdventureGameRepo
{
    // Interface defining common player actions
    public interface IPlayerActions
    {
        void Attack();
        void Defend();
        void UseAbility();
    }

    // Generic Player class implementing IPlayerActions
    public class Player<T> : IPlayerActions where T : IPlayerActions, new()
    {
        public string Name { get; private set; }
        public T PlayerType { get; private set; }

        public Player(string name)
        {
            Name = name;
            PlayerType = new T();
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} attacks!");
            PlayerType.Attack();
        }

        public void Defend()
        {
            Console.WriteLine($"{Name} defends!");
            PlayerType.Defend();
        }

        public void UseAbility()
        {
            Console.WriteLine($"{Name} uses a special ability!");
            PlayerType.UseAbility();
        }
    }

    // Warrior class implementing IPlayerActions
    public class Warrior : IPlayerActions
    {
        public void Attack()
        {
            Console.WriteLine("Warrior swings a mighty sword!");
        }

        public void Defend()
        {
            Console.WriteLine("Warrior raises a shield!");
        }

        public void UseAbility()
        {
            Console.WriteLine("Warrior uses Berserk Rage!");
        }
    }

    // Mage class implementing IPlayerActions
    public class Mage : IPlayerActions
    {
        public void Attack()
        {
            Console.WriteLine("Mage casts a fireball!");
        }

        public void Defend()
        {
            Console.WriteLine("Mage conjures a magical barrier!");
        }

        public void UseAbility()
        {
            Console.WriteLine("Mage uses Arcane Blast!");
        }
    }
}
