public enum TokenType {
    NUMBER,         //1234567890
    TEXT,           //""
    CHARACTER,      //''
    IDENTIFIER,     //

    PLUS,           //+
    MINUS,          //-
    MULTIPLY,       //*
    DIVIDE,         //\/
    REST,           //%
    EQUALS,         //=
    
    PLUS_PLUS,      //++
    MINUS_MINUS,    //--

    PLUS_EQUALS,    //+=
    MINUS_EQUALS,   //-=
    MULTIPLY_EQUALS,//*=
    DIVIDE_EQUALS,  //\/=

    EQUALS_EQUALS,  //==
    NOT_EQUALS,     //!=
    LESS,           //<
    GREATER,        //>
    LESS_EQUALS,    //<=
    GREATER_EQUALS, //>=
    COMMENT ,        //\//

    AND_AND,        //&&
    OR_OR,          //||
    NOT,            //!

    INT,            //int
    FLOAT,          //float
    DOUBLE,         //
    CHAR,           //
    LONG,
    SHORT,
    STRUCT,
    VOID, 
    STRING,

    CONST,
    STATIC,
    VOLATILE,
    PUBLIC,
    PRIVATE,

    FOR,
    WHILE,
    DO,

    IF,
    ELSE,
    IF_ELSE, //-----------------------------------------------------

    SWITCH,
    CASE,
    DEFAULT,

    BREAK,
    CONTINUE,
    RETURN,

    DOT,            //.
    COMMA,          //,
    COLON,          //:
    SEMICOLON,      //;
    UMPERSANT,      //&
    HASH,           //#
    QUESTION_MARK,

    BRACKET_ROUND_LEFT,     //(
    BRACKET_ROUND_RIGHT,    //)
    BRACKET_SQUERE_LEFT,    //[
    BRACKET_SQUARE_RIGHT,   //]
    BRACKET_CURLY_LEFT,     //{
    BRACKET_CURLY_RIGHT,    //}

    WHEN,
    NEW,
}