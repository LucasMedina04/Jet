namespace Clases;

public static class Begin
{
    public static void begin()
    {
        Console.Clear();
        if (CheckOS())
        {
            ShowControls();
            Top10.Generate();
            Game.Main();
        }
        else
        {
            Console.WriteLine("Incompatible OS");
            Console.ReadKey();
        }
    }
    public static void ShowControls()
    {
        Write.WriteAt("Controls:", Const.WINDOW_WIDTH / 2 - 10, 2);
        Write.WriteAt("[Left arrow] - Move left", Const.WINDOW_WIDTH / 2 - 10, 4);
        Write.WriteAt("[Right arrow] - Move right", Const.WINDOW_WIDTH / 2 - 10, 6);
        Write.WriteAt("[Spacebar] - Shoot", Const.WINDOW_WIDTH / 2 - 10, 8);
        Write.WriteAt("[Escape] - Pause / Resume", Const.WINDOW_WIDTH / 2 - 10, 10);
        Write.WriteAt("Press [Enter] to continue", Const.WINDOW_WIDTH / 2 - 10, 14);
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        Console.Clear();
    }
    public static bool CheckOS()
    {
        //Check if the OS is Windows or Linux
        if (Environment.OSVersion.Platform == PlatformID.Win32NT || Environment.OSVersion.Platform == PlatformID.Unix)
            return true;
        else return false;
    }
}
class Top10
{
    static string path = "";
    public static void Generate()
    {
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            // Windows path
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(path + "\\Jet"))
                Directory.CreateDirectory(path + "\\Jet");
            path += "\\Jet\\Top10.txt";
            if (!File.Exists(path))
                File.Create(path);
            else
            {
                List<string> list = new List<string>();
                StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    list.Add(line);
                }
                reader.Close();
                Const.Top10 = list;
            }
        }
        else
        {
            // Linux path
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(path + "/Jet"))
                Directory.CreateDirectory(path + "/Jet");
            path += "/Jet/Top10.txt";
            if (!File.Exists(path))
                File.Create(path);
            else
            {
                List<string> list = new List<string>();
                StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                        list.Add(line);
                }
                reader.Close();
                Const.Top10 = list;
            }
        }
    }
    public static void Update()
    {
        List<string> list = new List<string>();
        Sort();
        List<string> top10 = Const.Top10.GetRange(0, 10);
        foreach (string s in top10)
            list.Add(s);
        StreamWriter writer = new StreamWriter(path);
        foreach (string s in list)
            writer.WriteLine(s);
        writer.Close();
    }
    static void Sort()
    {
        //Top10 format: name: score
        List<string> list = new List<string>();
        foreach (string s in Const.Top10)
            list.Add(s);
        list.Sort((a, b) =>
        {
            uint aScore = uint.Parse(a.Split(':')[1]);
            uint bScore = uint.Parse(b.Split(':')[1]);
            if (aScore > bScore)
                return 1;
            else if (aScore < bScore)
                return -1;
            else
                return 0;
        });
        Const.Top10 = list;
    }
}