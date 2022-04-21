namespace Clases;

static class Shop
{
    public static void Open()
    {
        Const.Shoping = true;
        Verifications.Clear();
        Write.WriteAt("SHOP", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2, ConsoleColor.Green);
        Write.WriteAt("1. Health", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 2, ConsoleColor.Green);
        Write.WriteAt("2. Shield", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 3, ConsoleColor.Green);
        Write.WriteAt("3. Fuel", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 4, ConsoleColor.Green);
        Write.WriteAt("4. Bullet Speed", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 5, ConsoleColor.Green);
        Write.WriteAt("5. Damage", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 6, ConsoleColor.Green);
        Write.WriteAt("6. Money", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 7, ConsoleColor.Green);
        Write.WriteAt("7. Back", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 8, ConsoleColor.Green);
        Write.WriteAt("8. Exit", Const.WINDOW_WIDTH / 2 - 3, Const.WINDOW_HEIGHT / 2 + 9, ConsoleColor.Green);
        Console.ReadKey(true);
    }
}