namespace StarPattern14outof22
{
    class Program
    {
        /*
         * A
         * AB
         * ABC
         * ABCD
         * ABCDE
         */
        static void Main(string[] args)
        {
            for (int i = 0;i<5;i++)
            {
                char c = 'A';
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(c);
                    c++;
                }
                Console.WriteLine();
            }    
        }
    }
}