/*******************************************************************
 * Name: Princess Ellis
 * Date: 10/26/2025
 * Assignment: Week 3 Calculator Project – Arrays, Lists & Memory
 *
 * Description:
 * This program expands the Calculator Project to include memory
 * features using arrays and Lists. It allows the user to:
 *  - Store, retrieve, replace, and clear a single memory value
 *  - Manage a collection of up to 10 integer values
 *  - Display all stored integers and collection statistics
 *  - Continue running until the user chooses to quit
 * The design follows modular principles and builds on prior phases.
 *******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

public class MemoryManager
{
    private double? singleMemory = null;        // single numeric value
    private List<int> memoryList = new List<int>(); // list to hold up to 10 integers

    // ----- Single Value Memory -----
    public void StoreSingleValue(double value)
    {
        singleMemory = value;
        Console.WriteLine($"Value {value} stored in memory.");
    }

    public void RetrieveSingleValue()
    {
        if (singleMemory.HasValue)
            Console.WriteLine($"Stored value: {singleMemory}");
        else
            Console.WriteLine("No value currently stored in memory.");
    }

    public void ReplaceSingleValue(double value)
    {
        if (singleMemory.HasValue)
        {
            singleMemory = value;
            Console.WriteLine($"Memory value replaced with {value}.");
        }
        else
        {
            Console.WriteLine("No existing value found. Storing new value instead.");
            singleMemory = value;
        }
    }

    public void ClearSingleValue()
    {
        singleMemory = null;
        Console.WriteLine("Single memory value cleared.");
    }

    // ----- Collection Memory -----
    public void AddToCollection(int value)
    {
        if (memoryList.Count < 10)
        {
            memoryList.Add(value);
            Console.WriteLine($"Value {value} added to collection.");
        }
        else
            Console.WriteLine("Collection is full. Remove an item before adding a new one.");
    }

    public void RemoveFromCollection(int value)
    {
        if (memoryList.Remove(value))
            Console.WriteLine($"Value {value} removed from collection.");
        else
            Console.WriteLine("Value not found in collection.");
    }

    public void DisplayCollection()
    {
        if (memoryList.Count == 0)
        {
            Console.WriteLine("No values stored in collection.");
            return;
        }

        Console.WriteLine("\nIndex\tValue");
        for (int i = 0; i < memoryList.Count; i++)
        {
            Console.WriteLine($"{i}\t{memoryList[i]}");
        }
    }

    public void DisplayCollectionStats()
    {
        if (memoryList.Count == 0)
        {
            Console.WriteLine("No values to calculate statistics.");
            return;
        }

        int count = memoryList.Count;
        int sum = memoryList.Sum();
        double avg = memoryList.Average();
        int diff = memoryList.Last() - memoryList.First();

        Console.WriteLine($"\nCollection Statistics:");
        Console.WriteLine($"Count: {count}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {avg:F2}");
        Console.WriteLine($"Difference (Last - First): {diff}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MemoryManager memory = new MemoryManager();
        bool running = true;

        Console.WriteLine("\nPrincess Ellis - Week 3 Calculator Project: Arrays, Lists & Memory\n");
        Console.WriteLine("Welcome! This calculator memory manager allows you to work with a single\n" +
                          "stored value and a collection of up to 10 integers.\n");

        while (running)
        {
            Console.WriteLine("\n======= MAIN MENU =======");
            Console.WriteLine("1. Store single value");
            Console.WriteLine("2. Retrieve single value");
            Console.WriteLine("3. Replace single value");
            Console.WriteLine("4. Clear single value");
            Console.WriteLine("5. Add integer to collection");
            Console.WriteLine("6. Remove integer from collection");
            Console.WriteLine("7. Display all collection values");
            Console.WriteLine("8. Display collection statistics");
            Console.WriteLine("9. Quit");
            Console.Write("Select an option (1-9): ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter a value to store: ");
                    if (double.TryParse(Console.ReadLine(), out double sVal))
                        memory.StoreSingleValue(sVal);
                    else
                        Console.WriteLine("Invalid number.");
                    break;

                case "2":
                    memory.RetrieveSingleValue();
                    break;

                case "3":
                    Console.Write("Enter new value: ");
                    if (double.TryParse(Console.ReadLine(), out double rVal))
                        memory.ReplaceSingleValue(rVal);
                    else
                        Console.WriteLine("Invalid number.");
                    break;

                case "4":
                    memory.ClearSingleValue();
                    break;

                case "5":
                    Console.Write("Enter an integer to add: ");
                    if (int.TryParse(Console.ReadLine(), out int addVal))
                        memory.AddToCollection(addVal);
                    else
                        Console.WriteLine("Invalid integer.");
                    break;

                case "6":
                    Console.Write("Enter an integer to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int remVal))
                        memory.RemoveFromCollection(remVal);
                    else
                        Console.WriteLine("Invalid integer.");
                    break;

                case "7":
                    memory.DisplayCollection();
                    break;

                case "8":
                    memory.DisplayCollectionStats();
                    break;

                case "9":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the calculator memory application!");
    }
}
