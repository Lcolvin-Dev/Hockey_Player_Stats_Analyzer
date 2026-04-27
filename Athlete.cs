namespace HockeyPlayerStatsAnalyzer_Final_Lamonte
{
    public class Athlete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }

        public Athlete()
        {
            FirstName = "";
            LastName = "";
            Team = "";
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
