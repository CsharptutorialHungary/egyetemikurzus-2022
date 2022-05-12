# Project Amoba
Console amoeba (amőba) game written in C#.

## Usage

Play a new game: 
        
    play size_of_board game_mode
    
Replay a saved game: 
        
    replay path_to_game_file pause_time_between_turns_in_ms

Game modes:

    0 - Local multiplayer
    1 - Against random AI
    2 - Random AI vs random AI

## Board

Board size: 5x5-100x100
    
## Game rules

First player to place 5 symbols (O or X) in a line (row, column, diagonal) wins.
