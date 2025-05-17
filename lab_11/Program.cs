class Program
{
    static void Main()
    {
        string file1 = "price1.txt";
        string file2 = "price2.txt";
        if (!File.Exists("price1.txt")) File.Create("price1.txt");
        if (!File.Exists("price2.txt")) File.Create("price2.txt");

        Dictionary<string, int> finalPriceList = new Dictionary<string, int>();
        
        void ProcessFile(string filePath)
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && int.TryParse(parts[1], out int price))
                {
                    string product = parts[0];

       
                    if (finalPriceList.ContainsKey(product))
                    {
                        finalPriceList[product] = Math.Max(finalPriceList[product], price);
                    }
                    else
                    {
                        finalPriceList[product] = price;
                    }
                }
            }
        }

        ProcessFile(file1);
        ProcessFile(file2);
     
        foreach (var item in finalPriceList)
        {
            Console.WriteLine($"{item.Key} {item.Value}");
        }
    }
}
