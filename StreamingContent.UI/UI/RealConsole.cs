
public class RealConsole : IConsole
{
    public void Clear()
    {
        Console.Clear();
    }

    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    public string ReadLine()
    {
        return Console.ReadLine()!;
    }

    public void Write(string o)
    {
        Console.Write(o);
    }

    public void WriteLine(string s)
    {
        System.Console.WriteLine(s);
    }

    public void WriteLine(object o)
    {
        System.Console.WriteLine(o);
    }
}
