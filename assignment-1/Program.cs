namespace assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckEven(9901, 2));
        }

        static bool CheckEven(int number, int divider)
        {
            if (number % divider == 0) return true;
            else if (number % divider != 0 && divider >= 2 && divider <= Math.Sqrt(number)) { 
                return CheckEven(number, divider+1); 
            }
            else return false;
        }
    }
}