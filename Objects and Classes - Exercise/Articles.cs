using System;


public class Article
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Author { get; private set; }

    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public void Edit(string newContent)
    {
        Content = newContent;
    }

    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }

    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        
        string[] articleData = Console.ReadLine().Split(", ");
        string title = articleData[0];
        string content = articleData[1];
        string author = articleData[2];

        
        Article article = new Article(title, content, author);

       
        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] commandData = Console.ReadLine().Split(": ");
            string command = commandData[0];
            string argument = commandData[1];

            
            if (command == "Edit")
            {
                article.Edit(argument);
            }
            else if (command == "ChangeAuthor")
            {
                article.ChangeAuthor(argument);
            }
            else if (command == "Rename")
            {
                article.Rename(argument);
            }
        }

        
        Console.WriteLine(article);
    }
}
