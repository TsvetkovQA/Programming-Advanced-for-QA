using System;
using System.Text;

class Program
{
    static void Main()
    {
        
        string input = Console.ReadLine();

        
        StringBuilder digits = new StringBuilder();
        StringBuilder letters = new StringBuilder();
        StringBuilder others = new StringBuilder();

       
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                digits.Append(c);
            }
            else if (char.IsLetter(c))
            {
                letters.Append(c);
            }
            else
            {
                others.Append(c);
            }
        }

       
        Console.WriteLine(digits.ToString());
        Console.WriteLine(letters.ToString());
        Console.WriteLine(others.ToString());
    }
}
