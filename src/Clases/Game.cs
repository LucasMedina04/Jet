namespace Clases;

public class Game
{
    public static Task GameTask = new Task(() => { });
    public static void Main()
    {
        GameTask = Task.Run(() =>
        {
            do
            {
                Frame();
                if (Const.GamePaused)
                {
                    
                }
                else
                {
                    Update();
                }
            } while (true);
        });
    }
    public static void Update()
    {
        
    }
    static void Pause() => Const.GamePaused = true;
    static void Resume() => Const.GamePaused = false;
    /*public static void Main()
    {
        Console.CursorVisible = false;
        Console.Title = "Jet";
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Write.WriteAt("Loading...", Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
        Start();
    }*/
    public static void Finallice()
    {
        Console.Clear();
        Console.WriteLine("Game Over");
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        Environment.Exit(0);
    }
    static void PauseTask()
    {
        ConsoleKey key;
        do
        {
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                Pause();
            }
        } while (true);
    }
    static void Frame() => Thread.Sleep(1000/30);
}