namespace Clases;

public class Game
{
    static byte frame = 0;
    public static byte Frame => frame;
    public static void Main()
    {
        Console.Title = "Jet";
        Console.Clear();
        Console.CursorVisible = false;
        Write.WriteAt("Loading...", Const.WINDOW_WIDTH / 2 - 5, Const.WINDOW_HEIGHT / 2, ConsoleColor.Yellow);
        UI.WriteAll();
        EnemyController.AddEnemy(EnemyType.Strong);
        EnemyController.AddEnemy(EnemyType.Basic);
        EnemyController.AddEnemy(EnemyType.Fast);
        Player.Render();
        Write.WriteAt("          ", Const.WINDOW_WIDTH / 2 - 5, Const.WINDOW_HEIGHT / 2);
        Thread SubHilo = new Thread(()=>
        {
            while (true)
            {
                Fps();
                if (!Const.GamePaused)
                Update();
            }
        });
        SubHilo.Start();
        while (true)
        {
            ReadKey();
        }
    }
    static void ReadKey()
        => Verifications.CheckKey(Console.ReadKey(true));
    static void Update()
    {
        Player.Update();
        EnemyController.Update();
    }
    internal static void Finallice()
    {
        Console.Clear();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        Environment.Exit(0);
    }
    static void Fps()
    {
        Thread.Sleep(1000/7);
        if (frame < 11)
        frame++;
        else frame = 0;
    }
    public static void EndGame()
    {
        Const.GameEnded = true;
        Write.WriteAt("GAME OVER", Const.WINDOW_WIDTH / 2 - 6, Const.WINDOW_HEIGHT / 2, ConsoleColor.Red);
    }
}

static class Verifications
{
    public static void CheckKey(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.Escape)
        {
            Pause();
            return;
        }
        if (!Const.GamePaused)
        {
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Pause();
                    break;
                case ConsoleKey.LeftArrow:
                    Player.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    Player.MoveRight();
                    break;
                default:
                    Player.Render();
                    break;
                case ConsoleKey.Spacebar:
                    Player.Shoot();
                    break;
                
                /*Debug*/
                case ConsoleKey.F1:
                    Player.AddBulletSpeed();
                    UI.UpdateBulletSpeed();
                    break;
                case ConsoleKey.F2:
                    Player.DissmissBulletSpeed();
                    UI.UpdateBulletSpeed();
                    break;
                case ConsoleKey.F3:
                    Player.AddDamage();
                    UI.UpdateDamage();
                    break;
                case ConsoleKey.F4:
                    Player.DissmissDamage();
                    UI.UpdateDamage();
                    break;
                case ConsoleKey.F5:
                    Player.Damage(5, false);
                    break;
                case ConsoleKey.F6:
                    Player.Damage(5, true);
                    break;
                case ConsoleKey.F7:
                    Player.AddShield(10);
                    UI.UpdateHealth();
                    break;
                case ConsoleKey.F8:
                    Game.EndGame();
                    break;
                /*Debug*/
            }
        }
    }
    static void Pause()
    {
        if (Const.GamePaused)
        {
            Write.WriteAt("      ", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2);
            Const.GamePaused = false;
        }
        else
        {
            Write.WriteAt("PAUSED", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2, ConsoleColor.Red);
            Const.GamePaused = true;
        }
    }
}