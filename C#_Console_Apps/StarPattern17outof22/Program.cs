namespace StarPattern17outof22
{
    class Program
    {
        /*
         *    A
         *   ABA
         *  ABCBA
         * ABCDCBA
         */

        /*
         * 1-1-6
         * 2-3-4
         * 3-5-2
         * 4-7-0
         */
        static void Main(string[] args)
        {
            int row = 4;
            for (int i = 0; i < row; i++)
            {
                char c = 'A';
                for (int j=0; j < row-i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(c);
                    c++;
                }
                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0) { Console.Write(" "); }
                    c--;
                    Console.Write(c);
                }
                Console.WriteLine();
            }

        }   
    }
}