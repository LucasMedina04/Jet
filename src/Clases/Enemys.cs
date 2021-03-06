namespace Clases;

public class Enemy
{
    public byte posX;
    public byte posY = Const.ENEMY_POS;
    byte health;
    public byte Health => health;
    public bool isDead => health <= 0;
    public bool shooted;
    public EnemyShoot shoot;
    byte score;
    public uint Score => score;
    uint money;
    public uint Money => money;
    ConsoleColor color;
    public Enemy(byte pos, EnemyType type)
    {
        this.posX = pos;
        shoot = new EnemyShoot(type, pos, this);
        switch (type)
        {
            case EnemyType.Basic:
                health = 20;
                score = 10;
                money = 100;
                color = ConsoleColor.Green;
                break;
            case EnemyType.Fast:
                health = 30;
                score = 15;
                money = 150;
                color = ConsoleColor.Yellow;
                break;
            case EnemyType.Strong:
                health = 60;
                score = 30;
                money = 300;
                color = ConsoleColor.Red;
                break;
            case EnemyType.AntiArmor:
                health = 40;
                score = 20;
                money = 200;
                color = ConsoleColor.Cyan;
                break;
            case EnemyType.Boss:
                health = 200;
                score = 100;
                money = 1000;
                color = ConsoleColor.Magenta;
                break;
        }
        Render();
    }
    void Render()
        => Write.WriteAt("<O>", posX - 1, Const.ENEMY_POS, color);
    public void MoveLeft()
    {
        Write.WriteAt(" ", posX + 1, Const.ENEMY_POS);
        posX--;
        Render();
    }
    public void MoveRight()
    {
        Write.WriteAt(" ", posX - 1, Const.ENEMY_POS);
        posX++;
        Render();
    }
    public void Damage()
    {
        int aux = health - Player.ShootDamage;
        if (aux <= 0)
        {
            health = 0;
            return;
        }
        health -= Player.ShootDamage;
    }
    public void Update()
    {
        for (int i = 0; i < Player.shoots.Count; i++)
        {
            if ((Player.shoots[i].posX == posX || Player.shoots[i].posX == posX - 1|| Player.shoots[i].posX == posX + 1) && Player.shoots[i].posY == 1 + posY)
            {
                Player.shoots.RemoveAt(i);
                Write.WriteAt(" ", posX, posY + 1);
                i--;
                Damage();
            }
        }
        if (isDead)
            return;
        shoot.Update();
        if (new Random().Next(0,10) <= 4)
        {
            if (posX > 3)
            MoveLeft();
            else MoveRight();
        }
        else
        {
            if (posX < Const.WINDOW_WIDTH - 3)
            MoveRight();
            else MoveLeft();
        }
    }
}

public enum EnemyType
{
    Basic,
    Fast,
    Strong,
    AntiArmor,
    Boss
}

public class EnemyShoot
{
    byte posY = Const.SHOOT_POS;
    public byte PosY => posY;
    byte posX;
    public byte PosX => posX;
    byte speed;
    public byte Speed => speed;
    byte damage;
    bool armorPenetration;
    ConsoleColor color;
    Enemy enemy;
    public EnemyShoot(EnemyType enemyType, byte posX, Enemy enemy)
    {
        this.posX = posX;
        this.enemy = enemy;
        switch (enemyType)
        {
            case EnemyType.Basic:
                speed = 2;
                damage = 8;
                armorPenetration = false;
                color = ConsoleColor.Green;
                break;
            case EnemyType.Fast:
                speed = 7;
                damage = 7;
                armorPenetration = false;
                color = ConsoleColor.Yellow;
                break;
            case EnemyType.Strong:
                speed = 4;
                damage = 15;
                armorPenetration = false;
                color = ConsoleColor.Red;
                break;
            case EnemyType.AntiArmor:
                speed = 5;
                damage = 10;
                armorPenetration = true;
                color = ConsoleColor.Cyan;
                break;
            case EnemyType.Boss:
                speed = 4;
                damage = 25;
                armorPenetration = true;
                color = ConsoleColor.Magenta;
                break;
        }
    }
    public void Update()
    {
        switch (Speed)
        {
            case 2:
                if (Game.Frame % 10 == 0)
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
            case 7:
                if (Game.Frame % 5 == 0)
                    Move();
                break;
        }
        if (PosY == Const.PLAYER_POS)
        {
            if (Player.Pos == PosX || Player.Pos + 1 == PosX || Player.Pos - 1 == PosX)
                Player.Damage(damage, armorPenetration);
            Write.WriteAt(" ", PosX, PosY - 1);
            ResetShoot();
        }
        else
        {
            for (int i = 0; i < Player.shoots.Count; i++)
            {
                if (Player.shoots[i].posX == PosX)
                {
                    if (Player.shoots[i].posY <= PosY)
                    {
                        Write.WriteAt(" ", PosX, Player.shoots[i].posY + 1);
                        Player.shoots.RemoveAt(i);
                        Write.WriteAt(" ", PosX, PosY - 1);
                        ResetShoot();
                        break;
                    }
                }
            }
        }
    }
    void Move()
    {
        Write.WriteAt("|", posX, posY, color);
        if (posY != Const.SHOOT_POS)
        Write.WriteAt(" ", posX, posY - 1);
        posY++;
    }
    void ResetShoot()
    {
        Write.WriteAt(" ", posX, posY);
        posY = Const.SHOOT_POS;
        posX = enemy.posX;
    }
}

public static class EnemyController
{
    static List<Enemy> enemies = new List<Enemy>();
    public static uint Enemies
        => Convert.ToUInt32(enemies.Count);
    public static void AddEnemy(EnemyType type)
        => enemies.Add(new Enemy(Convert.ToByte(new Random().Next(2, Const.WINDOW_WIDTH - 1)), type));
    public static void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Update();
            if (enemies[i].isDead)
            {
                Player.AddScore(enemies[i].Score);
                Player.AddMoney(enemies[i].Money);
                UI.UpdateScore();
                Write.WriteAt("     ", enemies[i].posX - 2, Const.ENEMY_POS);
                Write.WriteAt(" ", enemies[i].shoot.PosX, enemies[i].shoot.PosY - 1);
                enemies.Remove(enemies[i]);
                i--;
            }
        }
    }
    public static void Reset()
        => enemies.Clear();
    public static byte GetEnemyHealth(int enemyIndex)
        => enemies[enemyIndex].Health;
}