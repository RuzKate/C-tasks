using System;

class Book
{
    //поля
    private string bookName;
    private string authorName;
    private int priceBook;

    //конструктор           
    public Book(string bookName, string authorName, int priceBook)
    {
        BookName = bookName;
        AuthorName = authorName;
        PriceBook = priceBook;
    }

    //свойства
    public string BookName
    {
        get { return bookName; }
        set { bookName = value; }
    }
    public string AuthorName
    {
        get { return authorName; }
        set { authorName = value; }
    }
    public int PriceBook
    {
        get { return priceBook; }
        set { priceBook = value; }
    }
    public virtual void Print()
    {
        Console.WriteLine($"Книга: {BookName}");
        Console.WriteLine($"Автор: {AuthorName}");
        Console.WriteLine($"Стоимость: {PriceBook}");
    }
}

class BookGenre : Book
{
    //поле
    private string genre;

    //свойство
    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }
    //конструктор
    public BookGenre(string bookName, string authorName, int priceBook, string genre) : base(bookName, authorName, priceBook)
    {
        Genre = genre;
    }
    //переопределенный Print
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Жанр: {Genre}");
    }
}

sealed class BookGenrePubl : BookGenre
{
    //поле
    private string publ;

    //свойство
    public string Publ
    {
        get { return publ; }
        set { publ = value; }
    }
    //конструктор
    public BookGenrePubl(string bookName, string authorName, int priceBook, string genre, string publ) : base(bookName, authorName, priceBook, genre)
    {
        Publ = publ;
    }
    //переопределенный Print
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Информация об издателе: {Publ}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book("Преступление и наказание", "Фёдор Достоевский", 1000);
        book1.Print();

        Console.WriteLine($"\n");

        BookGenrePubl book2 = new BookGenrePubl("Преступление и наказание", "Фёдор Достоевский", 1000, "Роман", "Русский писатель, мыслитель, философ и публицист");
        book2.Print();
    }
}