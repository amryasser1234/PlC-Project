
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_EXCLAM               =  4, // '!'
        SYMBOL_EXCLAMEQ             =  5, // '!='
        SYMBOL_PERCENT              =  6, // '%'
        SYMBOL_LPAREN               =  7, // '('
        SYMBOL_RPAREN               =  8, // ')'
        SYMBOL_TIMES                =  9, // '*'
        SYMBOL_COMMA                = 10, // ','
        SYMBOL_DIV                  = 11, // '/'
        SYMBOL_SEMI                 = 12, // ';'
        SYMBOL_PLUS                 = 13, // '+'
        SYMBOL_LT                   = 14, // '<'
        SYMBOL_LTEQ                 = 15, // '<='
        SYMBOL_EQ                   = 16, // '='
        SYMBOL_EQEQ                 = 17, // '=='
        SYMBOL_GT                   = 18, // '>'
        SYMBOL_GTEQ                 = 19, // '>='
        SYMBOL_DIGIT                = 20, // Digit
        SYMBOL_ELSE                 = 21, // else
        SYMBOL_FALSE                = 22, // false
        SYMBOL_FOR                  = 23, // for
        SYMBOL_ID                   = 24, // Id
        SYMBOL_IF                   = 25, // if
        SYMBOL_TRUE                 = 26, // true
        SYMBOL_VAR                  = 27, // var
        SYMBOL_WHILE                = 28, // while
        SYMBOL_BINARY_EXPRESSION    = 29, // <binary_expression>
        SYMBOL_BINARY_OPERATOR      = 30, // <binary_operator>
        SYMBOL_BOOLEAN_LITERAL      = 31, // <boolean_literal>
        SYMBOL_EXPRESSION           = 32, // <expression>
        SYMBOL_EXPRESSION_LIST      = 33, // <expression_list>
        SYMBOL_FOR_INITIALIZER      = 34, // <for_initializer>
        SYMBOL_FOR_LOOP             = 35, // <for_loop>
        SYMBOL_FUNCTION_CALL        = 36, // <function_call>
        SYMBOL_IDENTIFIER           = 37, // <identifier>
        SYMBOL_IF_STATEMENT         = 38, // <if_statement>
        SYMBOL_LITERAL              = 39, // <literal>
        SYMBOL_NUMBER_LITERAL       = 40, // <number_literal>
        SYMBOL_PROGRAM              = 41, // <program>
        SYMBOL_STATEMENT            = 42, // <statement>
        SYMBOL_STATEMENT_LIST       = 43, // <statement_list>
        SYMBOL_UNARY_EXPRESSION     = 44, // <unary_expression>
        SYMBOL_UNARY_OPERATOR       = 45, // <unary_operator>
        SYMBOL_VARIABLE_DECLARATION = 46, // <variable_declaration>
        SYMBOL_WHILE_LOOP           = 47  // <while_loop>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                              =  0, // <program> ::= <statement_list>
        RULE_STATEMENT_LIST                       =  1, // <statement_list> ::= <statement>
        RULE_STATEMENT_LIST2                      =  2, // <statement_list> ::= <statement> <statement_list>
        RULE_STATEMENT                            =  3, // <statement> ::= <variable_declaration>
        RULE_STATEMENT2                           =  4, // <statement> ::= <if_statement>
        RULE_STATEMENT3                           =  5, // <statement> ::= <while_loop>
        RULE_STATEMENT4                           =  6, // <statement> ::= <for_loop>
        RULE_STATEMENT_SEMI                       =  7, // <statement> ::= <expression> ';'
        RULE_VARIABLE_DECLARATION_VAR_EQ_SEMI     =  8, // <variable_declaration> ::= var <identifier> '=' <expression> ';'
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_ELSE   =  9, // <if_statement> ::= if '(' <expression> ')' <statement> else <statement>
        RULE_WHILE_LOOP_WHILE_LPAREN_RPAREN       = 10, // <while_loop> ::= while '(' <expression> ')' <statement>
        RULE_FOR_LOOP_FOR_LPAREN_SEMI_SEMI_RPAREN = 11, // <for_loop> ::= for '(' <for_initializer> ';' <expression> ';' <expression> ')' <statement>
        RULE_FOR_INITIALIZER                      = 12, // <for_initializer> ::= <variable_declaration>
        RULE_FOR_INITIALIZER_SEMI                 = 13, // <for_initializer> ::= <expression> ';'
        RULE_EXPRESSION                           = 14, // <expression> ::= <literal>
        RULE_EXPRESSION2                          = 15, // <expression> ::= <identifier>
        RULE_EXPRESSION3                          = 16, // <expression> ::= <binary_expression>
        RULE_EXPRESSION4                          = 17, // <expression> ::= <unary_expression>
        RULE_EXPRESSION5                          = 18, // <expression> ::= <function_call>
        RULE_LITERAL                              = 19, // <literal> ::= <number_literal>
        RULE_LITERAL2                             = 20, // <literal> ::= <boolean_literal>
        RULE_NUMBER_LITERAL_DIGIT                 = 21, // <number_literal> ::= Digit
        RULE_BOOLEAN_LITERAL_TRUE                 = 22, // <boolean_literal> ::= true
        RULE_BOOLEAN_LITERAL_FALSE                = 23, // <boolean_literal> ::= false
        RULE_BINARY_EXPRESSION                    = 24, // <binary_expression> ::= <expression> <binary_operator> <expression>
        RULE_BINARY_OPERATOR_PLUS                 = 25, // <binary_operator> ::= '+'
        RULE_BINARY_OPERATOR_MINUS                = 26, // <binary_operator> ::= '-'
        RULE_BINARY_OPERATOR_TIMES                = 27, // <binary_operator> ::= '*'
        RULE_BINARY_OPERATOR_DIV                  = 28, // <binary_operator> ::= '/'
        RULE_BINARY_OPERATOR_PERCENT              = 29, // <binary_operator> ::= '%'
        RULE_BINARY_OPERATOR_EQEQ                 = 30, // <binary_operator> ::= '=='
        RULE_BINARY_OPERATOR_EXCLAMEQ             = 31, // <binary_operator> ::= '!='
        RULE_BINARY_OPERATOR_LT                   = 32, // <binary_operator> ::= '<'
        RULE_BINARY_OPERATOR_GT                   = 33, // <binary_operator> ::= '>'
        RULE_BINARY_OPERATOR_LTEQ                 = 34, // <binary_operator> ::= '<='
        RULE_BINARY_OPERATOR_GTEQ                 = 35, // <binary_operator> ::= '>='
        RULE_UNARY_EXPRESSION                     = 36, // <unary_expression> ::= <unary_operator> <expression>
        RULE_UNARY_OPERATOR_MINUS                 = 37, // <unary_operator> ::= '-'
        RULE_UNARY_OPERATOR_EXCLAM                = 38, // <unary_operator> ::= '!'
        RULE_FUNCTION_CALL_LPAREN_RPAREN          = 39, // <function_call> ::= <identifier> '(' <expression_list> ')'
        RULE_EXPRESSION_LIST                      = 40, // <expression_list> ::= <expression>
        RULE_EXPRESSION_LIST_COMMA                = 41, // <expression_list> ::= <expression> ',' <expression_list>
        RULE_IDENTIFIER_ID                        = 42  // <identifier> ::= Id
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;

        public MyParser(string filename, ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BINARY_EXPRESSION :
                //<binary_expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BINARY_OPERATOR :
                //<binary_operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN_LITERAL :
                //<boolean_literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION_LIST :
                //<expression_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_INITIALIZER :
                //<for_initializer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_LOOP :
                //<for_loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CALL :
                //<function_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //<identifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STATEMENT :
                //<if_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER_LITERAL :
                //<number_literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT_LIST :
                //<statement_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARY_EXPRESSION :
                //<unary_expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARY_OPERATOR :
                //<unary_operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE_DECLARATION :
                //<variable_declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_LOOP :
                //<while_loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<program> ::= <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST :
                //<statement_list> ::= <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST2 :
                //<statement_list> ::= <statement> <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <variable_declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <if_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<statement> ::= <while_loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<statement> ::= <for_loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI :
                //<statement> ::= <expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLARATION_VAR_EQ_SEMI :
                //<variable_declaration> ::= var <identifier> '=' <expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_ELSE :
                //<if_statement> ::= if '(' <expression> ')' <statement> else <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_LOOP_WHILE_LPAREN_RPAREN :
                //<while_loop> ::= while '(' <expression> ')' <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_LOOP_FOR_LPAREN_SEMI_SEMI_RPAREN :
                //<for_loop> ::= for '(' <for_initializer> ';' <expression> ';' <expression> ')' <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_INITIALIZER :
                //<for_initializer> ::= <variable_declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_INITIALIZER_SEMI :
                //<for_initializer> ::= <expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<expression> ::= <literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<expression> ::= <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION3 :
                //<expression> ::= <binary_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION4 :
                //<expression> ::= <unary_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION5 :
                //<expression> ::= <function_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL :
                //<literal> ::= <number_literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL2 :
                //<literal> ::= <boolean_literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUMBER_LITERAL_DIGIT :
                //<number_literal> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_LITERAL_TRUE :
                //<boolean_literal> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_LITERAL_FALSE :
                //<boolean_literal> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_EXPRESSION :
                //<binary_expression> ::= <expression> <binary_operator> <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_PLUS :
                //<binary_operator> ::= '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_MINUS :
                //<binary_operator> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_TIMES :
                //<binary_operator> ::= '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_DIV :
                //<binary_operator> ::= '/'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_PERCENT :
                //<binary_operator> ::= '%'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_EQEQ :
                //<binary_operator> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_EXCLAMEQ :
                //<binary_operator> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_LT :
                //<binary_operator> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_GT :
                //<binary_operator> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_LTEQ :
                //<binary_operator> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BINARY_OPERATOR_GTEQ :
                //<binary_operator> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARY_EXPRESSION :
                //<unary_expression> ::= <unary_operator> <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARY_OPERATOR_MINUS :
                //<unary_operator> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARY_OPERATOR_EXCLAM :
                //<unary_operator> ::= '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CALL_LPAREN_RPAREN :
                //<function_call> ::= <identifier> '(' <expression_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LIST :
                //<expression_list> ::= <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LIST_COMMA :
                //<expression_list> ::= <expression> ',' <expression_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIER_ID :
                //<identifier> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Error : '"+args.UnexpectedToken.ToString()+"In Line :" + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string message1 = "Expected Token :" + args.ExpectedTokens.ToString();
            lst.Items.Add(message1);
            //todo: Report message to UI?
        }

    }
}
