using System;
namespace GameProgramTTT
{
    public static class Logic
    {
        /// <summary>
        /// A method which creates an empty Grid of 3 x 3
        /// </summary>
        /// <returns> the 3x3 grid</returns>
        public static char[,] CreateEmptyGrid()
        {
            char[,] grid = new char[Identifiers.GRID_SIZE, Identifiers.GRID_SIZE];
            for (int i = 0; i <= Identifiers.MAX_GRID_INPUT; i++)
            {
                for (int j = 0; j <= Identifiers.MAX_GRID_INPUT; j++)
                {
                    grid[i, j] = Identifiers.CELL_KEY;
                }
            }
            return grid;
        }
        /// <summary>
        /// Thos method aims at validating the input if its an integer
        /// </summary>
        /// <param name="userInput">The input from the user in the console</param>
        /// <returns></returns>
        public static bool InputValidation(string userInput)
        {
            bool inputSuccess = int.TryParse(userInput, out int _);
            return inputSuccess;
        }
        /// <summary>
        /// The method calculates matches to get a winner; if no block of code calculating to three matches then it returns no winner
        /// </summary>
        /// <param name="grid"></param>
        public static int CalculateMatches(Char[,] grid)
        {
            int i;
            int j;
            int aIMatchDiagnal = 0;
            int humanMatchDiagnal = 0;
            int aIMatchFromRight = 0;
            int humanMatchFromRight = 0;
            int noWinner = 9;
            for (i = 0; i <= Identifiers.MAX_GRID_INPUT; i++)
            {
                int machineHolizontalWin = 0;
                int humanHolizontalWin = 0;
                int machineVerticalWin = 0;
                int humanVerticalWin = 0;
                for (j = 0; j <= Identifiers.MAX_GRID_INPUT; j++)
                {

                    if (Identifiers.MACHINE == grid[i, j])
                    {

                        machineHolizontalWin++;

                        if (machineHolizontalWin == Identifiers.GRID_SIZE)
                        {
                            return Identifiers.MACHINE_IS_WINNER;
                        }
                    }
                    if (Identifiers.HUMAN == grid[i, j])
                    {
                        humanHolizontalWin++;

                        if (humanHolizontalWin == Identifiers.GRID_SIZE)
                        {
                            return Identifiers.HUMAN_IS_WINNER;
                        }
                    }
                    if (Identifiers.MACHINE == grid[j, i])
                    {
                        machineVerticalWin++;

                        if (machineVerticalWin == Identifiers.GRID_SIZE)
                        {
                            return Identifiers.MACHINE_IS_WINNER;
                        }
                    }

                    if (Identifiers.HUMAN == grid[j, i])
                    {
                        humanVerticalWin++;

                        if (humanVerticalWin == Identifiers.GRID_SIZE)
                        {
                            return Identifiers.HUMAN_IS_WINNER;
                        }
                    }
                }
                if (Identifiers.MACHINE == grid[i, i])
                {
                    aIMatchDiagnal++;

                    if (aIMatchDiagnal == Identifiers.GRID_SIZE)
                    {
                        return Identifiers.MACHINE_IS_WINNER;
                    }
                }
                if (Identifiers.HUMAN == grid[i, i])
                {
                    humanMatchDiagnal++;

                    if (humanMatchDiagnal == Identifiers.GRID_SIZE)
                    {
                        return Identifiers.HUMAN_IS_WINNER;
                    }
                }
                if (Identifiers.MACHINE == grid[i, Identifiers.MAX_GRID_INPUT - i])
                {
                    aIMatchFromRight++;

                    if (aIMatchFromRight == Identifiers.GRID_SIZE)
                    {
                        return Identifiers.MACHINE_IS_WINNER;
                    }
                }
                if (Identifiers.HUMAN == grid[i, Identifiers.MAX_GRID_INPUT - i])
                {
                    humanMatchFromRight++;
                    if (humanMatchFromRight == Identifiers.GRID_SIZE)
                    {
                        return Identifiers.HUMAN_IS_WINNER;
                    }
                }
            }
            return noWinner;
        }
        public static bool WinFound(Char[,] grid)
        {
            int resultFound = CalculateMatches(grid);

            if (resultFound == Identifiers.HUMAN_IS_WINNER || resultFound == Identifiers.MACHINE_IS_WINNER)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// This method checks if the grid is full or not. If the grid is not full and no winner then the game will keep on being played. If the grid is full then the results will be shown whether there is a winner or no winner
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>it returns a boolen true for a full grid or false if there are still spaces in the grid</returns>
        public static bool GridIsFull(char[,] grid)
        {
            foreach (char cell in grid)
            {
                if (cell == Identifiers.CELL_KEY)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
