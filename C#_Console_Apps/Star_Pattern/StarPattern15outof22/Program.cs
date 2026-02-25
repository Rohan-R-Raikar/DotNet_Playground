namespace StarPattern15outof22
{
    class Program
    {
        /*
         * ABCDE
         * ABCD
         * ABC
         * AB
         * A
         */
        static void Main(string[] args)
        {
            int row = 5;
            for (int i = 0; i < row; i++)
            {
                char c = 'A';
                for (int j = 0; j < row-i; j++)
                {
                    Console.Write(c);
                    c++;
                }
                Console.WriteLine();
            }
        }
    }
}