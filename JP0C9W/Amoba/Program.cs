using Amoba.Classes;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Amoba.Tests")]
namespace Amoba
{
    internal class Program
    {
        internal static void StartEngine(int gameMode, int boardSize)
        {
            try
            {
                var mode = GameEngine.IntToGameMode(gameMode);
                var reporter = new GameReporter(mode);
                var engine = new GameEngine(reporter, boardSize);
                engine.StartNewGame(mode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GameEngine error: {ex.Message}");
            }
        }

        internal static void StartReporter(string file, int pauseTime)
        {
            var reporter = new GameReporter();
            var task = Task.Run(async () =>
            {
                try
                {
                    await reporter.ReplayGameAsync(file, pauseTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GameReporter error: {ex.Message}");
                }
            }
            );
            task.Wait();
        }

        internal static void Initialize(string[] args)
        {
            if (args.Length != 3)
            {
                throw new Exception(
                    "Invalid arguments!\n" +
                    "Guide:\n\n" +
                    "   Play a new game: play size_of_board game_mode\n" +
                    "   Replay a saved game: replay path_to_game_file pause_time_between_turns_in_ms\n" +
                    "\n" +
                    "   Game modes:\n\n" +
                    "       0 - Local multiplayer\n" +
                    "       1 - Against random AI\n" +
                    "       2 - Random AI vs random AI\n" +
                    "\n" +
                    "   Board sizes: 5-100\n" +
                    "\n" +
                    "   Rules: First player to place 5 symbols (O or X) in a line (row, column, diagonal) wins!"
                );
            }

            if (!GameEngine.IsValidEngineMode(args[0]))
            {
                throw new Exception($"{args[0]} is an invalid mode!\nCommands: play, replay");
            }
            var mode = args[0];

            if (mode == GameEngine.PLAY_MODE)
            {
                bool boardSizeParseResult = int.TryParse(args[1], out int boardSize);
                if (!boardSizeParseResult)
                {
                    throw new Exception("The required board size is an invalid integer!");
                }

                bool gameModeParseResult = int.TryParse(args[2], out int gameMode);
                if (!gameModeParseResult || gameMode < 0 || 2 < gameMode)
                {
                    throw new Exception(
                        "The required game mode is invalid!" +
                        "Game modes:\n\n" +
                        "   0 - Local multiplayer\n" +
                        "   1 - Against random AI\n" +
                        "   2 - Random AI vs random AI\n");
                }

                StartEngine(gameMode, boardSize);
            }
            else
            {
                if (!File.Exists(args[1]))
                {
                    throw new Exception("Game file doesn't exists!");
                }

                bool timeoutResult = int.TryParse(args[2], out int timeout);
                if (!timeoutResult || timeout < 0)
                {
                    throw new Exception($"{args[2]} is an invalid pause time!");
                }

                StartReporter(args[1], timeout);
            }
        }

        internal static int Main(string[] args)
        {
            try
            {
                Initialize(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }

            return 0;
        }
    }
}
