namespace HockeyPlayerStatsAnalyzer_Final_Lamonte
{
    public static class InputValidator
    {
        public static int GetInteger(string prompt, int minimum)
        {
            int value;
            bool validInput = false;

            do
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= minimum)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a whole number greater than or equal to " + minimum + ".");
                }

            } while (!validInput);

            return value;
        }

        public static string GetRequiredString(string prompt)
        {
            string value = "";

            do
            {
                Console.Write(prompt);
                value = Console.ReadLine() ?? "";
                value = value.Trim();

                if (value == "")
                {
                    Console.WriteLine("Invalid input. This field cannot be blank.");
                }

            } while (value == "");

            return value;
        }
    }
}
