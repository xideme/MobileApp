using System;
using Microsoft.Maui.Controls;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        private bool isPlayerXTurn = true;
        private string[] board = new string[9];  // Track board state

        public MainPage()
        {
            InitializeComponent();
            NewGame(null, null);  // Start with a fresh game
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int index = GetButtonIndex(button);

            // Do not allow a button to be clicked twice
            if (!string.IsNullOrEmpty(board[index])) return;

            // Set the text based on the current player's turn
            board[index] = isPlayerXTurn ? "X" : "O";
            button.Text = board[index];

            // Check if we have a winner
            if (CheckForWinner())
            {
                DisplayAlert("Game Over", $"{board[index]} wins! Play again?", "Yes");
                NewGame(null, null);
            }
            else if (Array.IndexOf(board, null) == -1)  // Check if it's a draw
            {
                DisplayAlert("Game Over", "It's a draw! Play again?", "Yes");
                NewGame(null, null);
            }
            else
            {
                // Change turns
                isPlayerXTurn = !isPlayerXTurn;
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
            // Clear the board
            for (int i = 0; i < 9; i++)
            {
                board[i] = null;
                var button = GetButtonByIndex(i);
                button.Text = string.Empty;
            }

            // Reset first player
            isPlayerXTurn = true;
        }

        private void ChooseFirstPlayer(object sender, EventArgs e)
        {
            // Randomly decide who goes first
            isPlayerXTurn = new Random().Next(0, 2) == 0;
            DisplayAlert("First Player", isPlayerXTurn ? "X goes first!" : "O goes first!", "OK");
        }

        private int GetButtonIndex(Button button)
        {
            return button == Button0 ? 0 :
                   button == Button1 ? 1 :
                   button == Button2 ? 2 :
                   button == Button3 ? 3 :
                   button == Button4 ? 4 :
                   button == Button5 ? 5 :
                   button == Button6 ? 6 :
                   button == Button7 ? 7 : 8;
        }

        private Button GetButtonByIndex(int index)
        {
            return index == 0 ? Button0 :
                   index == 1 ? Button1 :
                   index == 2 ? Button2 :
                   index == 3 ? Button3 :
                   index == 4 ? Button4 :
                   index == 5 ? Button5 :
                   index == 6 ? Button6 :
                   index == 7 ? Button7 : Button8;
        }

        private bool CheckForWinner()
        {
            // Define the win conditions (rows, columns, diagonals)
            int[][] winPatterns = new int[][]
            {
                new[] { 0, 1, 2 },
                new[] { 3, 4, 5 },
                new[] { 6, 7, 8 },
                new[] { 0, 3, 6 },
                new[] { 1, 4, 7 },
                new[] { 2, 5, 8 },
                new[] { 0, 4, 8 },
                new[] { 2, 4, 6 },
            };

            foreach (var pattern in winPatterns)
            {
                if (!string.IsNullOrEmpty(board[pattern[0]]) &&
                    board[pattern[0]] == board[pattern[1]] &&
                    board[pattern[1]] == board[pattern[2]])
                {
                    return true;
                }
            }

            return false;
        }
    }
}

