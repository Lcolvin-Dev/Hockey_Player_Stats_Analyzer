namespace HockeyPlayerStatsAnalyzer_Final_Lamonte
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "players.txt";
            List<Player> players = PlayerRepository.LoadPlayers(filePath);
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("     Hockey Player Stats Analyzer");
                Console.WriteLine("========================================");
                Console.WriteLine("1. View All Players");
                Console.WriteLine("2. Add New Player");
                Console.WriteLine("3. Update Player Stats");
                Console.WriteLine("4. View Player Report");
                Console.WriteLine("5. Save and Exit");
                Console.Write("Select an option: ");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    ViewAllPlayers(players);
                }
                else if (choice == "2")
                {
                    AddPlayer(players);
                }
                else if (choice == "3")
                {
                    UpdatePlayer(players);
                }
                else if (choice == "4")
                {
                    ViewPlayerReport(players);
                }
                else if (choice == "5")
                {
                    PlayerRepository.SavePlayers(filePath, players);
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid menu option. Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }

        static void ViewAllPlayers(List<Player> players)
        {
            Console.Clear();
            Console.WriteLine("All Players");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4}{1,-22}{2,-10}{3,-14}{4,6}{5,7}{6,8}{7,8}", "#", "Name", "Team", "Position", "GP", "Goals", "Assists", "Points");
            Console.WriteLine("--------------------------------------------------------------------------------");

            for (int i = 0; i < players.Count; i++)
            {
                Player p = players[i];
                Console.WriteLine("{0,-4}{1,-22}{2,-10}{3,-14}{4,6}{5,7}{6,8}{7,8}",
                    i + 1, p.GetFullName(), p.Team, p.Position, p.GamesPlayed, p.Goals, p.Assists, p.GetTotalPoints());
            }

            Pause();
        }

        static void AddPlayer(List<Player> players)
        {
            Console.Clear();
            Console.WriteLine("Add New Player");
            Console.WriteLine("--------------");

            Player player = new Player();
            player.FirstName = InputValidator.GetRequiredString("First name: ");
            player.LastName = InputValidator.GetRequiredString("Last name: ");
            player.Team = InputValidator.GetRequiredString("Team: ");
            player.Position = InputValidator.GetRequiredString("Position: ");
            player.GamesPlayed = InputValidator.GetInteger("Games played: ", 0);
            player.Goals = InputValidator.GetInteger("Goals: ", 0);
            player.Assists = InputValidator.GetInteger("Assists: ", 0);
            player.ShotsOnGoal = InputValidator.GetInteger("Shots on goal: ", 0);

            players.Add(player);
            Console.WriteLine("Player added successfully.");
            Pause();
        }

        static void UpdatePlayer(List<Player> players)
        {
            Console.Clear();
            Console.WriteLine("Update Player Stats");
            Console.WriteLine("-------------------");
            DisplayPlayerChoices(players);

            int selection = InputValidator.GetInteger("Select player number: ", 1);

            if (selection > players.Count)
            {
                Console.WriteLine("Invalid player number.");
                Pause();
                return;
            }

            Player player = players[selection - 1];
            Console.WriteLine("Updating stats for " + player.GetFullName());
            player.GamesPlayed = InputValidator.GetInteger("Games played: ", 0);
            player.Goals = InputValidator.GetInteger("Goals: ", 0);
            player.Assists = InputValidator.GetInteger("Assists: ", 0);
            player.ShotsOnGoal = InputValidator.GetInteger("Shots on goal: ", 0);

            Console.WriteLine("Player stats updated successfully.");
            Pause();
        }

        static void ViewPlayerReport(List<Player> players)
        {
            Console.Clear();
            Console.WriteLine("Player Report");
            Console.WriteLine("-------------");
            DisplayPlayerChoices(players);

            int selection = InputValidator.GetInteger("Select player number: ", 1);

            if (selection > players.Count)
            {
                Console.WriteLine("Invalid player number.");
                Pause();
                return;
            }

            Player player = players[selection - 1];

            Console.Clear();
            Console.WriteLine("Player Report");
            Console.WriteLine("-------------");
            Console.WriteLine("Name: " + player.GetFullName());
            Console.WriteLine("Team: " + player.Team);
            Console.WriteLine("Position: " + player.Position);
            Console.WriteLine("Games Played: " + player.GamesPlayed.ToString("N0"));
            Console.WriteLine("Goals: " + player.Goals.ToString("N0"));
            Console.WriteLine("Assists: " + player.Assists.ToString("N0"));
            Console.WriteLine("Shots on Goal: " + player.ShotsOnGoal.ToString("N0"));
            Console.WriteLine("Total Points: " + player.GetTotalPoints().ToString("N0"));
            Console.WriteLine("Points Per Game: " + player.GetPointsPerGame().ToString("N2"));
            Console.WriteLine("Goals Per Game: " + player.GetGoalsPerGame().ToString("N2"));
            Console.WriteLine("Shooting Percentage: " + player.GetShootingPercentage().ToString("N2") + "%");

            Pause();
        }

        static void DisplayPlayerChoices(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + players[i].GetFullName() + " - " + players[i].Team);
            }
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
