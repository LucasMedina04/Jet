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
        //Check OS
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            //Get documents folder path for windows
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Create Jet folder in path if not exists
            if (!Directory.Exists(path + "\\Jet"))
                Directory.CreateDirectory(path + "\\Jet");
            //Set path to Jet folder
            path += "\\Jet\\Top10.txt";
            //Create Top10.txt if not exists
            if (!File.Exists(path))
                File.Create(path);
            //else read Top10.txt
            else
            {
                //Create list to read Top10.txt
                List<string> list = new List<string>();
                //Open Top10.txt
                StreamReader reader = new StreamReader(path);
                //Read line by line
                while (!reader.EndOfStream)
                    //Add line to list
                    list.Add(reader.ReadLine());
                //Close reader
                reader.Close();
                //Set Top10
                Const.Top10 = list;
            }
        }
        else
        {
            //Get documents folder path for linux
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Create Jet folder in path if not exists
            if (!Directory.Exists(path + "/Jet"))
                Directory.CreateDirectory(path + "/Jet");
            //Set path to Jet folder
            path += "/Jet/Top10.txt";
            //Create Top10.txt if not exists
            if (!File.Exists(path))
                File.Create(path);
            //else read Top10.txt
            else
            {
                //Create list to read Top10.txt
                List<string> list = new List<string>();
                //Open Top10.txt
                StreamReader reader = new StreamReader(path);
                //Read line by line
                while (!reader.EndOfStream)
                    //Add line to list
                    list.Add(reader.ReadLine());
                //Close reader
                reader.Close();
                //Set Top10
                Const.Top10 = list;
            }
        }
    }
    public static void Update()
    {
        //Create list to write Top10.txt
        List<string> list = new List<string>();
        //Sort Top10 by score
        Sort();
        //Get top 10
        List<string> top10 = Const.Top10.GetRange(0, 10);
        //Write top 10
        foreach (string s in top10)
            list.Add(s);
        //Open Top10.txt
        StreamWriter writer = new StreamWriter(path + "\\Top10.txt");
        //Write top 10
        foreach (string s in list)
            writer.WriteLine(s);
        //Close writer
        writer.Close();
    }
    public static void Sort()
    {
        //Top10 format: name: score
        //Create list to sort Top10
        List<string> list = new List<string>();
        //Add Top10 to list
        foreach (string s in Const.Top10)
            list.Add(s);
        //Sort list by score
        list.Sort((a, b) =>
        {
            //Get score of a
            uint aScore = uint.Parse(a.Split(':')[1]);
            //Get score of b
            uint bScore = uint.Parse(b.Split(':')[1]);
            //Compare scores
            if (aScore > bScore)
                return 1;
            else if (aScore < bScore)
                return -1;
            else
                return 0;
        });
        //Set Top10
        Const.Top10 = list;
    }
}