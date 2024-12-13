using System;

namespace EventPlannerApp
{
    public class Battle
    {
        private Character player;
        private Enemy enemy;

        public Battle(Character player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void StartBattle()
        {
            Console.WriteLine($"A wild {enemy.Name} appears!");
            while (!playerIsDefeated() && !enemy.IsDefeated())
            {
                PlayerTurn();
                if (!enemy.IsDefeated())
                {
                    EnemyTurn();
                }
            }
            DetermineOutcome();
        }

        private void PlayerTurn()
        {
            Console.WriteLine("Choose your action:");
            Console.WriteLine("1. Normal Attack");
            Console.WriteLine("2. Super Attack");
            Console.WriteLine("3. Display Armor");
            Console.WriteLine("4. Display Inventory");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    int normalDamage = player.NormalAttack();
                    enemy.TakeDamage(normalDamage);
                    Console.WriteLine($"You dealt {normalDamage} damage to the {enemy.Name}.");
                    Console.WriteLine($"You dealt {superDamage} damage to the {enemy.Name}.");
                    break;
                case "2":
                    int superDamage = player.SuperAttack();
                    enemy.TakeDamage(superDamage);
                    break;
                case "3":
                    player.DisplayArmor();
                    break;
                case "4":
                    player.DisplayInventory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    PlayerTurn();
                    break;
            }
        }

        private void EnemyTurn()
        {
            int damage = enemy.Attack();
            ApplyDamageToPlayer(damage);
        }

        private void ApplyDamageToPlayer(int damage)
        {
            if (player.Shield > 0)
            {
                if (damage <= player.Shield)
                {
                    player.Shield -= damage;
                }
                else
                {
                    damage -= player.Shield;
                    player.Shield = 0;
                    player.Health -= damage;
                }
            }
            else
            {
                player.Health -= damage;
            }

            if (player.Health < 0) player.Health = 0;
            Console.WriteLine($"Player takes {damage} damage and now has {player.Health} health and {player.Shield} shield.");
        }

        private bool playerIsDefeated()
        {
            return player.Health <= 0;
        }

        private void DetermineOutcome()
        {
            if (playerIsDefeated())
            {
                Console.WriteLine("You have been defeated!");
            }
            else if (enemy.IsDefeated())
            {
                Console.WriteLine($"You have defeated the {enemy.Name}!");
            }
        }
    }
}