namespace StarPattern12outof22
{
    class Program
    {
        /*
         * 1      1
         * 12    21
         * 123  321
         * 12344321 
         */
        static void Main(string[] args)
        {
            int row = 6;
            for (int i = 1; i < row; i++)
            {

                for(int j = 1; j <= i; j++)
                {
                    Console.Write(i);
                }
                for(int j = 1; j < ((row * 2) - 1) - (i * 2); j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
        }
    }
}