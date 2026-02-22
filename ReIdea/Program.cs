namespace ReIdea;

class Program
{
    static void Main(string[] args)
    {
        // Greet user with game name and choice view
        
        // Prompt user to choose game
        // Validate user input AND GOTO Prompt user to choose game if necassary (is the game choice valid?)
        
        // Load / Initialize game
        
        // Draw initial game board state to screen
        
        // Prompt user for move input
        // Validate user input AND GOTO: Prompt user for move input if necassary (is the move choice legal?)
        
        // Calculate new state of board (update positions, check if any completion state is hit)
        
        // Draw new game board state to screen OR Greet user about completion state
        // GOTO: Prompt user for move input OR Exit
        
        
        //-----
        
        
        // Things that don't fit neatly:
        // TUI to display data nicely and allow easy choice
        // Algorithm to work out completion states
        
        
        //------
        
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