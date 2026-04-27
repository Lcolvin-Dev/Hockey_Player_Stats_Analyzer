namespace HockeyPlayerStatsAnalyzer_Final_Lamonte
{
    public static class PlayerRepository
    {
        public static List<Player> LoadPlayers(string filePath)
        {
            if (!File.Exists(filePath))
            {
                CreateStarterFile(filePath);
            }

            List<Player> players = new List<Player>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length == 8)
                {
                    Player player = new Player();
                    player.FirstName = parts[0];
                    player.LastName = parts[1];
                    player.Team = parts[2];
                    player.Position = parts[3];
                    player.GamesPlayed = int.Parse(parts[4]);
                    player.Goals = int.Parse(parts[5]);
                    player.Assists = int.Parse(parts[6]);
                    player.ShotsOnGoal = int.Parse(parts[7]);
                    players.Add(player);
                }
            }

            return players;
        }

        public static void SavePlayers(string filePath, List<Player> players)
        {
            List<string> lines = new List<string>();

            foreach (Player player in players)
            {
                lines.Add(player.ToFileString());
            }

            File.WriteAllLines(filePath, lines);
        }

        private static void CreateStarterFile(string filePath)
        {
            string[] starterPlayers =
            {
                "Connor|McDavid|EDM|Center|82|64|89|352",
                "Auston|Matthews|TOR|Center|74|60|47|326",
                "Nathan|MacKinnon|COL|Center|82|51|89|405",
                "David|Pastrnak|BOS|Right Wing|82|47|63|382",
                "Cale|Makar|COL|Defense|77|21|69|231"
            };

            File.WriteAllLines(filePath, starterPlayers);
        }
    }
}
