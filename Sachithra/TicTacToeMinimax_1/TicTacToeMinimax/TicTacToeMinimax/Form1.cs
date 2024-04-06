using Microsoft.IdentityModel.Tokens;
using System.Media;

namespace TicTacToeMinimax
{
    public partial class Form1 : Form
    {
        private Button[,] buttons;
        private TicTacToeGame game;
        private DatabaseManager tictactoedb;
        private string playerName;
        private int playerWins = 0;
        private int computerWins = 0;
        private int draws = 0;

        public Form1()
        {

            InitializeComponent();
            try
            {

                    playerName = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name:", "Player Name", "");
                    InitializeGame();
                    UpdateStatisticsLabels("");

                    button1.Tag = 0;
                    button2.Tag = 1;
                    button3.Tag = 2;
                    button4.Tag = 3;
                    button5.Tag = 4;
                    button6.Tag = 5;
                    button7.Tag = 6;
                    button8.Tag = 7;
                    button9.Tag = 8;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : on Form1 - Form1 : " + ex.Message);
            }
        }

        private void InitializeGame()
        {
            playerNameTextBox.Text = playerName.ToString();
            buttons = new Button[3, 3] { { button1, button2, button3 },
                                          { button4, button5, button6 },
                                          { button7, button8, button9 } };

            game = new TicTacToeGame(playerNameTextBox.Text);
            tictactoedb = new DatabaseManager("Data Source=DESKTOP-02G3JA8\\MSSQLSERVER01;Initial Catalog=TicTacToe;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = game.GetMarkAt(i, j);
                }
            }

            label2.Text = game.Status;
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!playerNameTextBox.Text.IsNullOrEmpty())
                {
                    Button button = (Button)sender;
                    int row = (int)button.Tag / 3;
                    int col = (int)button.Tag % 3;

                    if (game.IsOccupied(row, col) || game.IsGameOver(out string result))
                    {
                        return;
                    }

                    game.MakeMove(row, col);
                    UpdateBoard();

                    if (game.IsGameOver(out result))
                    {
                        label2.Text = "";
                        UpdateStatisticsLabels(result);
                        MessageBox.Show(result);
                        InitializeGame();
                        return;
                    }

                    game.MakeComputerMove();
                    UpdateBoard();

                    if (game.IsGameOver(out result))
                    {
                        label2.Text = "";
                        UpdateStatisticsLabels(result);
                        MessageBox.Show(result);
                        InitializeGame();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("You Need to Enter a Player Name to Play the Game");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : on button_Click - Form1 : " + ex.Message);
            }
        }

        private void UpdateStatisticsLabels(string result)
        {
            try
            {
                if (result == $"{playerNameTextBox.Text} wins!") { playerWins++; }
                else if (result == "Computer wins!") { computerWins++; }
                else if (result == "It's a draw!") { draws++; }
                else { }
                labelWins.Text = $"{playerNameTextBox.Text} Wins: {playerWins}";
                labelLosses.Text = $"Computer Wins: {computerWins}";
                labelDraws.Text = $"Draws: {draws}";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : on UpdateStatisticsLabels - Form1 : " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRounds = (playerWins + computerWins + draws);
                tictactoedb.UpdatePlayerStatistics(playerNameTextBox.Text, playerWins, computerWins, draws, totalRounds);
                playerWins = 0;
                computerWins = 0;
                draws = 0;
                label2.Text = "";
                playerNameTextBox.Text = "";
                UpdateStatisticsLabels("");
                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : on close_Click - Form1 : " + ex.Message);
            }


        }

        private void newGame_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRounds = (playerWins + computerWins + draws);
                tictactoedb.UpdatePlayerStatistics(playerNameTextBox.Text, playerWins, computerWins, draws, totalRounds);
                playerWins = 0;
                computerWins = 0;
                draws = 0;
                playerName = null;
                label2.Text = "";
                playerNameTextBox.Text = "";
                UpdateStatisticsLabels("");
                playerName = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name:", "Player Name", "");
                playerNameTextBox.Text = playerName;
                InitializeGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : on newGame_Click - Form1 : " + ex.Message);
            }

        }
    }
}