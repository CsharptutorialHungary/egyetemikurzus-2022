using Amoba.Classes;

namespace Amoba
{
    internal class Program
    {
        private static int? GameMode;
        private static int? BoardSize;
        private static string? Mode;
        public static readonly string PLAY_MODE = "play";
        public static readonly string REPLAY_MODE = "replay";
        static int Main(string[] args)
        {
            if (args.Length == 0 || args.Length == 1 || 3 < args.Length)
            {
                Console.WriteLine("Invalid arguments!\nExample usages:\n\n     Play a new game: play size_of_board game_mode\n     Replay a saved game: replay path_to_game_file");
                return 1;
            }
            if (!GameEngine.IsValidEngineMode(args[0]))
            {
                Console.WriteLine($"{args[0]} is an invalid mode!\nAvailable modes: play, replay");
                return 2;
            }
            Mode = args[0];
            if (args.Length == 3)
            {
                bool boardSizeParseRes = int.TryParse(args[1], out int boardSize);
                if (!boardSizeParseRes)
                {
                    Console.WriteLine("The required board size is an invalid integer!");
                    return 3;
                }
                bool gameModeParseRes = int.TryParse(args[2], out int gameMode);
                if (!gameModeParseRes || gameMode < 0 || 2 < gameMode)
                {
                    Console.WriteLine("The required game mode is invalid!");
                    return 4;
                }
                BoardSize = boardSize;
                GameMode = gameMode;
            }
            
            if (GameMode.HasValue && BoardSize.HasValue && Mode == GameEngine.PLAY_MODE)
            {
                try
                {
                    var gameMode = GameEngine.IntToGameMode(GameMode.Value);
                    var reporter = new GameReporter(gameMode);
                    var engine = new GameEngine(reporter, BoardSize.Value);
                    engine.StartNewGame(gameMode);
                } 
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"GameEngine error: {ex.Message}");
                }
                
            } 
            else
            {
                var reporter = new GameReporter();
                var task = Task.Run( async () => 
                    {
                        try
                        {
                            await reporter.ReplayGameAsync(args[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"GameReporter error: {ex.Message}");
                        }
                        
                    } 
                );
                task.Wait();
            } 
            
            return 0;
        }
    }
}
