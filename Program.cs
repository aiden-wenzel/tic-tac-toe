using System;

class Program {
    static void Main() {
        // This line prints "Hello, World" 
        Game tic_tac = new Game();
        char[] init_state = ['E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E'];
        
        
        Console.WriteLine("Welcome to Tick Tac Toe");
        tic_tac.set_game_state(init_state);
        
        bool done = false;
        
        while (!done) {
            tic_tac.print_game_board();
            tic_tac.get_player_response();
            
            tic_tac.print_game_board();
            break;
        }
    }

    void get_player_response() {

    }

    void set_game_state(char[] game_state_in) {
        game_state = game_state_in;
    }

    char[] game_state;
    int num_cols = 3;
    int num_rows = 3;
}

class Game {
    public void print_game_board() {
        for (int i = 0; i < num_rows; i++) {
            string row_print = "|";
            for (int j = 0; j < num_cols; j++) {
                if (game_state[i * num_cols + j] == 'E') {
                    row_print += " |";
                }
                else {
                    row_print += game_state[i * num_cols + j] + "|";
                }
            }
            Console.WriteLine(row_print);
        }
    }
    public void set_game_state(char[] game_state_in) {
        game_state = game_state_in;
    }

    public void get_player_response() {
        Console.WriteLine("Player 1: Please enter the row and column you would like to mark [row column] or quit [q]");
            string? response = Console.ReadLine();

            string[] subs = response.Split(' ');
            int selected_row = Int32.Parse(subs[0]);
            int selected_column = Int32.Parse(subs[1]);
            int game_state_index = selected_row * this.num_cols + selected_column;
            this.game_state[game_state_index] = 'X';
    }
    
    public char[] game_state;
    public int num_cols = 3;
    public int num_rows = 3;
}
