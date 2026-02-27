namespace Palindrome_Number
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a Number : ");
            int num =  Convert.ToInt32(Console.ReadLine());

            int OrginalNum = num;
            int reverseNumber = 0;

            while (num > 0)
            {
                reverseNumber = (reverseNumber * 10) + (num % 10);
                num = num / 10;
            }

            if (reverseNumber == OrginalNum) Console.WriteLine("Number is Palindrome Number");
            else Console.WriteLine("Number is not Regular Number"); 
        }
    }
}