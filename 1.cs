using System;
using System.Collections.Generic;

namespace TextBasedSurvivalGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Text-Based Survival Game!");
            Console.WriteLine("You find yourself stranded in a wilderness. Your goal is to survive.");

            // Initialize player stats
            int health = 100;
            int hunger = 0;
            int thirst = 0;
            int mentalHealth = 100;

            // Initialize resources
            int food = 0;
            int water = 0;
            int wood = 0;
            int stone = 0;

            // Game loop
            while (true)
            {
                // Display player status
                Console.WriteLine();
                Console.WriteLine($"Health: {health} | Hunger: {hunger} | Thirst: {thirst} | Mental Health: {mentalHealth}");
                Console.WriteLine($"Food: {food} | Water: {water} | Wood: {wood} | Stone: {stone}");
                Console.WriteLine();

                // Display options
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Gather resources");
                Console.WriteLine("2. Hunt for food");
                Console.WriteLine("3. Build shelter");
                Console.WriteLine("4. Rest");
                Console.WriteLine("5. Quit");

                // Get player choice
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Process player choice
                switch (choice)
                {
                    case "1":
                        // Gather resources
                        GatherResources(ref wood, ref stone);
                        break;
                    case "2":
                        // Hunt for food
                        HuntForFood(ref food);
                        break;
                    case "3":
                        // Build shelter
                        BuildShelter(ref wood, ref stone);
                        break;
                    case "4":
                        // Rest
                        Rest(ref health, ref hunger, ref thirst, ref mentalHealth);
                        break;
                    case "5":
                        // Quit the game
                        Console.WriteLine("Exiting the game. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }

                // Check if player's health, hunger, thirst, or mental health drop to critical levels
                CheckPlayerStatus(ref health, ref hunger, ref thirst, ref mentalHealth);
            }
        }

        // Method to gather wood and stone
        static void GatherResources(ref int wood, ref int stone)
        {
            Console.WriteLine("You start gathering wood and stone.");
            // Simulate gathering resources
            wood += 2;
            stone += 1;
            Console.WriteLine("You gathered 2 wood and 1 stone.");
        }

        // Method to hunt for food
        static void HuntForFood(ref int food)
        {
            Console.WriteLine("You go hunting for food.");
            // Simulate hunting for food
            Random rand = new Random();
            int foodFound = rand.Next(1, 4); // Randomly find between 1 to 3 food items
            food += foodFound;
            Console.WriteLine($"You found {foodFound} food.");
        }

        // Method to build shelter using wood and stone
        static void BuildShelter(ref int wood, ref int stone)
        {
            Console.WriteLine("You start building a shelter.");
            // Check if enough resources to build shelter
            if (wood >= 3 && stone >= 2)
            {
                wood -= 3;
                stone -= 2;
                Console.WriteLine("You built a shelter.");
            }
            else
            {
                Console.WriteLine("You don't have enough resources to build a shelter.");
            }
        }

        // Method to rest and replenish health, hunger, thirst, and mental health
        static void Rest(ref int health, ref int hunger, ref int thirst, ref int mentalHealth)
        {
            Console.WriteLine("You rest and regain your strength.");
            // Simulate resting and replenishing stats
            health += 10;
            hunger += 5;
            thirst += 5;
            mentalHealth += 10;

            // Cap stats at maximum values
            if (health > 100) health = 100;
            if (hunger > 100) hunger = 100;
            if (thirst > 100) thirst = 100;
            if (mentalHealth > 100) mentalHealth = 100;

            Console.WriteLine("You feel refreshed.");
        }

        // Method to check player's health, hunger, thirst, and mental health status
        static void CheckPlayerStatus(ref int health, ref int hunger, ref int thirst, ref int mentalHealth)
        {
            // Check if any of the stats drop to critical levels
            if (health <= 0 || hunger >= 100 || thirst >= 100 || mentalHealth <= 0)
            {
                Console.WriteLine("Game over. You failed to survive.");
                Environment.Exit(0);
            }
        }
    }
}
