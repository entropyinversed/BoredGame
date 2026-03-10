namespace ReIdea;

internal static class Program
{
    private enum SupportedGames
    {
        TicTacToe
    }

    private enum BoardStates
    {
        InPlay,
        ZeroWon,
        CrossWon,
        Draw
    }

    struct MoveData
    {
        public int Row;
        public int Col;
    }
    
    private static readonly (int row, int col)[][] AllWinLines =
    [
        // Row
        [(0, 0), (0, 1), (0, 2)],
        [(1, 0), (1, 1), (1, 2)],
        [(2, 0), (2, 1), (2, 2)],

        // Col
        [(0, 0), (1, 0), (2, 0)],
        [(0, 1), (1, 1), (2, 1)],
        [(0, 2), (1, 2), (2, 2)],

        // Dia
        [(0, 0), (1, 1), (2, 2)],
        [(0, 2), (1, 1), (2, 0)]
    ];
    
    
    private static void Main()
    {
        //// Setup generic-ish variables
        const char zero = 'O';
        const char cross = 'X';
        const char empty = '_';
        var whosTurnIsIt = zero; // FIX: Should have states defined, maybe enum
        var gameBoard = new char[3, 3];
        
        //// Get info to decide what game to have as starting state
        var validatedUserGameSelection = GetUserGameSelection();
        
        //// Initialize specific game starting state
        SetupBoardStart(validatedUserGameSelection, gameBoard, empty, zero, cross);
        
        //// Display board state to the user
        Draw_Board:
        DrawBoard(gameBoard);
        
        //// Get and validate state update data from user
        MoveData validatedMoveData = GetAndValidateMoveRequest(whosTurnIsIt, empty, gameBoard);
        
        //// Update the state of the board
        if (whosTurnIsIt == zero)
        {
            gameBoard[validatedMoveData.Row, validatedMoveData.Col] = zero;
            whosTurnIsIt = cross;
        }
        else
        {
            gameBoard[validatedMoveData.Row, validatedMoveData.Col] = cross;
            whosTurnIsIt = zero;
        }
        
        //// Verify is any end state has been reached
        if (IsGameComplete(gameBoard, empty))
        {
            return;
        }
        else
        {
            goto Draw_Board;
        }
    }
    
    
    // -------------------------------------------------------------------------------------------------------------
    
    
    private static SupportedGames GetUserGameSelection() // FIX: There's gotta be a better way
    {
        Console.WriteLine("Welcome to BoredGame!!!");
        Console.WriteLine("Please choose what to play:");
        Console.WriteLine("[Tic Tac Toe]");
        
        var userGameSelection = "Not Selected";

        while (userGameSelection != "Tic Tac Toe")
        {
            userGameSelection = Console.ReadLine();
            Console.WriteLine("Please choose a valid game");
        }
        
        switch (userGameSelection)
        {
            case "Tic Tac Toe":
            {
                return SupportedGames.TicTacToe;
            }
            default:
            {
                throw new Exception("What the hell...");
            }
        }
    }

    
    private static void SetupBoardStart(SupportedGames validatedUserGameSelection, char[,] gameBoard, char empty, char zero, char cross)
    {
        switch (validatedUserGameSelection)
        {
            case SupportedGames.TicTacToe:
            {
                for (var row = 0; row < gameBoard.GetLength(0); row++)
                {
                    for (var col = 0; col < gameBoard.GetLength(1); col++)
                    {
                        gameBoard[row, col] = empty;
                    }
                }
                break;
            }
        }
    }

    
    private static void DrawBoard(char[,] gameBoard)
    {
        for (var row = -1; row < gameBoard.GetLength(0); row++)
        {
            if (row == -1)
            {
                Console.Write("   ");
                for (var col = 0; col < gameBoard.GetLength(1); col++)
                {
                    Console.Write($" {col} ");
                }
                Console.WriteLine();
                row++;
            }
            Console.Write($" {row} ");
            for (var col = 0; col < gameBoard.GetLength(1); col++)
            {
                Console.Write($" {gameBoard[row, col]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    
    private static MoveData GetAndValidateMoveRequest(char whosTurnIsIt, char empty, char[,]gameBoard) // FIX: Doing waaaaaay to much!
    {
        MoveData validatedMoveData;
        validatedMoveData.Row = -1;
        validatedMoveData.Col = -1;
        
        Get_State_Update:
        Console.WriteLine($"Please Select a move to play as {whosTurnIsIt}");
        
        // 0A - Get row and make sure int can be pulled from it
        string userRowSelection;
        int userRowSelectionInt = -1;
        bool isUserRowSelectionValid = false;
        
        while (!isUserRowSelectionValid)
        {
            Console.Write("Row: ");
            userRowSelection = Console.ReadLine();
            isUserRowSelectionValid = int.TryParse(userRowSelection, out userRowSelectionInt);

            if (isUserRowSelectionValid)
            {
                break;
            }

            Console.WriteLine("Please enter a valid row number.");
        }

        // 0B - Get col and make sure int can be pulled from it
        string userColSelection;
        int userColSelectionInt = -1;
        bool isUserColSelectionValid = false;
        
        while (!isUserColSelectionValid)
        {
            Console.Write("Col: ");
            userColSelection = Console.ReadLine();
            isUserColSelectionValid = int.TryParse(userColSelection, out userColSelectionInt);

            if (isUserColSelectionValid)
            {
                break;
            }

            Console.WriteLine("Please enter a valid col number.");
        }

        // 1 - Make sure it is on the board
        if (userRowSelectionInt > 2 || userRowSelectionInt < 0 || userColSelectionInt > 2 || userColSelectionInt < 0)
        {
            Console.WriteLine("Please ensure your selection is on the board");
            goto Get_State_Update;
        }

        // 2 - Make sure position is empty FIX: this only works for tic tac toe....
        if (gameBoard[userRowSelectionInt, userColSelectionInt] != empty)
        {
            Console.WriteLine("Please do not place your piece on another!");
            goto Get_State_Update;
        }
        
        validatedMoveData.Row = userRowSelectionInt;
        validatedMoveData.Col = userColSelectionInt;
        return validatedMoveData;
    }
    
    
    private static bool IsBoardFull(char[,] gameBoard, char empty)
    {
        foreach (var piece in gameBoard)
        {
            if (piece == empty)
            {
                return false;
            }
        }
        return true;
    }

    
    private static char WhoWonTheGame(char[,] gameBoard, char empty) // Just stealling the math method for now, but I will come up with something better!!!
    {
        foreach (var line in AllWinLines)
        {
            var firstCellValue = gameBoard[line[0].row, line[0].col];
            if (firstCellValue == empty)
            {
                continue;
            }

            if (gameBoard[line[1].row, line[1].col] != firstCellValue ||
                gameBoard[line[2].row, line[2].col] != firstCellValue)
            {
                continue;
            }

            return firstCellValue;
        }
        Console.WriteLine("The Game Continues");
        return empty;
    }

    
    private static bool IsGameComplete(char[,] gameBoard, char empty)
    {
        if (IsBoardFull(gameBoard, empty))
        {
            DrawBoard(gameBoard);
            Console.WriteLine($"board state = {BoardStates.Draw}");
            return true;
        }
        else
        {
            var whoWon = WhoWonTheGame(gameBoard, empty);
            if (whoWon == empty)
            {
                DrawBoard(gameBoard);
                return false;
            }
            else
            {
                DrawBoard(gameBoard);
                Console.WriteLine($"The player that one was: {whoWon} !");
                return true;
            }
        }
    }
}