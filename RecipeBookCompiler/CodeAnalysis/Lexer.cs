namespace RecipeBookCompiler.CodeAnalysis
{
    public class Lexer
    {
        private readonly string _text;
        private int _position;

        public Lexer(string text)
        {
            _text = text;
            _position = 0;
        }

        private char GetCurrent()
        {
            if (_position >= _text.Length)
                return '\0';
            return _text[_position];
        } 

        public SyntaxToken Lex()
        {
            if (_position >= _text.Length)
                return LexEndOfFileToken();

            if (char.IsWhiteSpace(GetCurrent()))
            {
                return LexWhiteSpaceToken();
            }

            if (char.IsDigit(GetCurrent()))
            {
                return LexLiteralToken();
            }

            switch (GetCurrent())
            {
                case '+':
                    return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
                case '-':
                    return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
                case '*':
                    return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);
                case '/':
                    return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);
                case '(':
                    return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);
                case ')':
                    return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null);
                case ',':
                    return new SyntaxToken(SyntaxKind.CommaToken, _position++, ",", null);
                case '.':
                    return new SyntaxToken(SyntaxKind.PeriodToken, _position++, ".", null);
                case ':':
                    return new SyntaxToken(SyntaxKind.ColonToken, _position++, ":", null);
                default:
                    break;
            }
            return new SyntaxToken(SyntaxKind.BadToken, _position, "", null);
        }

        private SyntaxToken LexLiteralToken()
        {
            int start = _position;
            int length;
            while (true)
            {
                if (!char.IsDigit(GetCurrent()))
                {
                    length = _position - start;
                    break;
                }
                _position++;
            }
            string text = _text.Substring(start, length);
            int value = int.Parse(text);
            return new SyntaxToken(SyntaxKind.LiteralToken, start, text, value);
        }

        private SyntaxToken LexWhiteSpaceToken()
        {
            int start = _position;
            while (true)
            {
                if (!char.IsWhiteSpace(GetCurrent()))
                    break;
                _position++;
            }
            return new SyntaxToken(SyntaxKind.WhiteSpaceToken, _position, " ", null);
        }

        private SyntaxToken LexEndOfFileToken()
        {
            return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);
        }
    }
}
