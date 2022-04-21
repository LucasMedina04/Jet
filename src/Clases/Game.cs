namespace Clases;

public class Game
{
    public static bool debug = false;
    static byte frame = 0;
    public static byte Frame => frame;
    public static void Main()
    {
        Console.Title = "Jet";
        Console.Clear();
        Console.CursorVisible = false;
        NewGame();
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
        if (Player.GameOver)
            NewGame();
        if (EnemyController.Enemies == 0)
            LevelController.Update();
        /*Debug*/
        if (debug)
            Debug();
        /*Debug*/
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
        Verifications.Clear();
        Write.WriteAt("GAME OVER", Const.WINDOW_WIDTH / 2 - 6, Const.WINDOW_HEIGHT / 2, ConsoleColor.Red);
    }
    static void Debug()
    {
        Write.WriteAt("Frame: " + Frame + "  ", 58, 0);
        Write.WriteAt("Bullets: " + Player.shoots.Count + "  ", 58, 2);
        Write.WriteAt("Enemies: " + EnemyController.Enemies + "  ", 58, 4);
        Write.WriteAt("[F1] : Add Bullet Speed", 58, 6);
        Write.WriteAt("[F2] : Dismiss Bullet Speed", 58, 8);
        Write.WriteAt("[F3] : Add Bullet Damage", 58, 10);
        Write.WriteAt("[F4] : Dismiss Bullet Damage", 58, 12);
        Write.WriteAt("[F5] : Hit player by 5 damage", 58, 14);
        Write.WriteAt("[F6] : Hit player by 5 damage (armor penetration)", 58, 16);
        Write.WriteAt("[F7] : Add 10 Shield", 58, 18);
        Write.WriteAt("[F8] : Add 10 Health", 58, 20);
        Write.WriteAt("[F9] : Increase Level", 58, 22);
    }
    public static void NewGame()
    {
        LevelController.Restart();
        Player.ResetAll();
        EnemyController.Reset();
        LevelController.Update();
        Const.GameEnded = false;
        Const.GamePaused = false;
        UI.WriteAll();
        Player.Render();
        Thread.Sleep(1000);
        Write.WriteAt("                " + LevelController.Level_ , Const.WINDOW_WIDTH / 2 - (9 - Convert.ToInt32(LevelController.Level_)), Const.WINDOW_HEIGHT / 2);
        Update();
        new Thread(()=>
        {
            while (!Const.GameEnded)
            {
                Fps();
                if (!Const.GamePaused)
                Update();
            }
        }).Start();
    }
}

static class Verifications
{
    public static void CheckKey(ConsoleKeyInfo key)
    {
        if (!Const.GameEnded)
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
                        if (Game.debug)
                        {
                            Player.AddBulletSpeed();
                            UI.UpdateBulletSpeed();
                        }
                        break;
                    case ConsoleKey.F2:
                        if (Game.debug)
                        {
                            Player.DismissBulletSpeed();
                            UI.UpdateBulletSpeed();
                        }
                        break;
                    case ConsoleKey.F3:
                        if (Game.debug)
                        {
                            Player.AddDamage();
                            UI.UpdateDamage();
                        }
                        break;
                    case ConsoleKey.F4:
                        if (Game.debug)
                        {
                            Player.DismissDamage();
                            UI.UpdateDamage();
                        }
                        break;
                    case ConsoleKey.F5:
                        if (Game.debug)
                            Player.Damage(5, false);
                        break;
                    case ConsoleKey.F6:
                        if (Game.debug)
                            Player.Damage(5, true);
                        break;
                    case ConsoleKey.F7:
                        if (Game.debug)
                        {
                            Player.AddShield(10);
                            UI.UpdateHealth();
                        }
                        break;
                    case ConsoleKey.F8:
                        if (Game.debug)
                        {
                            Player.AddHealth(10);
                            UI.UpdateHealth();
                        }
                        break;
                    case ConsoleKey.F9:
                        if (Game.debug)
                            LevelController.Update();
                        break;
                    case ConsoleKey.F12:
                        if (Game.debug)
                        Game.debug = false;
                        else Game.debug = true;
                        break;
                    /*Debug*/
                }
            }
        }
        else
        {
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Game.Finallice();
                    break;
                case ConsoleKey.Enter:
                    Game.NewGame();
                    break;
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
    public static void Clear()
    {
        for (int i = 1; i < Const.WINDOW_WIDTH - 1; i++)
        {
            for (int j = 1; j < Const.WINDOW_HEIGHT - 1; j++)
            {
                Write.WriteAt(" ", i, j);
            }
        }
    }
}