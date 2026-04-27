namespace HockeyPlayerStatsAnalyzer_Final_Lamonte
{
    public class Player : Athlete
    {
        public string Position { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int ShotsOnGoal { get; set; }

        public Player()
        {
            Position = "";
        }

        public int GetTotalPoints()
        {
            return Goals + Assists;
        }

        public double GetPointsPerGame()
        {
            if (GamesPlayed == 0)
                return 0;

            return (double)GetTotalPoints() / GamesPlayed;
        }

        public double GetGoalsPerGame()
        {
            if (GamesPlayed == 0)
                return 0;

            return (double)Goals / GamesPlayed;
        }

        public double GetShootingPercentage()
        {
            if (ShotsOnGoal == 0)
                return 0;

            return (double)Goals / ShotsOnGoal * 100;
        }

        public string ToFileString()
        {
            return FirstName + "|" + LastName + "|" + Team + "|" + Position + "|" + GamesPlayed + "|" + Goals + "|" + Assists + "|" + ShotsOnGoal;
        }
    }
}
