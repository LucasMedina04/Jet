namespace Clases;

public class Enemy
{
    public byte pos;
    byte health;
    public byte Health => health;
    public bool isDead => health <= 0;
    public bool canShoot;
    public EnemyShoot shoot;
    ConsoleColor color;
    public Enemy(byte pos, EnemyType type)
    {
        this.pos = pos;
        shoot = new EnemyShoot(type);
        switch (type)
        {
            case EnemyType.Basic:
                health = 20;
                color = ConsoleColor.Red;
                break;
            case EnemyType.Fast:
                health = 30;
                color = ConsoleColor.Yellow;
                break;
            case EnemyType.Strong:
                health = 60;
                color = ConsoleColor.Green;
                break;
            case EnemyType.AntiArmor:
                health = 40;
                color = ConsoleColor.Cyan;
                break;
            case EnemyType.Boss:
                health = 200;
                color = ConsoleColor.Magenta;
                break;
        }
    }
    void Render()
    {
        if (!isDead)
        {
            Console.SetCursorPosition(pos, 0);
            Console.ForegroundColor = color;
            Console.Write("<O>");
            Console.ResetColor();
        }
        else
        {
            Console.SetCursorPosition(pos, 0);
            Console.Write(" ");
        }
    }
    public void MoveLeft()
    {
        if (!isDead)
        {
            Console.SetCursorPosition(pos, 0);
            Console.Write(" ");
            pos--;
            Render();
        }
    }
    public void MoveRight()
    {
        if (!isDead)
        {
            Console.SetCursorPosition(pos, 0);
            Console.Write(" ");
            pos++;
            Render();
        }
    }
    public void Damage()
    {
        health -= Player.Damage;
        if (isDead)
        {
            Console.SetCursorPosition(pos, 0);
            Console.Write(" ");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Thread.Sleep(100);
            Render();
        }
    }
    public void Shoot()
        => shoot.Shoot(pos);
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
    public byte posX;
    public byte posY;
    public byte speed;
    public byte damage;
    public bool armorPenetration;
    public bool isDead;
    ConsoleColor color;
    public EnemyShoot(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Basic:
                speed = 6;
                damage = 8;
                armorPenetration = false;
                color = ConsoleColor.Red;
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
                color = ConsoleColor.Green;
                break;
            case EnemyType.AntiArmor:
                speed = 5;
                damage = 10;
                armorPenetration = true;
                color = ConsoleColor.Cyan;
                break;
            case EnemyType.Boss:
                speed = 3;
                damage = 25;
                armorPenetration = true;
                color = ConsoleColor.Magenta;
                break;
        }
    }
    public void Shoot(byte pos)
    {
        if (!isDead)
        {
            Console.SetCursorPosition(posX, posY + pos);
            Console.ForegroundColor = color;
            Console.Write("|");
            Console.ResetColor();
            posX = pos;
        }
    }
}
