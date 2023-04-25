
public class FunConsole : IConsole
{
    public void ChangeColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void Clear()
    {
        Console.Clear();
        Console.BackgroundColor = RndColor();
    }

    private ConsoleColor RndColor()
    {
        Thread.Sleep(10);
        Random rnd = new Random();
        int colorIndex = rnd.Next(0, 16);  //0 -> 15
        return (ConsoleColor)colorIndex;
    }

    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    public string ReadLine()
    {
        string input = Console.ReadLine()!;
        Console.WriteLine("Ummm...");
        Console.Beep();
        Thread.Sleep(1000);

        System.Console.WriteLine("Your sure?");
        Console.Beep();
        Thread.Sleep(1000);

        System.Console.WriteLine("...okay?");
        return input;
    }

    public void ResetConsoleColor()
    {
        Console.ResetColor();
    }

    public void Write(string o)
    {
        foreach (char letter in o)
        {
            Console.ForegroundColor = RndColor();
            System.Console.Write(letter);
        }
    }

    public void WriteLine(string s)
    {
        //sPoNgEbOb lettering
        Console.ForegroundColor = RndColor();
        bool capitalize = false;
        foreach (var letter in s)
        {
            if (capitalize == true)
            {
                Console.ForegroundColor = RndColor();
                System.Console.Write(char.ToUpper(letter));
                capitalize = false;
            }
            else
            {
                Console.ForegroundColor = RndColor();
                System.Console.Write(char.ToLower(letter));
                capitalize = true;
            }
        }
        Thread.Sleep(50);
        System.Console.WriteLine("\n");
    }

    public void WriteLine(object o)
    {
        Console.ForegroundColor = RndColor();
        System.Console.WriteLine(o);
    }
}
