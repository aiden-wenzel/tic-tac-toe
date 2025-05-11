using System;

class Program {
    static void Main() {
        // This line prints "Hello, World" 
        Program prog = new Program();
        char[] init_state = ['E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E'];
        prog.set_game_state(init_state);
        prog.print_game_board();
    }

    void print_game_board() {
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

    void set_game_state(char[] game_state_in) {
        game_state = game_state_in;
    }

    char[] game_state;
    int num_cols = 3;
    int num_rows = 3;
}
