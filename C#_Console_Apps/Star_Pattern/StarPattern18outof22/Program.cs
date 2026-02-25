namespace StarPattern18outof22
{
    class Program
    {
        /*
         * E
         * DE
         * CDE
         * BCDE
         * ABCDE
         */
        static void Main(string[] args)
        {
            int row = 5;
            char lastChar = (char)('A' + row - 1);

            for (int i = 0; i < row; i++)
            {
                char start = (char)(lastChar - i);

                for (char c = start; c <= lastChar; c++)
                {
                    Console.Write(c);
                }

                Console.WriteLine();
            }
        }
    }
}