namespace Clases;

class Level
{
    public static void Update(List<EnemyType> Enemies)
    {
        for (int i = 0; i < Enemies.Count; i++)
            EnemyController.AddEnemy(Enemies[i]);
    }
}
static class LevelController
{
    static uint level;
    public static uint Level_ => level;
    static byte dificulty => Convert.ToByte(level / 5);
    static List<EnemyType> list = new();
    public static void Restart()
        => level = 0;
    public static void Update()
    {
        level++;
        list.Clear();
        Verifications.Clear();
        int lenght = level.ToString().Length / 2;
        Write.WriteAt("Loading level " + level, Const.WINDOW_WIDTH / 2 - (7 - lenght), Const.WINDOW_HEIGHT / 2, ConsoleColor.Green);
        Random rnd = new(DateTime.Now.Millisecond);
        list.Clear();
        if (level % 5 == 0) AddBoss();
        if (level % 15 == 0) AddBoss();
        if (level % 30 == 0) AddBoss();
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
            
        }
        else
        {
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
        Level.Update(list);
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