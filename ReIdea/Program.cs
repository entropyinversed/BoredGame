namespace ReIdea;

class Program
{
    static void Main(string[] args)
    {
       
	// Just to test git creds

	const char EMPTY = '_';
        
        // Plan for Tic Tac Toe
        var board = new char[3, 3];
        ////// fill it in
        //// run into issue of how to encode rules
        
        // Greet user with game name and choice view
        Console.WriteLine("Welcome to BoredGame!");
        Console.WriteLine("Please choose what to play:");
        Console.WriteLine("[Tic Tac Toe]");
        Console.WriteLine("[Not Yet Add]");
        
        
        // Prompt user to choose game
        // Validate user input AND GOTO Prompt user to choose game if necassary (is the game choice valid?)
        var userGameSelection = "";
        userGameSelection = "Tic Tac Toe"; // for debugging

        while (userGameSelection != "Tic Tac Toe")
        {
            userGameSelection = Console.ReadLine();

            if (userGameSelection == "Tic Tac Toe")
            {
                break;
            }
            
            Console.WriteLine("Please choose a valid game");
        }

        // Console.WriteLine($"board.GetLength(0) = {board.GetLength(0)}"); // for debugging
        // Console.WriteLine($"board.GetLength(1) = {board.GetLength(1)}"); // for debugging

        // Load / Initialize game
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                board[row, col] = EMPTY;
                // Console.WriteLine($"row = {row}; col = {col}; board = {board[row, col]}"); // for debugging
            }
        }

        // Draw initial game board state to screen (what an absolute disaster... but it works)
        for (var row = -1; row < board.GetLength(0); row++)
        {
            // Hack to get column numbers drawn first above and offset
            if (row == -1)
            {
                Console.Write("   ");
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write($" {col} ");        
                }
                Console.WriteLine();
                row++;
            }
            
            Console.Write($" {row} ");
            for (var col = 0; col < board.GetLength(1); col++)
            {
                Console.Write($" {board[row, col]} ");   
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        
        // Prompt user for move input and validate
        TryAgain:
        Console.WriteLine("Please Select a move to play as zeros"); // needs fixing obviously...

        // Get row and make sure int can be pulled from it
        string userRowSelection;
        int userRowSelectionInt = -1; // hacky, something about might not be init later on...
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
        
        // Get col and make sure int can be pulled from it
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

        // Console.WriteLine($"userRowSelectionInt {userRowSelectionInt}"); // for debugging
        // Console.WriteLine($"userColSelectionInt {userColSelectionInt}"); // for debugging

        // - 1. Make sure it is on the board
        if (userRowSelectionInt > 2 || userRowSelectionInt < 0 || userColSelectionInt > 2 || userColSelectionInt < 0)
        {
            Console.WriteLine("Please ensure your selection is on the board");
            goto TryAgain;
        }
        
        // - 2. Make sure position is empty
        if (board[userRowSelectionInt, userColSelectionInt] != EMPTY)
        {
            Console.WriteLine("Please do not place your piece on another!");
            goto TryAgain;
        }


        // Set new state of board (update positions, check if any completion state is hit)
        // Place the user's move
        board[userRowSelectionInt, userColSelectionInt] = '0';
        
        // Do some magic to check if completion state is hit
        Console.WriteLine("Somehow, you won!");

        // Draw new game board state to screen AND if compeltion status is true Greet user about completion state
        // Draw initial game board state to screen (what an absolute disaster... but it works)
        for (var row = -1; row < board.GetLength(0); row++)
        {
            // Hack to get column numbers drawn first above and offset
            if (row == -1)
            {
                Console.Write("   ");
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write($" {col} ");        
                }
                Console.WriteLine();
                row++;
            }
            
            Console.Write($" {row} ");
            for (var col = 0; col < board.GetLength(1); col++)
            {
                Console.Write($" {board[row, col]} ");   
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        
        // GOTO: Prompt user for move input OR Exit

        
        //-------------------------
        //-------------------------
        //-------------------------


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
