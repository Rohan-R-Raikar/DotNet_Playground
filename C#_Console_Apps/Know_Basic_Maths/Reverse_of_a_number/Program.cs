namespace Reverse_of_a_number
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number you want to reverse");

            int num = Convert.ToInt32(Console.ReadLine());

            // Variables to store last digit and reversed number
            int ld = 0;
            int revNum = 0;
            while (num > 0)
            {
                // Get the last digit of the number
                ld = num % 10;

                // Append the last digit to the reversed number
                revNum = (revNum * 10) + ld;

                // Remove the last digit from the original number
                num = num / 10;
            }

            Console.WriteLine("Your Reversed Number is : " + revNum);

            Console.ReadKey();
        }
    }
}