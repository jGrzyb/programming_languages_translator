using System.ComponentModel.Design;

public class TokenColor {

    static string sign = "sign";
    static string kWord = "keyWord";
    static string bracket = "bracket";
    static string number = "number";
    static string text = "text";
    static string identifier = "identifier";
    static string comment = "comment";
    static Dictionary<TokenType, string> dict;
    
    
    public static string GetColor(TokenType type) {
        return dict[type];
    }




    static TokenColor() {
        dict = new Dictionary<TokenType, string>() {
            {TokenType.NUMBER, number},
            {TokenType.TEXT, text},
            {TokenType.IDENTIFIER, identifier},
            {TokenType.CHARACTER,text},

            {TokenType.PLUS, sign},
            {TokenType.MINUS, sign},
            {TokenType.MULTIPLY,sign},
            {TokenType.DIVIDE,sign},
            {TokenType.REST,sign},
            {TokenType.EQUALS,sign},
            
            {TokenType.PLUS_PLUS,sign},
            {TokenType.MINUS_MINUS,sign},

            {TokenType.PLUS_EQUALS,sign},
            {TokenType.MINUS_EQUALS,sign},
            {TokenType.MULTIPLY_EQUALS,sign},
            {TokenType.DIVIDE_EQUALS,sign},

            {TokenType.EQUALS_EQUALS,sign},
            {TokenType.NOT_EQUALS,sign},
            {TokenType.LESS,sign},
            {TokenType.GREATER,sign},
            {TokenType.LESS_EQUALS,sign},
            {TokenType.GREATER_EQUALS, sign},
            {TokenType.COMMENT, comment},

            {TokenType.AND_AND,sign},
            {TokenType.OR_OR,sign},
            {TokenType.NOT,sign},

            {TokenType.INT,kWord},
            {TokenType.FLOAT,kWord},
            {TokenType.DOUBLE,kWord},
            {TokenType.CHAR,kWord},
            {TokenType.LONG,kWord},
            {TokenType.SHORT,kWord},
            {TokenType.STRUCT,kWord},
            {TokenType.VOID,kWord},
            {TokenType.STRING, kWord},

            {TokenType.CONST,kWord},
            {TokenType.STATIC,kWord},
            {TokenType.VOLATILE,kWord},
            {TokenType.PUBLIC,kWord},
            {TokenType.PRIVATE,kWord},

            {TokenType.FOR,kWord},
            {TokenType.WHILE,kWord},
            {TokenType.DO,kWord},

            {TokenType.IF,kWord},
            {TokenType.ELSE,kWord},
            {TokenType.IF_ELSE,kWord},

            {TokenType.SWITCH,kWord},
            {TokenType.CASE,kWord},
            {TokenType.DEFAULT,kWord},

            {TokenType.BREAK,kWord},
            {TokenType.CONTINUE,kWord},
            {TokenType.RETURN,kWord},

            {TokenType.DOT,sign},
            {TokenType.COMMA,sign},
            {TokenType.COLON,sign},
            {TokenType.SEMICOLON,sign},
            {TokenType.UMPERSANT,sign},
            {TokenType.HASH,sign},
            {TokenType.QUESTION_MARK,sign},

            {TokenType.BRACKET_ROUND_LEFT,bracket},
            {TokenType.BRACKET_ROUND_RIGHT,bracket},
            {TokenType.BRACKET_SQUERE_LEFT,bracket},
            {TokenType.BRACKET_SQUARE_RIGHT,bracket},
            {TokenType.BRACKET_CURLY_LEFT,bracket},
            {TokenType.BRACKET_CURLY_RIGHT,bracket},

            {TokenType.WHEN,kWord},
            {TokenType.NEW,kWord}
        };
    }
}