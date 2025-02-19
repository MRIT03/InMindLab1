using System;
using System.Collections.Generic;

namespace InMindLab1.Models;

public partial class Book
{
    public Book(int bookId, string title, int authorId, string? isbn, int publishedYear)
    {
        BookId = bookId;
        Title = title;
        AuthorId = authorId;
        Isbn = isbn;
        PublishedYear = publishedYear;
    }

    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public string? Isbn { get; set; }

    public int PublishedYear { get; set; }

    public virtual Author Author { get; set; } = null!;

    public Book()
    {
        
    }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
