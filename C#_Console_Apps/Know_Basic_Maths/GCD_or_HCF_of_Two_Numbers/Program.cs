namespace GCD_or_HCF_of_Two_Numbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter First Number : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter Second Number : ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            while (num1 > 0 && num2 > 0)
            {
                if (num1 > num2) num1 = num1 % num2;
                else num2 = num2 % num1;
            }

            if(num1 == 0)
            {
                Console.WriteLine("GCD or HCF of Two Numbers is : "+ num2);
            }
            else
            {
                Console.WriteLine("GCD or HCF of Two Numbers is : "+ num1);
            }
        }
    }
}