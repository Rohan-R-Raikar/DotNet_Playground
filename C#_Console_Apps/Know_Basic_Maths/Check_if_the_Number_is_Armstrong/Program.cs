using System;

namespace Check_if_the_Number_is_Armstrong
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            int digits = num.ToString().Length;

            int temp = num;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, digits);
                temp /= 10;
            }

            if (sum == num)
                Console.WriteLine($"{num} is an Armstrong number.");
            else
                Console.WriteLine($"{num} is NOT an Armstrong number.");
        }
    }
}