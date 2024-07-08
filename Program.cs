using System;

namespace GameProgramTTT;
class Program
{
    static void Main(string[] args)
    {
        char[,] grid = new char[Identifiers.GRID_SIZE, Identifiers.GRID_SIZE];
        UI.ShowWelcomeMessage();
        char userInput = UI.GetUserInput();
        if (userInput == Identifiers.USER_LOWER_KEY)
        {
            Console.WriteLine("Lets go on");
        }
        else
        {
            UI.InformGameEnd();
            return;
        }
        grid = Logic.CreateEmptyGrid();
        UI.DisplayWholeGrid(grid);
        char nextPlayer = UI.GetGamePlayer();
        while (true)
        {
            if (nextPlayer == Identifiers.HUMAN)
            {
                UI.HumanToPlay(grid);
                nextPlayer = Identifiers.MACHINE;
                UI.DisplayWholeGrid(grid);
                if (Logic.WinFound(grid))
                {
                    UI.ShowResults(grid);
                    break;
                }
                Console.WriteLine("No winner yet");
            }
            else
            {
                UI.AiToPlay(grid);
                nextPlayer = Identifiers.HUMAN;
                UI.DisplayWholeGrid(grid);
                if (Logic.WinFound(grid))
                {
                    UI.ShowResults(grid);
                    break;
                }
                Console.WriteLine("No winner yet");
            }
            bool theGridIsFull = Logic.GridIsFull(grid);
            if (theGridIsFull)
            {
                UI.ShowTieResults();
                break;
            }
        }
        UI.DisplayLastThanksStatement();
    }
}

