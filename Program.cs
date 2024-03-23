using System.Net;

public class Pr {
    public static void Main(string [] args) {
        string text = "";
        try {
            StreamReader sr = new StreamReader(args[0]);
            text = sr.ReadToEnd();
        } catch (Exception) {
            try {
                StreamReader sr = new StreamReader("Scanner.cs");
                text = sr.ReadToEnd();
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }
        Console.WriteLine(text);
        Scanner scanner = new();
        List<Token> tokens = scanner.getTokens(text);
        string path = "colored.html";
        Painter.paint(tokens, text, path);
    }
}