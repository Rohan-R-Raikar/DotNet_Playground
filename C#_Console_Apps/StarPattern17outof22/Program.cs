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

        static void Main(string[] args)
        {
            int row = 4;
            for (int i = 0; i < row; i++)
            {
                char c = 'A';
                for (int j=0; j < row-i-1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write(c);
                    c++;
                }
                
                c--;
                
                for (int j = 0; j < i; j++)
                {
                    c--;
                    Console.Write(c);
                }
                Console.WriteLine();
            }

        }   
    }
}