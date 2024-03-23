public class Token {
    public TokenType type;
    public string? value;
    public int location;

    public Token(TokenType type, string? value, int location) {
        this.type = type;
        this.value = value;
        this.location = location;
    }
    public Token(TokenType type, int location) {
        this.type = type;
        this.location = location;
        value = null;
    }

    public override string ToString()
    {
        return location + ". " + type + ": `" + value + "`";
    }
}