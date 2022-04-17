namespace Clases;

class Level
{
    int level;
    int dificulty;
    public Level() => level = Player.Level;
    void UpdateDificulty()
    {
        if (level % 3 == 0) dificulty = level / 3;
    }
}
static class LevelController
{
    public static Level level = new Level();
    static void UpdateLevel()
        => level = new Level();
    
}