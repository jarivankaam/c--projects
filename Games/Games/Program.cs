using System;
using System.Collections.Generic;
using System.Linq;

namespace Games
{
    
    abstract class Game
    {
        public abstract void Play();
    }

    
    //generate classes for hangman, tictactoe and mastermind
    class Hangman : Game
    {
        private string word;
        private HashSet<char> guessedLetters;
        private int maxTries;
        private int tries;

        public Hangman(bool isReverse = false)
        {
            Console.WriteLine(isReverse ? "Reverse Hangman: Enter a word, and the computer will guess!" : "Classic Hangman: Enter a word for the game!");
            word = Console.ReadLine();
            guessedLetters = new HashSet<char>();
            maxTries = word.Length + 5;
            tries = 0;

            if (isReverse)
                PlayReverseHangman();
            else
                PlayClassicHangman();
        }

        private void PlayClassicHangman()
        {
            while (tries < maxTries && guessedLetters.Count < word.Distinct().Count())
            {
                Console.WriteLine("Guess a letter:");
                char guess = Console.ReadLine()[0];
                tries++;

                if (word.Contains(guess))
                {
                    guessedLetters.Add(guess);
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    Console.WriteLine("Wrong guess!");
                }

                DisplayProgress();
            }

            Console.WriteLine(guessedLetters.Count == word.Distinct().Count() ? "You've won!" : "You've been hanged!");
        }

        private void PlayReverseHangman()
        {
            Random random = new Random();

            while (tries < maxTries && guessedLetters.Count < word.Distinct().Count())
            {
                char guess = (char)random.Next('a', 'z' + 1);
                Console.WriteLine($"Computer guesses: {guess}");
                tries++;

                if (word.Contains(guess))
                {
                    guessedLetters.Add(guess);
                    Console.WriteLine("Computer guessed correctly!");
                }
                else
                {
                    Console.WriteLine("Computer guessed wrong!");
                }

                DisplayProgress();
            }

            Console.WriteLine(guessedLetters.Count == word.Distinct().Count() ? "Computer won!" : "Computer lost!");
        }

        private void DisplayProgress()
        {
            Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
            Console.WriteLine("Word progress: " + string.Concat(word.Select(c => guessedLetters.Contains(c) ? c : '_')));
        }

        public override void Play()
        {
            
            
        }
    }

    
    class TicTacToe : Game
    {
        private char[] board;
        private char currentPlayer;

        public TicTacToe()
        {
            board = Enumerable.Range(1, 9).Select(i => i.ToString()[0]).ToArray();
            currentPlayer = 'X';
        }

        public override void Play()
        {
            int moves = 0;
            while (true)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move (1-9):");

                if (int.TryParse(Console.ReadLine(), out int move) && move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O')
                {
                    board[move - 1] = currentPlayer;
                    moves++;

                    if (CheckWin())
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                    else if (moves == 9)
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine("It's a draw!");
                        break;
                    }

                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Invalid move! Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }

        private void DisplayBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]} ");
            Console.WriteLine("     |     |      ");
        }

        private bool CheckWin()
        {
            int[,] winConditions = new int[,]
            {
                {0,1,2}, {3,4,5}, {6,7,8}, 
                {0,3,6}, {1,4,7}, {2,5,8}, 
                {0,4,8}, {2,4,6}           
            };

            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                if (board[winConditions[i, 0]] == currentPlayer &&
                    board[winConditions[i, 1]] == currentPlayer &&
                    board[winConditions[i, 2]] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }
    }

    
    class Mastermind : Game
    {
        private int[] secretCode;
        private int codeLength = 4;
        private int maxAttempts = 10;
        private bool isHumanVsHuman;

        public Mastermind(bool isHumanVsHuman = false)
        {
            this.isHumanVsHuman = isHumanVsHuman;
            secretCode = new int[codeLength];

            if (isHumanVsHuman)
                SetSecretCodeByPlayer();
            else
                GenerateSecretCode();
        }

        private void GenerateSecretCode()
        {
            Random rand = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                secretCode[i] = rand.Next(1, 7);
            }
        }

        private void SetSecretCodeByPlayer()
        {
            Console.WriteLine("Player 1, enter the secret code (numbers from 1 to 6):");
            while (true)
            {
                string input = Console.ReadLine();
                if (ValidateCode(input, out int[] code))
                {
                    secretCode = code;
                    Console.Clear();
                    Console.WriteLine("Secret code has been set. Player 2, start guessing!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Please enter exactly {codeLength} digits between 1 and 6.");
                }
            }
        }

        private bool ValidateCode(string input, out int[] code)
        {
            code = new int[codeLength];
            if (input.Length != codeLength || !input.All(char.IsDigit))
                return false;

            for (int i = 0; i < codeLength; i++)
            {
                int digit = int.Parse(input[i].ToString());
                if (digit < 1 || digit > 6)
                    return false;
                code[i] = digit;
            }
            return true;
        }

        public override void Play()
        {
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                attempts++;
                Console.WriteLine($"Attempt {attempts}/{maxAttempts}: Enter your guess (numbers from 1 to 6):");
                if (ValidateCode(Console.ReadLine(), out int[] guess))
                {
                    var feedback = GetFeedback(guess);
                    Console.WriteLine($"Feedback: {feedback.correctPosition} correct digit(s) in the correct position.");
                    Console.WriteLine($"          {feedback.correctNumber} correct digit(s) but in the wrong position.\n");

                    if (feedback.correctPosition == codeLength)
                    {
                        Console.WriteLine("Congratulations! You've cracked the code!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"Please enter exactly {codeLength} digits between 1 and 6.");
                }

                if (attempts == maxAttempts)
                {
                    Console.WriteLine("You've used all attempts. Game over!");
                    Console.WriteLine("The secret code was: " + string.Join("", secretCode));
                }
            }
        }

        private (int correctPosition, int correctNumber) GetFeedback(int[] guess)
        {
            int correctPosition = 0;
            int correctNumber = 0;
            bool[] secretUsed = new bool[codeLength];
            bool[] guessUsed = new bool[codeLength];

            for (int i = 0; i < codeLength; i++)
            {
                if (guess[i] == secretCode[i])
                {
                    correctPosition++;
                    secretUsed[i] = guessUsed[i] = true;
                }
            }

            for (int i = 0; i < codeLength; i++)
            {
                if (!guessUsed[i])
                {
                    for (int j = 0; j < codeLength; j++)
                    {
                        if (!secretUsed[j] && guess[i] == secretCode[j])
                        {
                            correctNumber++;
                            secretUsed[j] = true;
                            break;
                        }
                    }
                }
            }
            return (correctPosition, correctNumber);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a game: \n1. Classic Hangman \n2. Reverse Hangman \n3. Tic Tac Toe \n4. Mastermind (Human vs Computer) \n5. Mastermind (Human vs Human)");
            string choice = Console.ReadLine();
            Game game;

            switch (choice)
            {
                case "1":
                    game = new Hangman();
                    break;
                case "2":
                    game = new Hangman(isReverse: true);
                    break;
                case "3":
                    game = new TicTacToe();
                    game.Play();
                    break;
                case "4":
                    game = new Mastermind();
                    game.Play();
                    break;
                case "5":
                    game = new Mastermind(isHumanVsHuman: true);
                    game.Play();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }
        }
    }
}
