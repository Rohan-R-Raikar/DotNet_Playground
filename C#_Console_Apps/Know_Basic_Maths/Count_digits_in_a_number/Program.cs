using System;

namespace Count_digits_in_a_number
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a Number: ");

            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Your Entered Number is: " + num);

            int counter = (num == 0) ? 1 : (int)Math.Floor(Math.Log10(Math.Abs(num))) + 1;

            // If number is negative, make it positive
            num = Math.Abs(num);

            // Special case: if number is 0, it has 1 digit
            if (num == 0)
            {
                Console.WriteLine("Digit Count: 1");
                return;
            }

            int count = 0;

            // Keep dividing the number by 10 until it becomes 0
            while (num > 0)
            {
                num = num / 10;
                count++;
            }

            // Display total digit count
            Console.WriteLine("Digit Count: " + count);
            Console.WriteLine("Digit Counter: " + counter);
        }
    }
}