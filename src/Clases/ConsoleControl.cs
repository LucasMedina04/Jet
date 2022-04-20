namespace Clases;
using static Clases.Const;

static class Write
{
    public static void WriteAt(string text, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }
    public static void WriteAt(string text, int x, int y, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        WriteAt(text, x, y);
        Console.ResetColor();
    }
    public static void WriteAt(string text, int x, int y, ConsoleColor color, ConsoleColor background)
    {
        Console.ForegroundColor = color;
        Console.BackgroundColor = background;
        WriteAt(text, x, y);
        Console.ResetColor();
    }
}
static class Menus
{
    
}
static class UI
{
    static void WriteFrames()
    {
        Write.WriteAt("╔", 0, 0);
        Write.WriteAt("╗", WINDOW_WIDTH, 0);
        Write.WriteAt("╚", 0, WINDOW_HEIGHT);
        Write.WriteAt("╝", WINDOW_WIDTH, WINDOW_HEIGHT);

        Write.WriteAt("╔", WINDOW_WIDTH + 1, 0);
        Write.WriteAt("╗", 57, 0);
        Write.WriteAt("╚", WINDOW_WIDTH + 1, WINDOW_HEIGHT);
        Write.WriteAt("╝", 57, WINDOW_HEIGHT);
        for (int i = 1; i < WINDOW_HEIGHT; i++)
        {
            Write.WriteAt("║", 0, i);
            Write.WriteAt("║", WINDOW_WIDTH, i);
        }
        for (int i = 1; i < WINDOW_WIDTH; i++)
        {
            Write.WriteAt("═", i, 0);
            Write.WriteAt("═", i, WINDOW_HEIGHT);
        }
        for (int i = 1; i < WINDOW_HEIGHT; i++)
        {
            Write.WriteAt("║", WINDOW_WIDTH + 1, i);
            Write.WriteAt("║", 57, i);
        }
        for (int i = WINDOW_WIDTH + 2; i < 57; i++)
        {
            Write.WriteAt("═", i, 0);
            Write.WriteAt("═", i, WINDOW_HEIGHT);
        }
    }
    static void WriteLives()
    {
        Write.WriteAt("Lives: ", WINDOW_WIDTH + 2, 1);
        if (Player.Lives == 3)
            Write.WriteAt("♥   ♥   ♥", WINDOW_WIDTH + 10, 1, ConsoleColor.Red);
        else if (Player.Lives == 2)
            Write.WriteAt("♥   ♥    ", WINDOW_WIDTH + 10, 1, ConsoleColor.Red);
        else Write.WriteAt("♥        ", WINDOW_WIDTH + 10, 1, ConsoleColor.Red);
        /*for (int i = 0; i < Player.Lives * 2; i = i + 2)
            Write.WriteAt("♥", WINDOW_WIDTH + 10 + (i * 2), 1, ConsoleColor.Red);*/
    }
    static void WriteScore()
    {
        Write.WriteAt("Score: ", WINDOW_WIDTH + 2, 4);
        Write.WriteAt(Player.Score.ToString(), WINDOW_WIDTH + 9, 4, ConsoleColor.DarkCyan);
    }
    static void WriteMoney()
    {
        Write.WriteAt("Money: ", WINDOW_WIDTH + 2, 7);
        Write.WriteAt("$" + Player.Money.ToString(), WINDOW_WIDTH + 9, 7, ConsoleColor.Yellow);
    }
    static void WriteLevel()
    {
        /*Write.WriteAt("Level: ", WINDOW_WIDTH + 2, 10);
        Write.WriteAt(Player.Level.ToString(), WINDOW_WIDTH + 9, 10, ConsoleColor.Green);*/
    }
    static void WriteFuel()
    {
        Write.WriteAt("Fuel: ", WINDOW_WIDTH + 2, 13);
        Write.WriteAt(Player.Fuel.ToString() + "%  ", WINDOW_WIDTH + 9, 13, ConsoleColor.DarkBlue);
        for (int i = 0; i < 19; i++)
        {
            Write.WriteAt(" ", i + WINDOW_WIDTH + 2, 14);
        }
        for (int i = 10; i < 100; i += 10)
        {
            if (Player.Fuel >= i)
                Write.WriteAt("█", WINDOW_WIDTH + 1 + (2 * (i / 10)), 14, ConsoleColor.DarkBlue);
            else break;
        }
    }
    static void WriteShield()
    {
        Write.WriteAt("Shield: ", WINDOW_WIDTH + 2, 16);
        Write.WriteAt(Player.Shield.ToString() + "%  ", WINDOW_WIDTH + 10, 16, ConsoleColor.DarkMagenta);
        for (int i = 0; i < 19; i++)
        {
            Write.WriteAt(" ", i + WINDOW_WIDTH + 2, 17);
        }
        for (int i = 10; i < 100; i += 10)
        {
            if (Player.Shield >= i)
                Write.WriteAt("█", WINDOW_WIDTH + 1 + (2 * (i / 10)), 17, ConsoleColor.DarkMagenta);
            else break;
        }
    }
    static void WriteHealth()
    {
        Write.WriteAt("Health: ", WINDOW_WIDTH + 2, 19);
        Write.WriteAt(Player.Health.ToString() + "%  ", WINDOW_WIDTH + 10, 19, ConsoleColor.DarkRed);
        for (int i = 0; i < 19; i++)
        {
            Write.WriteAt(" ", i + WINDOW_WIDTH + 2, 20);
        }
        for (int i = 10; i < 100; i += 10)
        {
            if (Player.Health >= i)
                Write.WriteAt("█", WINDOW_WIDTH + 1 + (2 * (i / 10)), 20, ConsoleColor.DarkRed);
            else break;
        }
    }
    static void WriteBulletSpeed()
    {
        Write.WriteAt("Bullet Speed: ", WINDOW_WIDTH + 2, 23);
        Write.WriteAt(Player.BulletSpeed.ToString() + "  ", WINDOW_WIDTH + 16, 23, ConsoleColor.DarkYellow);
        for (int i = 0; i < 19; i++)
        {
            Write.WriteAt(" ", i + WINDOW_WIDTH + 2, 24);
        }
        for (int i = 1; i < 10; i++)
        {
            if (Player.BulletSpeed >= i)
                Write.WriteAt("█", WINDOW_WIDTH + 1 + (2 * i), 24, ConsoleColor.DarkYellow);
            else break;
        }
    }
    static void WriteDamage()
    {
        Write.WriteAt("Bullet Damage: ", WINDOW_WIDTH + 2, 26);
        Write.WriteAt(Player.ShootDamage.ToString() + "  ", WINDOW_WIDTH + 17, 26, ConsoleColor.DarkYellow);
        for (int i = 0; i < 19; i++)
        {
            Write.WriteAt(" ", i + WINDOW_WIDTH + 2, 27);
        }
        for (int i = 5; i < 50; i++)
        {
            if (Player.ShootDamage >= i)
                Write.WriteAt("█", WINDOW_WIDTH + 1 + (2 * (i / 5)), 27, ConsoleColor.DarkYellow);
            else break;
        }
    }
    public static void WritePause()
        => Write.WriteAt("Game paused", WINDOW_WIDTH / 2 - 5, WINDOW_HEIGHT / 2, ConsoleColor.Red);
    public static void WriteAll()
    {
        WriteFrames();
        WriteLives();
        WriteScore();
        WriteMoney();
        WriteLevel();
        WriteFuel();
        WriteShield();
        WriteHealth();
        WriteBulletSpeed();
        WriteDamage();
    }
    public static void UpdateHealth()
    {
        WriteLives();
        WriteShield();
        WriteHealth();
    }
    public static void UpdateBulletSpeed()
        => WriteBulletSpeed();
    public static void UpdateDamage()
        => WriteDamage();
}