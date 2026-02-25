namespace StarPattern11outof22
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;

            for (int i = 0; i<7; i++)
            {
                if (i % 2 == 0) start = 1;
                else start = 0;

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(start);
                    start = 1 - start;
                }
                Console.WriteLine();
            }
        }
    }
}