public class Scanner {
    string collector = "";
    string text = "";
    int pos = 0;
    int start = 0;
    List<Token> tokens = new();

    public List<Token> getTokens(string text) {
        collector = "";
        this.text = text;
        pos = 0;
        tokens = new();

        while(pos < text.Length-1) {
            scan(text[pos]);
            pos++;
        }
        return tokens;
    }

    public List<Token> getTokens() {
        return tokens;
    }

    public void scan(char symbol) {
        if(" \r\n".Contains(symbol) && collector.Length==0) {
            return;
        }
        switch(collector) {
            case "": collector += symbol; start = pos; break;
            case string s when isNumber(s): number(symbol); break;
            case string s when isWholeText(s): collector = text.Substring(start, text.Substring(start, pos-start).LastIndexOf('\"')+1); addToken(TokenType.TEXT); break;
            case string s when isText(s): collector += symbol; break;
            case string s when isCharText(s): charText(symbol); break;
            case string s when isSthPart(s): sthB(symbol); break;
            case "+": plus(symbol); break;
            case "-": minus(symbol); break;
            case "*": multiply(symbol); break;
            case "/": divide(symbol); break;
            case "%": addToken(TokenType.REST); break;
            case "=": equals(symbol); break;
            case "++": addToken(TokenType.PLUS_PLUS); break;
            case "--": addToken(TokenType.MINUS_MINUS); break;
            case "+=": addToken(TokenType.PLUS_EQUALS); break;
            case "-=": addToken(TokenType.MINUS_EQUALS); break;
            case "*=": addToken(TokenType.MINUS_EQUALS); break;
            case "/=": addToken(TokenType.DIVIDE_EQUALS); break;
            case "==": addToken(TokenType.EQUALS_EQUALS); break;
            case "//": skip(); break;
            case "!": not(symbol); break;
            case "!=": addToken(TokenType.NOT_EQUALS); break;
            case "<": less(symbol); break;
            case ">": greater(symbol); break;
            case "<=": addToken(TokenType.LESS_EQUALS); break;
            case ">=": addToken(TokenType.GREATER_EQUALS); break;
            case "&": umpersant(symbol); break;
            case "&&": addToken(TokenType.AND_AND); break;
            case "|": collector += symbol; break;
            case "||": addToken(TokenType.OR_OR); break;
            case string s when s[0]=='|': throw new Exception(exceptionText(start));
            case "#": addToken(TokenType.HASH); break;
            case ";": addToken(TokenType.SEMICOLON); break;
            case ":": addToken(TokenType.COLON); break;
            case ",": addToken(TokenType.COMMA); break;
            case ".": addToken(TokenType.DOT); break;
            case "(": addToken(TokenType.BRACKET_ROUND_LEFT); break;
            case ")": addToken(TokenType.BRACKET_ROUND_RIGHT); break;
            case "[": addToken(TokenType.BRACKET_SQUERE_LEFT); break;
            case "]": addToken(TokenType.BRACKET_SQUARE_RIGHT); break;
            case "{": addToken(TokenType.BRACKET_CURLY_LEFT); break;
            case "}": addToken(TokenType.BRACKET_CURLY_LEFT); break;
            case "?": addToken(TokenType.QUESTION_MARK); break;
            case string s when isIdentifier(s): identifier(symbol); break;
            default: throw new Exception(exceptionText(start));
        }
    }

    public void addToken(TokenType type) {
        tokens.Add(new Token(type, collector, start)); 
        pos--;
        collector = "";
        Console.WriteLine(tokens[tokens.Count()-1]);
    }

    public string exceptionText(int start) {
        return "Wrong symbol at: " + start + "\n" + (start + 30 < text.Length ? text.Substring(start, 30) : text.Substring(start, text.Length-start));
    }

    public void number(char symbol) {
        switch(symbol) {
            case char c when isDigit(c): collector += c; break;
            default: addToken(TokenType.NUMBER); break;
        }
    }
    public void plus(char symbol) {
        switch(symbol) {
            case char c when "+=".Contains(c): collector += symbol; break;
            default: addToken(TokenType.PLUS); break;
        }
    }
    public void minus(char symbol) {
        switch(symbol) {
            case char c when "-=".Contains(c): collector += symbol; break;
            default: addToken(TokenType.MINUS); break;
        }
    }
        public void multiply(char symbol) {
        switch(symbol) {
            case char c when "=".Contains(c): collector += symbol; break;
            default: addToken(TokenType.MULTIPLY); break;
        }
    }
    public void divide(char symbol) {
        switch(symbol) {
            case char c when "=/".Contains(c): collector += symbol; break;
            default: addToken(TokenType.DIVIDE); break;
        }
    }
    public void equals(char symbol) {
        switch(symbol) {
            case char c when "=".Contains(c): collector += symbol; break;
            default: addToken(TokenType.EQUALS); break;
        }
    }
    public void not(char symbol) {
        switch(symbol) {
            case char c when "=".Contains(c): collector += symbol; break;
            default: addToken(TokenType.NOT); break;
        }
    }
    public void less(char symbol) {
        switch(symbol) {
            case char c when "=".Contains(c): collector += symbol; break;
            default: addToken(TokenType.LESS); break;
        }
    }
    public void greater(char symbol) {
        switch(symbol) {
            case char c when "=".Contains(c): collector += symbol; break;
            default: addToken(TokenType.GREATER); break;
        }
    }
    public void umpersant(char symbol) {
        switch(symbol) {
            case char c when "&".Contains(c): collector += symbol; break;
            default: addToken(TokenType.UMPERSANT); break;
        }
    }
    public void skip() {
        int len = text.Substring(start).IndexOf('\r');
        collector = text.Substring(start, len);
        int tmp = start;
        addToken(TokenType.COMMENT);
        pos = tmp + len;
    }
    // public void floatB(char symbol) {
    //     string t = "float";
    //     switch(symbol) {
    //         case char c when collector.Length == t.Length && (text[pos] == ' ' || isSign(c)): addToken(TokenType.FLOAT); break;
    //         case char c when " \r\n".Contains(c): addToken(TokenType.IDENTIFIER); break;
    //         default: collector += symbol; break;
    //     }
    // }
    // public void intB(char symbol) {
    //     string t = "int";
    //     switch(symbol) {
    //         case char c when collector.Length == t.Length && (text[pos] == ' ' || isSign(c)): addToken(TokenType.INT); break;
    //         case char c when " \r\n".Contains(c): addToken(TokenType.IDENTIFIER); break;
    //         default: collector += symbol; break;
    //     }
    // }
    // public void doubleB(char symbol) {
    //     string t = "double";
    //     switch(symbol) {
    //         case char c when collector.Length == t.Length && (text[pos] == ' ' || isSign(c)): addToken(TokenType.DOUBLE); break;
    //         case char c when " \r\n".Contains(c): addToken(TokenType.IDENTIFIER); break;
    //         default: collector += symbol; break;
    //     }
    // }
    // public void charB(char symbol) {
    //     string t = "char";
    //     switch(symbol) {
    //         case char c when collector.Length == t.Length && (text[pos] == ' ' || isSign(c)): addToken(TokenType.DOUBLE); break;
    //         case char c when " \r\n".Contains(c): addToken(TokenType.CHAR); break;
    //         default: collector += symbol; break;
    //     }
    // }
    public void identifier(char symbol) {
        switch(symbol) {
            case char c when isSign(c) || " \r\n".Contains(c): addToken(TokenType.IDENTIFIER); break;
            default: collector += symbol; break;
        }
    }
    public void charText(char symbol) {
        if(collector.Length <= 2 || (collector.Length==3 && collector[1]=='\\')) {
            collector += symbol;
        }
        else if((collector.Length==3 && collector[2]=='\'') || (collector.Length==4 && collector[3]=='\'')) {
            addToken(TokenType.CHARACTER);
        }
        else throw new Exception(exceptionText(start));
    }
    public void isOrOr(char symbol) {
        switch(symbol) {
            case '|': addToken(TokenType.OR_OR); break;
            default: throw new Exception(exceptionText(start));
        }
    }




    public bool isSthPart(string text) {
        foreach(string s in keys.Keys) {
            if(text.Length <= s.Length && text == s.Remove(text.Length)) {
                return true;
            }
        }
        return false;
    }
    public void sthB(char symbol) {
        string t = "";
        foreach(string s in keys.Keys) {
            if(collector.Length <= s.Length && collector == s.Remove(collector.Length)) {
                t = s;
                break;
            }
        }
        switch(symbol) {
            case char c when collector.Length == t.Length && (text[pos] == ' ' || isSign(c)): addToken(keys[t]); break;
            case char c when " \r\n".Contains(c): addToken(TokenType.IDENTIFIER); break;
            default: collector += symbol; break;
        }
    }





    // public bool isFloatPart(string text) {
    //     string t = "float";
    //     return collector.Length <= t.Length && text == t.Remove(collector.Length);
    // }
    // public bool isIntPart(string text) {
    //     string t = "int";
    //     return collector.Length <= t.Length && text == t.Remove(collector.Length);
    // }
    // public bool isDoublePart(string text) {
    //     string t = "double";
    //     return collector.Length <= t.Length && text == t.Remove(collector.Length);
    // }
    // public bool isCharPart(string text) {
    //     string t = "char";
    //     return collector.Length <= t.Length && text == t.Remove(collector.Length);
    // }
    public bool isNumber(string text) {
        char symbol = text[0];
        return symbol >= 48 && symbol <= 57;
    }
    public bool isText(string text) {
        return text[0] == '\"';
    }
    public bool isIdentifier(string text) {
        return isLetter(text[0]);
    }
    public bool isWholeText(string text) {
        int l = text.Length;
        char s = text[0];
        char e = text[l-1];
        return s == '\"' && l != 1 && text[l-2] != '\\' && e == '\"';
    }
    public bool isLetter(char symbol) {
        return (symbol >= 65 && symbol <= 90) || (symbol >= 97 && symbol <= 122) || symbol=='_';
    }
    public bool isDigit(char symbol) {
        return symbol >= 48 && symbol <= 57;
    }
    public bool isSign(char symbol) {
        return "+_*/%=!<>&|.,:;#()[]{}".Contains(symbol);
    }
    public bool isCharText(string text) {
        return text[0] == '\'';
    }
    Dictionary<string, TokenType> keys = new(){
        {"int", TokenType.INT},
        {"float", TokenType.FLOAT}, 
        {"double", TokenType.DOUBLE}, 
        {"char", TokenType.CHAR}, 
        {"long", TokenType.LONG}, 
        {"short", TokenType.SHORT}, 
        {"struct", TokenType.STRUCT}, 
        {"void", TokenType.VOID}, 
        {"string", TokenType.STRING},
        {"const", TokenType.CONST}, 
        {"static", TokenType.STATIC}, 
        {"volatile", TokenType.VOLATILE}, 
        {"public", TokenType.PUBLIC}, 
        {"private", TokenType.PRIVATE}, 
        {"for", TokenType.FOR}, 
        {"while", TokenType.WHILE}, 
        {"do", TokenType.DO}, 
        {"if", TokenType.IF}, 
        {"else", TokenType.ELSE}, 
        {"switch", TokenType.SWITCH}, 
        {"case", TokenType.CASE}, 
        {"default", TokenType.DEFAULT}, 
        {"break", TokenType.BREAK}, 
        {"continue", TokenType.CONTINUE}, 
        {"return", TokenType.RETURN},
        {"new", TokenType.NEW},
        {"when", TokenType.WHEN}
    };
}