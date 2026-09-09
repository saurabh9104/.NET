using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Player_Management
{
    internal class MainApp
    {
        static Player[] players = new Player[3];
        static int counter = 3;
        static void Main(string[] args)
        {

            DefaultPlayers();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add player");
                Console.WriteLine("2. Display all players");
                Console.WriteLine("3. Update player ");
                Console.WriteLine("4. Delete player ");
                Console.WriteLine("5. Search player ");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddPlayer();
                        break;
                    case "2":
                        DisplayPlayers();
                        break;
                    case "3":
                        UpdatePlayer();
                        break;
                    case "4":
                        DeletePlayer();
                        break;
                    case "5":
                        SearchPlayer();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                input = Console.ReadLine();
                
            }
        }

        static void DefaultPlayers()
        {
            players[0] = new Player(1, "Rohit sharma", 10, 500, 20);
            players[1] = new Player(2, "virat kohli", 15, 700, 25);
            players[2] = new Player(3, "suresh raina", 20, 1000, 30);
        }
        static void AddPlayer()
        {
            if (counter >= players.Length)
            {
                Array.Resize(ref players, players.Length * 2);
                Console.WriteLine("Player array resized to accommodate more players.");
            }

            Console.Write("Jersey no: ");
            int j = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Name: ");
            string n = Console.ReadLine() ?? string.Empty;

            Console.Write("Matches: ");
            int m = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Runs: ");
            int r = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Wickets: ");
            int w = int.Parse(Console.ReadLine() ?? "0");

            players[counter] = new Player(j, n, m, r, w);
            counter++;

            Console.WriteLine("Player added successfully.");
        }

        static void DisplayPlayers()
        {
            if (counter == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }

            foreach (var p in players)
            {
                if (p != null)
                {
                    Console.WriteLine($"#{p.JerseyNo} {p.Name} - Matches:{p.Match} Runs:{p.Run} Wkts:{p.Wicket}");
                }
            }
        }

        static void UpdatePlayer()
        {
            Console.Write("Enter jersey number to update: ");
            int j = int.Parse(Console.ReadLine() ?? "0");
            
            bool found = false;

            for(int i = 0; i < counter; i++)
            {
                if (players[i].JerseyNo == j)
                {
                    found = true;
                    Console.Write("New name: ");
                    players[i].Name = Console.ReadLine() ?? string.Empty;
                    Console.Write("New matches: ");
                    players[i].Match = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("New runs: ");
                    players[i].Run = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("New wickets: ");
                    players[i].Wicket = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Player updated successfully.");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Player not found.");
            }
        }

        static void DeletePlayer()
        {
            Console.Write("Enter jersey number to delete: ");
            int j = int.Parse(Console.ReadLine() ?? "0");
            
            bool found = false;

            for (int i = 0; i < counter; i++)
            {
                if (players[i].JerseyNo == j)
                {
                    found = true;
                    players[i] = null;
                    Console.WriteLine("Player deleted.");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Player not found.");
            }
        }

        public static void SearchPlayer()
        {

            Console.WriteLine("Search Player by:");
            Console.WriteLine("1. Jersey Number");
            Console.WriteLine("2. Name");
            int choice =int.Parse(Console.ReadLine() ?? "0");
            if(choice == 1)
            {
                SearchByJerseyNumber();
            }
            else if (choice == 2)
            {
                SearchByName();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            void SearchByJerseyNumber()
            {
                Console.Write("Enter jersey number to search: ");
                int j = int.Parse(Console.ReadLine() ?? "0");

                bool found = false;
                for (int i = 0; i < counter; i++)
                {
                    if (players[i].JerseyNo == j)
                    {
                        found = true;
                        Console.WriteLine($"#{players[i].JerseyNo} {players[i].Name} - Matches:{players[i].Match} Runs:{players[i].Run} Wkts:{players[i].Wicket}");
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Player not found.");
                }
            }

            void SearchByName()
            {
                Console.Write("Enter name to search: ");
                string name = Console.ReadLine() ?? string.Empty;

                bool found = false;
                for (int i = 0; i < counter; i++)
                {
                    if (players[i].Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        Console.WriteLine($"#{players[i].JerseyNo} {players[i].Name} - Matches:{players[i].Match} Runs:{players[i].Run} Wkts:{players[i].Wicket}");
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Player not found.");
                }
            }        
        }
    }
}
