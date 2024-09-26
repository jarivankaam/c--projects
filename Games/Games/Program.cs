using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Games
{
    class Game
    {
        private string? hangMansWord;
        private char[]? wordArray;
        private bool running;
        private int amountOfMaxTries;
        private int amountOfTries;
        private List<char>? guessed;
        private char[]? arr;
        private int player;
        private int choice;
        private int flag;

        
        public void StartClassicHangman()
        {
            Console.WriteLine("Classic Hangman (Case-sensitive when guessing): Which word?");
            hangMansWord = Console.ReadLine();
            wordArray = hangMansWord.ToCharArray();
            running = true;
            amountOfMaxTries = wordArray.Length + 5;
            amountOfTries = 0;
            guessed = new List<char>();
        }

        
        public void StartReverseHangman()
        {
            Console.WriteLine("Reverse Hangman: Enter a word, and the computer will guess!");
            hangMansWord = Console.ReadLine();
            wordArray = hangMansWord.ToCharArray();
            running = true;
            amountOfMaxTries = wordArray.Length + 5;
            amountOfTries = 0;
            guessed = new List<char>();
        }

        
        public void StartTicTacToe()
        {
            Console.WriteLine("Tic Tac Toe: Grab a friend and start the battle!");
            arr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            player = 1; 
            flag = 0;   
            running = true;
        }

        
        public void PlayTicTacToe()
        {
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Player1: X and Player2: O\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn (O):");
                }
                else
                {
                    Console.WriteLine("Player 1's turn (X):");
                }

                Board();

                
                while (true)
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        if (choice < 1 || choice > 9 || arr[choice] == 'X' || arr[choice] == 'O')
                        {
                            Console.WriteLine("Invalid input, please choose an available number.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input, please enter a number between 1 and 9.");
                    }
                }

                
                arr[choice] = player % 2 == 0 ? 'O' : 'X';
                player++;

                
                flag = CheckWin();
                if (flag == 1)
                {
                    Console.Clear();
                    Board();
                    Console.WriteLine("Player {0} has won!", (player % 2) + 1);
                    running = false;
                }
                else if (flag == -1)
                {
                    Console.Clear();
                    Board();
                    Console.WriteLine("It's a draw!");
                    running = false;
                }
            }
        }

        
        private void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        
        private int CheckWin()
        {
            
            if (arr[1] == arr[2] && arr[2] == arr[3]) return 1;
            if (arr[4] == arr[5] && arr[5] == arr[6]) return 1;
            if (arr[7] == arr[8] && arr[8] == arr[9]) return 1;

            
            if (arr[1] == arr[4] && arr[4] == arr[7]) return 1;
            if (arr[2] == arr[5] && arr[5] == arr[8]) return 1;
            if (arr[3] == arr[6] && arr[6] == arr[9]) return 1;

            
            if (arr[1] == arr[5] && arr[5] == arr[9]) return 1;
            if (arr[3] == arr[5] && arr[5] == arr[7]) return 1;

            
            if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' &&
                arr[4] != '4' && arr[5] != '5' && arr[6] != '6' &&
                arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            
            return 0;
        }

        
        public void PlayClassicHangman()
        {
            while (running)
            {
                Console.WriteLine("Which letter?");
                char guessedLetter = Convert.ToChar(Console.ReadLine());
                amountOfTries++;

                if (wordArray.Contains(guessedLetter))
                {
                    guessed.Add(guessedLetter);
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    Console.WriteLine("Wrong guess!");
                }

                
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessed));

                
                if (guessed.Distinct().Count() >= wordArray.Distinct().Count())
                {
                    Console.WriteLine("You've won!");
                    running = false;
                }
                else if (amountOfTries > amountOfMaxTries)
                {
                    Console.WriteLine("You've been hanged!");
                    running = false;
                }
            }
        }

        
        public void PlayReverseHangman()
        {
            Random random = new Random();
            while (running)
            {
                char computerGuess = (char)random.Next('a', 'z');
                Console.WriteLine($"Computer guesses: {computerGuess}");
                amountOfTries++;

                if (wordArray.Contains(computerGuess))
                {
                    guessed.Add(computerGuess);
                    Console.WriteLine("Computer guessed correctly!");
                }
                else
                {
                    Console.WriteLine("Computer guessed wrong!");
                }

                
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessed));

                
                if (guessed.Distinct().Count() >= wordArray.Distinct().Count())
                {
                    Console.WriteLine("Computer won!");
                    running = false;
                }
                else if (amountOfTries > amountOfMaxTries)
                {
                    Console.WriteLine("Computer lost!");
                    running = false;
                }
            }
        }

        
        public void SelectAndPlayGame()
        {
            Console.WriteLine("Choose a game: \n1. Classic Hangman \n2. Reverse Hangman \n3. Tic Tac Toe");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartClassicHangman();
                    PlayClassicHangman();
                    break;
                case "2":
                    StartReverseHangman();
                    PlayReverseHangman();
                    break;
                case "3":
                    StartTicTacToe();
                    PlayTicTacToe();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.SelectAndPlayGame();
        }
    }
}
