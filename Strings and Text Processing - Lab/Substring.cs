string wordToRemove = Console.ReadLine();
string text = Console.ReadLine();




while (text.IndexOf(wordToRemove) != -1)
{
    
    int positionWord = text.IndexOf(wordToRemove);
    text = text.Remove(positionWord, wordToRemove.Length);
}

Console.WriteLine(text);