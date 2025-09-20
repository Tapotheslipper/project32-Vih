public abstract class LibraryItems
{
    public string Title { get; set; }

    public abstract void FindItem();
}

public interface ISearchable
{
    public void Search(string title);
}

public class Book : LibraryItems, ISearchable
{
    public string Author { get; set; }

    public override void FindItem()
    {
        Console.WriteLine($"A book titled {Title}, written by {Author}");
    }
    public void Search(string title)
    {
        Console.WriteLine($"Found a book, it is: {Title}");
    }
}

public class Magazine : LibraryItems, ISearchable
{
    public int IssueNum { get; set; }

    public override void FindItem()
    {
        Console.WriteLine($"A magazine titled {Title}, issue no. {IssueNum}.");
    }
    public void Search(string title)
    {
        Console.WriteLine($"Found a magazine, it is: {Title}");
    }
}

public class DVD : LibraryItems, ISearchable
{
    public string Author { get; set; }

    public override void FindItem()
    {
        Console.WriteLine($"A DVD titled {Title}, filmed by {Author}");
    }
    public void Search(string title)
    {
        Console.WriteLine($"Found a DVD, it is: {Title}");
    }
}