# Hockey_Player_Stats_Analyzer
This project was developed to demonstrate data processing, analytical thinking, and programming logic using real world sports data.

This C# console application allows a user to view hockey players, add new players, update player statistics, and view calculated stat reports.

Main features:
1. Loads player data from players.txt.
2. Displays all players in a formatted table.
3. Adds new players with validation.
4. Updates player statistics with validation.
5. Calculates total points, points per game, goals per game, and shooting percentage.
6. Saves player data back to players.txt when exiting.

OOP features included:
- Athlete base class
- Player class inherits from Athlete
- PlayerRepository class handles file loading and saving
- InputValidator class handles reusable input validation
- Player methods calculate statistics


*Testing Checklist*
1. Application Startup
- Open the solution in Visual Studio.
- Run the program.
- Confirm the main menu appears.

2. View All Players
- Select option 1.
- Confirm sample players display in columns.
- Confirm goals, assists, and points are displayed.

3. Add New Player
Successful test:
- First name: Johnny
- Last name: Hockey
- Team: CBJ
- Position: Center
- Games played: 10
- Goals: 5
- Assists: 7
- Shots on goal: 40
Expected result:
- Player is added successfully.
- Player appears in View All Players.

Invalid input tests:
- Blank first name should show an invalid input message.
- Negative games played should show an invalid input message.
- Non-number goals should show an invalid input message.

4. Update Player Stats
Successful test:
- Select an existing player.
- Enter games played: 20
- Goals: 8
- Assists: 12
- Shots on goal: 60
Expected result:
- Player stats update successfully.

Invalid input tests:
- Player number greater than the list count should show invalid player number.
- Negative stat values should not be accepted.
- Text entered for numeric values should not be accepted.

5. Player Report Calculation Tests
Test values:
- Games played: 10
- Goals: 5
- Assists: 7
- Shots on goal: 40
Expected calculations:
- Total points = 12
- Points per game = 1.20
- Goals per game = 0.50
- Shooting percentage = 12.50%

6. Save and Exit
- Select option 5.
- Restart the program.
- Confirm added or updated players are still present.

Desired behavior:
- Program should not crash when bad input is entered.
- Program should continue asking until valid input is provided.
- Calculations should display to two decimal places where appropriate.
- Data should be saved in players.txt so the projec
