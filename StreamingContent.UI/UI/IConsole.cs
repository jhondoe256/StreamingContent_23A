
public interface IConsole
{
    void WriteLine(string s);

    void WriteLine(object o);

    void Write(string o);

    void Clear();

    string ReadLine();

    ConsoleKeyInfo ReadKey();
}
