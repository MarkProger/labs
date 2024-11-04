using System;
using System.Collections.Generic;
using System.Linq;

IBookCollection bookProxy = new BookCollectionProxy();

bookProxy.AddBook(new Book("1984", "George Orwell"));
bookProxy.AddBook(new Book("Brave New World", "Aldous Huxley"));

bookProxy.SearchByAuthor("George Orwell");

bookProxy.RemoveBook("1984");

bookProxy.SearchByAuthor("George Orwell");

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public Book(string title, string author)
    {
        this.Title = title;
        this.Author = author;
    }
    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}";
    }
}

interface IBookCollection
{
    void AddBook( Book book );
    void RemoveBook(string title);
    Book SearchByAuthor(string author);
}

public class BookCollection : IBookCollection
{
    private List<Book> books = new List<Book>();
    public void AddBook(Book book)
    {
        books.Add( book );
        Console.WriteLine($"Book {book.Title} added");
    }

    public void RemoveBook(string title)
    {
        var book = books.FirstOrDefault(b => b.Title == title);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Book '{title}' removed.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' not found.");
        }
    }

    public Book SearchByAuthor(string author)
    {
        return books.FirstOrDefault(b => b.Author == author);
    }
}

public class BookCollectionProxy : IBookCollection
{
    private BookCollection bookCollection;

    public BookCollectionProxy()
    {
        bookCollection = new BookCollection();
    }

    public void AddBook(Book book)
    {
        Console.WriteLine("Proxy: Forwarding add request to the real collection.");
        bookCollection.AddBook(book);
    }

    public void RemoveBook(string title)
    {
        Console.WriteLine("Proxy: Forwarding remove request to the real collection.");
        bookCollection.RemoveBook(title);
    }

    public Book SearchByAuthor(string author)
    {
        Console.WriteLine("Proxy: Searching for a book by author...");
        var book = bookCollection.SearchByAuthor(author);
        if (book != null)
        {
            Console.WriteLine($"Book found: {book}");
        }
        else
        {
            Console.WriteLine("No book found by that author.");
        }
        return book;
    }
}