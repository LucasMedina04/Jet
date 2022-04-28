namespace Clases;

static class Shop
{
    static byte idx = 0;
    static byte idx2 = 0;
    static byte BulletSpeed = 0;
    static byte Damage = 0;
    static byte Bullets = 0;

    public static void Open()
    {
        if (!Const.GeneratingLevel)
        {
            Const.Shoping = true;
            Verifications.Clear();
            Update();
            WriteShop();
        }
    }
    public static void WriteShop()
    {
        Write.WriteAt("SHOP", Const.WINDOW_WIDTH / 2 - 3, 2, ConsoleColor.Green);
        Write.WriteAt("1. Health", 2, 5, ConsoleColor.Gray);
        Write.WriteAt("2. Shield", 2, 7, ConsoleColor.Gray);
        Write.WriteAt("3. Fuel", 2, 9, ConsoleColor.Gray);
        Write.WriteAt("4. Bullet Speed",2, 11, ConsoleColor.Gray);
        Write.WriteAt("5. Damage", 2, 13, ConsoleColor.Gray);
        Write.WriteAt("6. Bullets", 2, 15, ConsoleColor.Gray);
    }
    public static void Update()
    {
        switch (idx)
        {
            case 0:
                Write.WriteAt("< Buy for: 3000 >", 18, 5, ConsoleColor.Blue);
                break;
            case 1:
                Write.WriteAt("< Buy for: 3000 >", 18, 7, ConsoleColor.Blue);
                break;
            case 2:
                Write.WriteAt("< Buy for: 3000 >", 18, 9, ConsoleColor.Blue);
                break;
            case 3:
                Write.WriteAt("< Buy for: " + Bspd().ToString() + " >", 18, 11, ConsoleColor.Blue);
                break;
            case 4:
                Write.WriteAt("< Buy for: " + Dmg().ToString() + " >", 18, 13, ConsoleColor.Blue);
                break;
            case 5:
                Write.WriteAt("< Buy for: " + Blts().ToString() + " >", 18, 15, ConsoleColor.Blue);
                break;
        }
        ReWrite();
    }
    public static void Close()
    {
        Const.Shoping = false;
        LevelController.Next();
    }
    public static void MoveUp()
    {
        if (idx > 0)
        {
            idx2 = idx;
            idx--;
        }
        else
        {
            idx2 = idx;
            idx = 5;
        }
        Clear();
    }
    public static void MoveDown()
    {
        if (idx < 5)
        {
            idx2 = idx;
            idx++;
        }
        else
        {
            idx2 = idx;
            idx = 0;
        }
        Clear();
    }
    public static void Buy()
    {
        uint price = 0;
        switch (idx)
        {
            case 0:
                price = 3000;
                if (Verify(price))
                {
                    Player.AddHealth(30);
                    UI.UpdateHealth();
                }
                break;
            case 1:
                price = 3000;
                if (Verify(price))
                {
                    Player.AddShield(30);
                    UI.UpdateHealth();
                }
                break;
            case 2:
                price = 3000;
                if (Verify(price))
                {
                    Player.AddFuel(30);
                    UI.WriteAll();
                }
                break;
            case 3:
                price = Bspd();
                if (Verify(price))
                {
                    Player.AddBulletSpeed();
                    UI.UpdateBulletSpeed();
                }
                break;
            case 4:
                price = Dmg();
                if (Verify(price))
                {
                    Player.AddDamage();
                    UI.UpdateDamage();
                }
                break;
            case 5:
                price = Blts();
                if (Verify(price))
                {
                    Player.AddBullets();
                    UI.UpdateBullets();
                }
                break;
        }
    }
    static bool Verify(uint price)
    {
        if (Player.Money >= price)
        {
            Player.SubstractMoney(price);
            UI.UpdateMoney();
            return true;
        }
        else
        {
            NeM();
            return false;
        }
    }
    static void NeM()
        => Write.WriteAt("Not enough money", Const.WINDOW_WIDTH / 2 - 8, Const.WINDOW_HEIGHT - 3, ConsoleColor.Red);
    static void Clear()
        => Write.WriteAt("                ", Const.WINDOW_WIDTH / 2 - 8, Const.WINDOW_HEIGHT - 3);
    static uint Bspd()
    {
        uint price = 0;
        switch (BulletSpeed)
        {
            case 0:
                price = 5000;
                break;
            case 1:
                price = 7500;
                break;
            case 2:
                price = 10000;
                break;
            case 3:
                price = 12500;
                break;
            case 4:
                price = 15000;
                break;
            case 5:
                price = 17500;
                break;
            case 6:
                price = 20000;
                break;
            case 7:
                price = 22500;
                break;
            case 8:
                price = 25000;
                break;
            case 9:
                price = 27500;
                break;
            default:
                price = 99999;
                break;
        }
        return price;
    }
    static uint Dmg()
    {
        uint price = 0;
        switch (Damage)
        {
            case 0:
                price = 5000;
                break;
            case 1:
                price = 7500;
                break;
            case 2:
                price = 10000;
                break;
            case 3:
                price = 12500;
                break;
            case 4:
                price = 15000;
                break;
            case 5:
                price = 17500;
                break;
            case 6:
                price = 20000;
                break;
            case 7:
                price = 22500;
                break;
            case 8:
                price = 25000;
                break;
            case 9:
                price = 27500;
                break;
            default:
                price = 99999;
                break;
        }
        return price;
    }
    static uint Blts()
    {
        uint price = 0;
        switch (Bullets)
        {
            case 0:
                price = 5000;
                break;
            case 1:
                price = 7500;
                break;
            case 2:
                price = 10000;
                break;
            case 3:
                price = 12500;
                break;
            case 4:
                price = 15000;
                break;
            case 5:
                price = 17500;
                break;
            case 6:
                price = 20000;
                break;
            case 7:
                price = 22500;
                break;
            case 8:
                price = 25000;
                break;
            case 9:
                price = 27500;
                break;
            default:
                price = 99999;
                break;
        }
        return price;
    }
    static void ReWrite()
    {
        switch (idx2)
        {
            case 0:
                Cicle(5);
                break;
            case 1:
                Cicle(7);
                break;
            case 2:
                Cicle(9);
                break;
            case 3:
                Cicle(11);
                break;
            case 4:
                Cicle(13);
                break;
            case 5:
                Cicle(15);
                break;
        }
    }
    static void Cicle(byte x)
    {
        for (byte i = 18; i < Const.WINDOW_WIDTH; i++)
            Write.WriteAt(" ", i, x, ConsoleColor.Black);
    }
}