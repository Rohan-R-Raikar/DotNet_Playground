namespace StarPattern16outof22
{
    class Program
    {
        /*
         * A
         * BB
         * CCC
         * DDDD
         * EEEEE
         */
        static void Main(string[] args)
        {
            char c = 'A';
            for(int i=0; i<5;i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(c);
                }
                c++;
                Console.WriteLine();
            }
        }
    }
}