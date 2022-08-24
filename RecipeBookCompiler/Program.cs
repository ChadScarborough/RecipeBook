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

                if (line.ToUpper() == "PRINT TWO PLUS TWO.")
                    Console.WriteLine("FOUR");
            }
        }
    }
}
