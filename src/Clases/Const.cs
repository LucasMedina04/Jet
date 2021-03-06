namespace Clases;

static class Const
{
    public static bool GameEnded = false;
    public static bool GamePaused = false;
    public static bool Shoping = false;
    public static bool GeneratingLevel = false;
    public const byte ENEMY_POS = 1;
    public const byte SHOOT_POS = 2;
    public const byte PLAYER_POS = 28;
    public const byte MAX_LIVES = 3;
    public const byte MAX_HEALTH = 100;
    public const byte MAX_SHIELD = 100;
    public const byte MAX_FUEL = 100;
    public const byte MAX_BULLET_SPEED = 10;
    public const byte MAX_DAMAGE = 10;
    public const uint MAX_MONEY = 10000;
    public const uint MAX_ENEMIES = 30;
    public const byte WINDOW_WIDTH = 36;
    public const byte WINDOW_HEIGHT = 29;
    public static List<string> Top10 = new List<string>();
}