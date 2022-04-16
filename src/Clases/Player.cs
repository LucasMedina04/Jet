namespace Clases;
public static class Player
{
    public static byte pos;
    public static byte Pos => pos;
    static uint score;
    public static uint Score => score;
    static byte lives;
    public static byte Lives => lives;
    static byte level;
    public static byte Level => level;
    static byte health;
    public static byte Health => health;
    static byte shield;
    public static byte Shield => shield;
    static byte fuel;
    public static byte Fuel => fuel;
    static byte bulletSpeed;
    public static byte BulletSpeed => bulletSpeed;
    static byte damage;
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
        bulletSpeed = 0;
        damage = 00;
        money = 0;
    }
}
