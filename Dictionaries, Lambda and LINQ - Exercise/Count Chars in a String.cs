string text = Console.ReadLine();


Dictionary<char, int> charsCount = new Dictionary<char, int>();



foreach (char symbol in text)
{
    if (symbol == ' ')
    {
        continue; 
    }

    
    if (!charsCount.ContainsKey(symbol))
    {
       
        charsCount.Add(symbol, 1);
    }
    else
    {
        
        charsCount[symbol]++;
    }

}



foreach(KeyValuePair<char, int> entry in charsCount)
{
    
    Console.WriteLine(entry.Key + " -> " + entry.Value);
}

