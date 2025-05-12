using System;

class Program {
    static void Main() {
        // This line prints "Hello, World" 
        Game tic_tac = new Game();
        char[,] init_state = {
            {'E', 'E', 'E'},
            {'E', 'E', 'E'},
            {'E', 'E', 'E'},
        };
        
        
        Console.WriteLine("Welcome to Tick Tac Toe");
        tic_tac.set_game_state(init_state);
        
        bool done = false;
        
        int round_num = 1;
        while (!done) {
            Console.Clear();
            tic_tac.print_game_board();
            if (round_num % 2 == 1) {
                tic_tac.get_player_response("Player 1");
            }
            else {
                tic_tac.get_player_response("Player 2");
            }
            done = tic_tac.check_board();

            if (done) {
                break;
            }
            round_num++;
        }
        Console.Clear(); 
        if (round_num % 2 == 1) {
            Console.WriteLine("Player 1 Wins!");
        }
        else {
            Console.WriteLine("Player 2 Wins!");
        }
        tic_tac.print_game_board(); 
        Console.WriteLine("Thanks for Playing!");
    }
}

class Game {
    public void print_game_board() {
        for (int i = 0; i < num_rows; i++) {
            string row_print = "|";
            for (int j = 0; j < num_cols; j++) {
                if (game_state[i,j] == 'E') {
                    row_print += " |";
                }
                else {
                    row_print += game_state[i,j]  + "|";
                }
            }
            Console.WriteLine(row_print);
        }
    }
    public void set_game_state(char[,] game_state_in) {
        game_state = game_state_in;
    }

    public void get_player_response(string player) {
        Console.WriteLine($"{player}: Please enter the row and column you would like to mark [row column]");
        while (true) {
            string? response = Console.ReadLine();

            string[] subs = response.Split(' ');
            int selected_row = Int32.Parse(subs[0]);
            int selected_column = Int32.Parse(subs[1]);

            if (selected_column < 0 || selected_column > this.num_cols-1) {
                Console.WriteLine("Column was not inbounds. Try again.");
                continue;
            }
            else if (selected_row < 0 || selected_row > this.num_rows-1) {
                Console.WriteLine("Row was not inbounds. Try again.");
                continue;
            }

            char selected_cell_val = this.game_state[selected_row, selected_column];
            if (selected_cell_val != 'E') {
                Console.WriteLine("That spot is already taken. Try again.");
                continue;
            }

            else if (player == "Player 1") {
                this.game_state[selected_row, selected_column] = 'X';
                break;
            }
            else {
                this.game_state[selected_row, selected_column] = 'O';
                break;
            }

        }
    }

    public bool check_cols() {
        for (int col = 0; col < num_cols; col++) {
            char curr_char = this.game_state[0, col];
            for (int row = 0; row < num_rows; row++) {
                if (curr_char == 'E') {
                    break;
                }
                if (this.game_state[row, col] != curr_char) {
                    break;
                }
                if (num_rows-1 == row && this.game_state[row,col] == curr_char) {
                    Console.WriteLine($"Winner in column {col}");
                    return true;
                }
            }
        }
        return false;
    }

    public bool check_rows() {
        for (int row = 0; row < num_rows; row++) {
            char curr_char = this.game_state[row, 0];
            for (int col = 0; col < num_cols; col++) {
                if (curr_char == 'E') {
                    break;
                }
                if (this.game_state[row, col] != curr_char) {
                    break;
                }
                if (num_cols-1 == col && this.game_state[row,col] == curr_char) {
                    Console.WriteLine($"Winner in row {row}");
                    return true;
                }
            }
        }
        return false;
    }
    public bool check_diags() {
        char init_char = this.game_state[0, 0];
        for (int row = 0; row < this.num_rows; row++) {
            int col = row;
            if (init_char == 'E') {
                break;
            }
            if (this.game_state[row, col] != init_char) {
                break;
            }
            if (row == num_rows-1 && this.game_state[row,col] == init_char) {
                return true;
            }
        }

        init_char = this.game_state[this.num_rows-1, 0];
        for (int row = 2; row >= 0; row--) {
            int col = num_rows - row - 1;
            if (init_char == 'E') {
                break;
            }
            if (this.game_state[row, col] != init_char) {
                break;
            }
            if (row == 0 && this.game_state[row,col] == init_char) {
                Console.WriteLine("Winner in Diagonal");
                return true;
            }
        }

        return false;
    }

    public bool check_board() {
        return this.check_cols() ||
        this.check_rows() ||
        this.check_diags();
    }

    public char[,] game_state;
    public int num_cols = 3;
    public int num_rows = 3;
}
