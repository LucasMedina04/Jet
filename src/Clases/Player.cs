namespace Clases;
public static class Player
{
    public static List<PlayerShoot> shoots = new List<PlayerShoot>();
    public static byte pos = Const.WINDOW_WIDTH / 2;
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
    public static byte ShootDamage => damage;
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
    public static byte DismissShield(byte Shield)
    {
        int aux = Convert.ToInt32(shield) - Convert.ToInt32(Shield);
        shield -= Shield;
        if (aux < 0)
            {
                shield = 0;
                return Convert.ToByte(-aux);
            }
        else return 0;
    }
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
    public static void Render()
    {
        Write.WriteAt("<O>", pos - 1, Const.PLAYER_POS);
        if (isShielded)
            Write.WriteAt("S", pos, Const.PLAYER_POS);
    }
    public static void MoveLeft()
    {
        if (pos > 2)
        {
            Write.WriteAt(" ", pos + 1, Const.PLAYER_POS);
            pos--;
            Render();
        }
    }
    public static void MoveRight()
    {
        if (pos < Const.WINDOW_WIDTH - 2)
        {
            Write.WriteAt(" ", pos - 1, Const.PLAYER_POS);
            pos++;
            Render();
        }
    }
    public static void Update()
    {
        if (shoots is not null)
        {
            for (int i = 0; i < shoots.Count; i++)
            {
                for (int j = 0; j < EnemyController.enemies.Count; j++)
                {
                    if (shoots[i].posY == 1)
                    {
                        Write.WriteAt(" ", shoots[i].posX, 2);
                        shoots.RemoveAt(i);
                        i--;
                        continue;
                    }
                    else shoots[i].Update();
                }
            }
        }
    }
    public static void UpdateHealth()
    {
        UI.UpdateHealth();
    }
    public static void Shoot()
    {
        shoots.Add(new PlayerShoot(pos));
    }
    public static void Damage(byte Damage, bool AntiArmor)
    {
        if (AntiArmor)
        {
            DissmissHealth(Damage);
            DismissShield(Convert.ToByte(2 * Damage));
        }
        else DissmissHealth(DismissShield(Damage));
        UpdateHealth();
    }
}

public class PlayerShoot
{
    public byte posX;
    public byte posY = Const.PLAYER_POS - 1;
    byte speed = Player.BulletSpeed;

    public PlayerShoot(byte Pos)
        => posX = Pos;
    public void Update()
    {
        switch (speed)
        {
            case 1:
                if (Game.Frame % 11 == 0)
                    Move();
                break;
            case 2:
                if (Game.Frame % 10 == 0 )
                    Move();
                break;
            case 3:
                if (Game.Frame % 9 == 0)
                    Move();
                break;
            case 4:
                if (Game.Frame % 8 == 0)
                    Move();
                break;
            case 5:
                if (Game.Frame % 7 == 0)
                    Move();
                break;
            case 6:
                if (Game.Frame % 6 == 0)
                    Move();
                break;
            case 7:
                if (Game.Frame % 5 == 0)
                    Move();
                break;
            case 8:
                if (Game.Frame % 4 == 0)
                    Move();
                break;
            case 9:
                if (Game.Frame % 3 == 0)
                    Move();
                break;
            case 10:
                if (Game.Frame % 2 == 0)
                    Move();
                break;
        }
    }
    void Move()
    {
        Write.WriteAt("^", posX, posY);
        if (posY != Const.PLAYER_POS - 1)
        Write.WriteAt(" ", posX, posY + 1);
        posY--;
    }
}