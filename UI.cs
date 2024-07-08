using System;
using GameProgramTTT;
using Microsoft.VisualBasic;

namespace GameProgramTTT
{
    public static class UI
    {
        /// <summary>
        /// This medthod creates and displays a welcome method for the user
        /// </summary>
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Hello welcome to play this game.");
            Console.WriteLine($"In this game you will play against an {Identifiers.COMPUTER_PLAY}.");
        }
        /// <summary>
        /// This method gets userinputer from the keyboard
        /// </summary>
        /// <param name="question">The question or statement to get a user input character</param>
        /// <returns>The character needed from the Question</returns>
        public static char GetUserAnswer(string question)
        {
            Console.WriteLine(question);
            char userInput = Console.ReadKey().KeyChar;
            return userInput;
        }
        /// <summary>
        /// This method is for getting a userinput if the user wants to play or not
        /// </summary>
        /// <returns>The return is the character y for continuing to play or another character to exit</returns>
        public static char GetUserInput()
        {
            char userInput = GetUserAnswer($"Do you wish to play? Press {Identifiers.USER_LOWER_KEY} for yes and any key to exit");
            Console.WriteLine();
            return char.ToLower(userInput);
        }
        /// <summary>
        /// A statement to inform the user that the game ends now
        /// </summary>
        public static void InformGameEnd()
        {
            Console.WriteLine("The game will end here");
        }
        /// <summary>
        /// A statement to inform the user that the game is full and there is no winner
        /// </summary>
        public static void ShowTieResults()
        {
            Console.WriteLine("The grid is full, and the result is...");
            Console.WriteLine("It is a tie");
        }
        /// <summary>
        /// A statement to inform the user that the game ends now and thanks for playig
        /// </summary>
        public static void DisplayLastThanksStatement()
        {
            Console.WriteLine("Thank you for playing");
        }
        /// <summary>
        /// This method adds some lines and dots to make the grid well displayable
        /// </summary>
        /// <param name="grid">the parameter is the 3x3 grid</param>
        public static void DisplayWholeGrid(char[,] grid)
        {
            Console.WriteLine("..........");
            for (int i = 0; i <= Identifiers.MAX_GRID_INPUT; i++)
            {
                Console.Write($"{Identifiers.GRID_SEPARATOR}");
                for (int j = 0; j <= Identifiers.MAX_GRID_INPUT; j++)
                {
                    Console.Write($"{grid[i, j]} {Identifiers.GRID_SEPARATOR}");
                }
                Console.WriteLine();
                Console.WriteLine("..........");
            }
        }

        /// <summary>
        /// Asks user who should make the first move
        /// </summary>
        /// <returns>the char nextPlayer; H for Human and A for AI</returns>
        public static char GetGamePlayer()
        {
            while (true)
            {
                char userChoice = GetUserAnswer($"You are given the option to choose who should start the game, press {Identifiers.MACHINE} for AI and  {Identifiers.HUMAN} for you");
                Console.WriteLine();
                char UpperKeyUserChoice = char.ToUpper(userChoice);
                if (UpperKeyUserChoice == Identifiers.HUMAN)
                {
                    Console.WriteLine("You will start the game");
                    char nextPlayer = Identifiers.HUMAN;
                    return nextPlayer;
                }

                if (UpperKeyUserChoice == Identifiers.MACHINE)
                {
                    Console.WriteLine("The AI will start the game");
                    char nextPlayer = Identifiers.MACHINE;
                    return nextPlayer;
                }
                Console.WriteLine("Enter a valid key");
            }
        }
        /// <summary>
        /// This methos displays the result after the logic has calculated and found the winner
        /// </summary>
        /// <param name="grid"> the grid values will be passed on here </param>
        public static void ShowResults(Char[,] grid)
        {
            int result = Logic.CalculateMatches(grid);

            if (result == Identifiers.MACHINE_IS_WINNER) 
            {
                Console.WriteLine("The AI won");
                return;
            }
            if (result == Identifiers.HUMAN_IS_WINNER)
            {
                Console.WriteLine("Conglatulations you won");
                return;
            }
        }
        /// <summary>
        /// This method seeks to get a valid number from the user which will be a first coordnate, specifically its for the row position
        /// </summary>
        /// <returns></returns>
        public static int EnterFirstCordinate()
        {
            while (true)
            {
                Console.WriteLine($"Enter a valid number for the row between {Identifiers.MIN_GRID_INPUT} and {Identifiers.MAX_GRID_INPUT}");
                string userInput = Console.ReadLine();
                if (Logic.InputValidation(userInput) && int.TryParse(userInput, out int firstNumber) && firstNumber >= 0 && firstNumber <= Identifiers.MAX_GRID_INPUT)
                {
                    return firstNumber;
                }
                Console.WriteLine("Please enter a valid number");
            }
        }
        /// <summary>
        /// This method seeks to get a valid number from the user which will be a second coordnate, specifically its for the column position
        /// </summary>
        /// <returns></returns>
        public static int EnterSecondCordinate()
        {
            while (true)
            {
                Console.WriteLine($"Enter a valid number for the column between {Identifiers.MIN_GRID_INPUT} and {Identifiers.MAX_GRID_INPUT}");
                string userInput = Console.ReadLine();
                if (Logic.InputValidation(userInput) && int.TryParse(userInput, out int secondNumber) && secondNumber >= 0 && secondNumber <= Identifiers.MAX_GRID_INPUT)
                {

                    return secondNumber;
                }

                Console.WriteLine("Please enter a valid number");

            }
        }
        /// <summary>
        /// Method to get 2 numbers/coordinates from user where the user wants to place his symbol if the posisiton is valid
        /// </summary>
        /// <param name="gridValue">playing grid to be checked for valid placement</param>
        /// <returns>list of 2 selected numbers</returns>
        public static void HumanToPlay(char[,] gridValue)
        {
            Console.WriteLine();
            Console.WriteLine("Your move");
            while (true)
            {
                int rowValue = EnterFirstCordinate();
                int colValue = EnterSecondCordinate();
                if (gridValue[rowValue, colValue] == Identifiers.CELL_KEY)
                {
                    gridValue[rowValue, colValue] = Identifiers.HUMAN;
                    return;
                }
                Console.WriteLine($"That  was an invalid move, try again ");
            }
        }
        /// <summary>
        /// The AI will check where there is empty space and place the A letter
        /// </summary>
        /// <param name="aivalues"> this will be the existing grid</param>
        public static void AiToPlay(Char[,] aivalues)
        {
            Random random = new Random();
            int row = 0;
            int col = 0;
            Console.WriteLine();
            Console.WriteLine("The AI move");
            while (true)
            {
                row = random.Next(0, Identifiers.GRID_SIZE);
                col = random.Next(0, Identifiers.GRID_SIZE);
                if (aivalues[row, col] == Identifiers.CELL_KEY)
                {
                    aivalues[row, col] = Identifiers.MACHINE;
                    return;
                }
            }

        }

    }
}



