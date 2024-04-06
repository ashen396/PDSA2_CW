using System;
using System.Data.SqlClient;

namespace TicTacToeMinimax
{
    public class DatabaseManager
    {
        private readonly string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void UpdatePlayerStatistics(string playerName, int playerWins, int computerWins, int draws, int totalRounds)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "IF EXISTS (SELECT 1 FROM PlayerStatistics WHERE PlayerName = @PlayerName) " +
                                   "UPDATE PlayerStatistics SET PlayerWins = @PlayerWins, ComputerWins = @ComputerWins, " +
                                   "Draws = @Draws, TotalRounds = @TotalRounds WHERE PlayerName = @PlayerName " +
                                   "ELSE " +
                                   "INSERT INTO PlayerStatistics (PlayerName, PlayerWins, ComputerWins, Draws, TotalRounds) " +
                                   "VALUES (@PlayerName, @PlayerWins, @ComputerWins, @Draws, @TotalRounds)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PlayerName", playerName);
                    command.Parameters.AddWithValue("@PlayerWins", playerWins);
                    command.Parameters.AddWithValue("@ComputerWins", computerWins);
                    command.Parameters.AddWithValue("@Draws", draws);
                    command.Parameters.AddWithValue("@TotalRounds", totalRounds);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : Updating/inserting player statistics: " + ex.Message);
            }
        }
    }
}
