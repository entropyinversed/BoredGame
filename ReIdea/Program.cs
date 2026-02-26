namespace ReIdea;

class Program
{
    static void Main(string[] args)
    {
        ////
        //// Setup generic-ish variables
        ////
        const char ZERO = '0';
        const char CROSS = 'X';
        const char EMPTY = '_';
        var userGameSelection = "Not Selected";
        var gameBoard = new char[3, 3];
        var completionStateReached = false;
        
        
        ////
        //// Gather direction flow should go
        ////
        Console.WriteLine("Welcome to BoredGame!");
        Console.WriteLine("Please choose what to play:");
        Console.WriteLine("[Tic Tac Toe]");
        Console.WriteLine("[Toe Tac Tic]");

        while (userGameSelection != "Tic Tac Toe" || userGameSelection != "Toe Tac Tic")
        {
            userGameSelection = Console.ReadLine();

            if (userGameSelection == "Tic Tac Toe" || userGameSelection == "Toe Tac Tic")
            {
                break;
            }
            
            Console.WriteLine("Please choose a valid game");
        }
        
        
        ////
        //// Initialize specific starting state
        ////
        if (userGameSelection == "Tic Tac Toe")
        {
            for (var row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (var col = 0; col < gameBoard.GetLength(1); col++)
                {
                    gameBoard[row, col] = EMPTY;
                }
            }
        }
        
        if (userGameSelection == "Toe Tac Tic")
        {
            for (var row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (var col = 0; col < gameBoard.GetLength(1); col++)
                {
                    gameBoard[row, col] = CROSS; // FIX: Fill board with a random (but equal) combination of Zeros and Crosses
                }
            }
        }
        

        ////
        //// Display board state to the user
        ////
        Draw_Board:
        for (var row = -1; row < gameBoard.GetLength(0); row++)
        {
            if (row == -1) // FIX: Hack to get column numbers drawn first above and offset
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
        if (completionStateReached)
        {
            return;
        }

        
        ////
        //// Get and validate state update data from user
        ////
        TryAgain:
        Console.WriteLine("Please Select a move to play as zeros"); // needs fixing obviously...

        // 0A - Get row and make sure int can be pulled from it
        string userRowSelection;
        int userRowSelectionInt = -1;
        bool isUserRowSelectionValid = false;

        Console.Write("Row: ");
        while (!isUserRowSelectionValid)
        {
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
        int userColSelectionInt = -1; // hacky, something about might not be init later on...
        bool isUserColSelectionValid = false;
        
        Console.Write("Col: ");
        while (!isUserColSelectionValid)
        {
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
            goto TryAgain;
        }
        
        // 2 - Make sure position is empty FIX: this only works for tic tac toe....
        if (gameBoard[userRowSelectionInt, userColSelectionInt] != EMPTY)
        {
            Console.WriteLine("Please do not place your piece on another!");
            goto TryAgain;
        }


        ////
        //// Update the state of the board
        ////
        gameBoard[userRowSelectionInt, userColSelectionInt] = '0'; // FIX: This fails for Tic Tac Toe and Tac Tic Toe
        
            
        ////
        //// Verify is any end state has been reached
        ////
        Console.WriteLine("Somehow, you won!"); // FIX: Obviously
        completionStateReached = true;
        goto Draw_Board;
        
        
        
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------


        
        // Things that don't fit neatly:
        // TUI to display data nicely and allow easy choice
        // Algorithm to work out completion states

        // Something like: Greetings, Drawing, Prompting that user can see all feels like something
        // that can be clumped together and handeled together. Not sure if its an intermediate state
        // before going to TUI? I don't know how TUI works but maybe I have this clump that gets data
        // into defined structure that then gets handed over to TUI

        // Game info is: What are the dimensions of the board? What pieces are on the board? What is the
        // starting state? What are legal moves? What are the win states? What algorithm checks the win states?
        // Maybe no sepration between algorithm and what are win states? Feels hard to read then though maybe?
        // // How to make this general? Does it make sense to have "General Board" "General Pieces" "General Rules"
        // // "General States" "General Algorithm"? Seems to break down on that last part...
        // // Maybe useless, but what is the 90 degree different view on how to categorize???
    }
}
