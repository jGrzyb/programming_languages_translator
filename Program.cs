using System.Net;

public class Pr {
    public static void Main(string [] args) {
        string text = "";
        try {
            StreamReader sr = new StreamReader(args[0]);
            text = sr.ReadToEnd();
        } catch (Exception) {
            try {
                StreamReader sr = new StreamReader("C:\\Users\\Mateusz\\Documents\\studia\\kompilatory\\skaner\\Scanner.cd");
                text = sr.ReadToEnd();
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }
        Console.WriteLine(text);
        Scanner scanner = new();
        List<Token> tokens = scanner.getTokens(text);
        string path = "C:\\Users\\Mateusz\\Documents\\studia\\kompilatory\\skaner\\colored.html";
        Painter.paint(tokens, text, path);
    }
}