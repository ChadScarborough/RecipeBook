using RecipeBookCompiler.CodeAnalysis;

namespace RecipeBookCompiler
{
    public static class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("> ");
                string? line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    break;
                Lexer lexer = new Lexer(line);

                while (true)
                {
                    SyntaxToken token = lexer.Lex();
                    if (token.Kind == SyntaxKind.EndOfFileToken || token.Kind == SyntaxKind.BadToken)
                        break;
                    Console.WriteLine($"{token.Kind} - {token.Text} : {token.Value}");
                }
            }
        }
    }
}
