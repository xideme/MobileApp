using System;
using Microsoft.Maui.Controls;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        private bool isPlayerXTurn = true;
        private string[] board = new string[9];  // board state
        private bool isPlayingWithBot = false;   // game vs. Bot

        public MainPage()
        {
            InitializeComponent();
            NewGame(null, null);  // fresh game
        }

        private void ButtonClick(object btnclicked, EventArgs e)
        {
            var button = (Button)btnclicked;
            int index = GetButtonIndex(button);

            if (!string.IsNullOrEmpty(board[index])) return; // do not allow a double click

            //  text for the player (X or O)
            board[index] = isPlayerXTurn ? "X" : "O";
            button.Text = board[index];

            //  if the current player won
            if (CheckForWinner())
            {
                DisplayAlert("Game Over", $"{board[index]} wins!", "Ok");
                return;
            }

            //  draw
            if (IsBoardFull())
            {
                DisplayAlert("Game Over", "It's a draw!", "Ok");
                return;
            }

            // switch turns
            isPlayerXTurn = !isPlayerXTurn;

            // if playing with bot, make the bots move
            if (isPlayingWithBot && !isPlayerXTurn)
            {
                BotMove();
            }
        }

        private void BotMove()
        {
            int move = GetBotMove();

            // text for bot move
            board[move] = "O";
            var button = GetButtonByIndex(move);
            button.Text = "O";

            // if the bot wins
            if (CheckForWinner())
            {
                DisplayAlert("Game Over", "O wins!", "Ok");

            }
            else if (IsBoardFull())  //check for a draw after bot's move
            {
                DisplayAlert("Game Over", "It's a draw!", "Ok");

            }
            else
            {
                // switch back to player turn after bot move
                isPlayerXTurn = true;
            }
        }

        private int GetBotMove()
        {
            // Simple bot logic: try to win, block, or make a random move
            for (int i = 0; i < 9; i++)
            {
                if (string.IsNullOrEmpty(board[i]))
                {
                    board[i] = "O"; //bot
                    if (CheckForWinner())
                    {
                        board[i] = null;  // Reset after check
                        return i;
                    }
                    board[i] = null; //reset if not a winning move
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (string.IsNullOrEmpty(board[i]))
                {
                    board[i] = "X"; //player
                    if (CheckForWinner())
                    {
                        board[i] = null;  // Reset after check
                        return i;
                    }
                    board[i] = null; //reset if not a blocking move
                }
            }

            Random random = new Random();
            int randomMove;
            do
            {
                randomMove = random.Next(0, 9);
            } while (!string.IsNullOrEmpty(board[randomMove]));

            return randomMove;
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

        private void PlayWithBot(object sender, EventArgs e)
        {
            isPlayingWithBot = true;
            NewGame(null, null);  // Start a new game with the bot
            DisplayAlert("Game Mode", "Playing against the Bot!", "OK");
        }

        private void ChooseFirstPlayer(object sender, EventArgs e)
        {
            // Random who goes first (X is human, O is bot)
            isPlayerXTurn = new Random().Next(0, 2) == 0;
            DisplayAlert("First Player", isPlayerXTurn ? "X goes first!" : "O goes first!", "OK");

            if (isPlayingWithBot && !isPlayerXTurn)
            {
                BotMove();  // Bot starts if O is chosen
            }
        }

        private int GetButtonIndex(Button button) //return button index
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
            int[][] winPatterns =
            [
                [0, 1, 2],
                [3, 4, 5],
                [6, 7, 8],
                [0, 3, 6],
                [1, 4, 7],
                [2, 5, 8],
                [0, 4, 8],
                [2, 4, 6],

                // check if player has all three positions in that pattern
            ];

            foreach (var pattern in winPatterns)
            {
                if (!string.IsNullOrEmpty(board[pattern[0]]) &&
                    board[pattern[0]] == board[pattern[1]] && // checks if the value in the first cell is equal to second
                    board[pattern[1]] == board[pattern[2]]) // checks if the value in the second cell is equal to third
                {
                    return true; //Winner
                }
            }

            return false; // No winner
        }

        private bool IsBoardFull()
        {
            return Array.IndexOf(board, null) == -1; // Its a draw
        }
    }
}
