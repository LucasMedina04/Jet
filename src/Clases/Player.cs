namespace Clases;
public static class Player
{
    public static byte pos;
    public static byte Pos => pos;
    static ulong score;
    public static ulong Score => score;
    static byte lives = Const.MAX_LIVES;
    public static byte Lives => lives;
    static int level;
    public static int Level => level;
    static byte health = Const.MAX_HEALTH;
    public static byte Health => health;
    static byte shield = 0;
    public static byte Shield => shield;
    static byte fuel = Const.MAX_FUEL;
    public static byte Fuel => fuel;
    static byte bulletSpeed = 1;
    public static byte BulletSpeed => bulletSpeed;
    static byte damage = 8;
    public static byte Damage => damage;
    static int money;
    public static int Money => money;
    public static bool isDead => health <= 0;
    public static bool isShielded => shield > 0;
    public static bool isFueled => fuel > 0;

    public static void AddScore(uint Score)
        => score += Score;
    public static void AddLive()
        => lives++;
    public static void DismissLife()
        => lives--;
    public static void AddLevel()
        => level++;
    public static void AddHealth(byte Health)
        => health += Health;
    public static void DissmissHealth(byte Health)
        => health -= Health;
    public static void AddShield(byte Shield)
        => shield += Shield;
    public static void DismissShield(byte Shield)
        => shield -= Shield;
    public static void AddFuel(byte Fuel)
        => fuel += Fuel;
    public static void DismissFuel(byte Fuel)
        => fuel -= Fuel;
    public static void AddBulletSpeed()
        => bulletSpeed++;
    public static void AddDamage()
        => damage++;
    public static void AddMoney(int Money)
        => money += Money;
    public static void SubstractMoney(int Money)
        => money -= Money;
    public static void ResetAll()
    {
        score = 0;
        lives = 3;
        level = 1;
        health = 100;
        shield = 0;
        fuel = 100;
        bulletSpeed = 1;
        damage = 8;
        money = 0;
    }
}
