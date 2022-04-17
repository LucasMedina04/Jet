using Clases;
using static Clases.Const;

Console.Title = "Jet";
Console.Clear();
Console.CursorVisible = false;
Write.WriteAt("Loading...", WINDOW_WIDTH / 2 - 5, WINDOW_HEIGHT / 2);
UI.WriteAll();
Write.WriteAt("          ", WINDOW_WIDTH / 2 - 5, WINDOW_HEIGHT / 2);
Console.ReadKey();