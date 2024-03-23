using System.Runtime.InteropServices;

public class Painter {
    public static void paint(List<Token> tokens, string text, string path) {
        string h1 = File.ReadAllText("C:\\Users\\Mateusz\\Documents\\studia\\kompilatory\\skaner\\h1");
        string h2 = File.ReadAllText("C:\\Users\\Mateusz\\Documents\\studia\\kompilatory\\skaner\\h2");
        string contents = "";
        for(int i=0; i<tokens.Count(); i++) {
            int start = tokens[i].location;
            int end = i+1 >= tokens.Count() ? text.Length : tokens[i+1].location;
            string orginal = text.Substring(start, end - start);
            string repaired = "";
            foreach(char c in orginal) {
                switch(c) {
                    case ' ': repaired += "&nbsp"; break;
                    case '\r': repaired += "<br>"; break;
                    default: repaired += c; break;
                }
            }
            contents += "<span class=\"" + TokenColor.GetColor(tokens[i].type) + "\">" + repaired + "</span>";
        }
        File.WriteAllText(path, h1 + contents + h2);
    }

}