using System;

namespace TicTacToeMinimax
{
    public class TicTacToeGame
    {
        private const int BOARD_SIZE = 3;
        private string[,] board;
        private string currentPlayer;
        private string currentPlayerName;

        public string Status { get; private set; }

        public TicTacToeGame(string playerNameTextBox)
        {
            currentPlayerName = playerNameTextBox;
            board = new string[BOARD_SIZE, BOARD_SIZE];
            Reset();
        }

        public void Reset()
        {
            currentPlayer = "X";
            Status = $"{currentPlayerName}'s turn";
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = "";
                }
            }
        }

        public bool IsOccupied(int row, int col)
        {
            return board[row, col] != "";
        }

        public bool IsGameOver(out string result)
        {
            if (CheckWin("X"))
            {
                result = $"{currentPlayerName} wins!";
                return true;
            }
            else if (CheckWin("O"))
            {
                result = "Computer wins!";
                return true;
            }
            else if (IsBoardFull())
            {
                result = "It's a draw!";
                return true;
            }
            else
            {
                result = "";
                return false;
            }
        }
        public string GetMarkAt(int row, int col)
        {
            return board[row, col];
        }

        public void MakeMove(int row, int col)
        {
            try
            {
                if (!IsOccupied(row, col))
                {
                    board[row, col] = currentPlayer;
                    TogglePlayer();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error : on MakeMove - TicTacToeGame : " + ex.Message);
            }
        }

        public void MakeComputerMove()
        {
            try
            {
                int bestScore = int.MinValue;
                int bestRow = -1;
                int bestCol = -1;

                for (int i = 0; i < BOARD_SIZE; i++)
                {
                    for (int j = 0; j < BOARD_SIZE; j++)
                    {
                        if (board[i, j] == "")
                        {
                            board[i, j] = "O";
                            int score = Minimax(board, "X");
                            board[i, j] = "";

                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestRow = i;
                                bestCol = j;
                            }
                        }
                    }
                }

                MakeMove(bestRow, bestCol);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : on MakeComputerMove - TicTacToeGame : " + ex.Message);
            }


        }

        private int Minimax(string[,] board, string player)
        {
            if (CheckWin("X"))
                return -1;
            else if (CheckWin("O"))
                return 1;
            else if (IsBoardFull())
                return 0;

            int bestScore = (player == "O") ? int.MinValue : int.MaxValue;

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j] == "")
                    {
                        board[i, j] = player;
                        if (player == "O")
                            bestScore = Math.Max(bestScore, Minimax(board, "X"));
                        else
                            bestScore = Math.Min(bestScore, Minimax(board, "O"));
                        board[i, j] = "";
                    }
                }
            }

            return bestScore;
        }


        private bool CheckWin(string player)
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                    return true;

                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                    return true;
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;

            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j] == "")
                        return false;
                }
            }
            return true;
        }

        private void TogglePlayer()
        {
            currentPlayer = (currentPlayer == "X") ? "O" : "X";
            Status = (currentPlayer == currentPlayerName) ? $"{currentPlayerName}'s turn" : "Computer's turn";
        }
    }


}
