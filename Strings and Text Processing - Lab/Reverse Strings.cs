string input = Console.ReadLine();

while (input != "end")
{

    string reversedText = "";
   
    for (int position = input.Length - 1; position >= 0; position--)
    {
        char currentSymbol = input[position];
        reversedText += currentSymbol;
       
    }

   
    Console.WriteLine(input + " = " + reversedText);


    input = Console.ReadLine();
}