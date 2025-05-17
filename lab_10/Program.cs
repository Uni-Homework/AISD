using System.Text.RegularExpressions;

namespace lab_10;

public class Program
{
    public static void Main()
    {
        for (;;)
        {
            Console.WriteLine("What program to run?\n5 or 26?\n");
            int decision = Convert.ToInt32(Console.ReadLine());

            if (decision == 5) Task5();
            if (decision == 26) Task26();
        }
    }
    
   public static void Task5() 
   {
        string inputFile = "input.txt";   
        string outputFile = "output.txt";  

        string text = File.ReadAllText(inputFile);

        Regex wordRegex = new Regex(@"\b[^\s\p{P}]+\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        var matches = wordRegex.Matches(text);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (Match match in matches)
            {
                string word = match.Value;
                if (Regex.IsMatch(word, "[сС]"))
                {
                    writer.WriteLine(word);
                }
            }
        }
    }
    static void Task26()
    {
        string inputFile = "input.txt";
        string text = File.ReadAllText(inputFile);

        Regex exprRegex = new Regex(@"(-?\d+)\s*([+\-*/])\s*(-?\d+)", RegexOptions.Compiled);

        MatchCollection matches = exprRegex.Matches(text);

        foreach (Match match in matches)
        {
            string operand1 = match.Groups[1].Value;
            string op = match.Groups[2].Value;
            string operand2 = match.Groups[3].Value;

            Console.WriteLine($"{operand1}:{operand2}:{op}");
        }
        Console.WriteLine();
    }
}