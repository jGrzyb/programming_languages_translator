public class FileReader {

    public static string getLines(string path) {
        string lines = "";
        try {
            StreamReader sr = new StreamReader(path);
            string? line = sr.ReadLine();
            while(line != null) {
                lines += line + "\n";
                line = sr.ReadLine();
            }
            lines = lines.Substring(0, lines.Length-1);
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
        lines = lines.Trim();
        return lines;
    }
}