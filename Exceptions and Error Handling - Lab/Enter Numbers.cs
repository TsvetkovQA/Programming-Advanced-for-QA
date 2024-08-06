int end = 100; 
int start = 1;
List<int> numbers = new List<int>(); 
while (numbers.Count < 10)
{
    try
    {
        int number = ReadNumber(start, end);
        numbers.Add(number);
        start = number; 
    }
    catch (FormatException fe)
    {
        Console.WriteLine(fe.Message);
    }
    catch (ArgumentException argEx)
    {
        Console.WriteLine(argEx.Message);
    }
}


Console.WriteLine(String.Join(", ", numbers));






static int ReadNumber(int start, int end)
{
    
    string input = Console.ReadLine();

    
    try
    {
        int number = int.Parse(input);
       
        if (number <= start || number >= end)
        {
            throw new ArgumentException($"Your number is not in range {start} - {end}!"); 
        }
        
        return number;
    }
    catch(FormatException)
    {
        throw new FormatException("Invalid Number!");
    }

}