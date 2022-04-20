namespace Clases;

class Level
{
    static List<EnemyType> enemies = new();
    static void Update(List<EnemyType> enemies)
        => Level.enemies = enemies;
}
static class LevelController
{
    static uint level;
    static byte dificulty => Convert.ToByte(level / 5);
    static List<EnemyType> list = new();
    static void Update()
    {
        Random rnd = new(DateTime.Now.Millisecond);
        list.Clear();
        if (level % 5 == 0) AddBoss();
        if (level % 15 == 0) AddBoss();
        if (level <= 10)
        {
            switch (level)
            {
                case 1:
                    AddBasic(2);
                    break;
                case 2:
                    AddBasic(3);
                    break;
                case 3:
                    AddBasic(2);
                    AddFast();
                    break;
                case 4:
                    AddBasic(2);
                    AddStrong();
                    break;
                case 5:
                    AddFast(2);
                    AddStrong();
                    AddAntiarmor();
                    break;
                case 6:
                    AddStrong(3);
                    AddFast();
                    break;
                case 7:
                    AddAntiarmor(2);
                    AddFast(2);
                    AddBasic(2);
                    break;
                case 8:
                    AddBasic(3);
                    AddStrong(2);
                    break;
                case 9:
                    AddStrong(3);
                    AddFast(2);
                    break;
                case 10:
                    AddAntiarmor(2);
                    AddStrong(2);
                    AddFast();
                    break;
            }
            return;
        }
        switch (rnd.Next(0,6))
        {
            case 0:
            AddBasic(2 * dificulty);
            AddFast(1 * dificulty);
            break;
            case 1:
            AddBasic(1 * dificulty);
            AddStrong(2 * dificulty);
            break;
            case 2:
            AddBasic(1 * dificulty);
            AddAntiarmor(2 * dificulty);
            break;
            case 3:
            AddFast(2 * dificulty);
            AddAntiarmor( 2 * dificulty);
            break;
            case 4:
            AddFast(1 * dificulty);
            AddStrong(2 * dificulty);
            break;
            case 5:
            AddAntiarmor(2 * dificulty);
            AddStrong(2 * dificulty);
            break;
        }
    }
    static void AddBasic()
        => list.Add(EnemyType.Basic);
    static void AddBasic(int times)
    {
        for (int i = 0; i < times; i++) AddBasic();
    }
    static void AddFast()
        => list.Add(EnemyType.Fast);
    static void AddFast(int times)
    {
        for (int i = 0; i < times; i++) AddFast();
    }
    static void AddAntiarmor()
        => list.Add(EnemyType.AntiArmor);
    static void AddAntiarmor(int times)
    {
        for (int i = 0; i < times; i++) AddAntiarmor();
    }
    static void AddStrong()
        => list.Add(EnemyType.Strong);
    static void AddStrong(int times)
    {
        for (int i = 0; i < times; i++) AddStrong();
    }
    static void AddBoss()
        => list.Add(EnemyType.Boss);
    static void AddBoss(int times)
    {
        for (int i = 0; i < times; i++) AddBoss();
    }
    static void AddLevel()
        => level++;
}