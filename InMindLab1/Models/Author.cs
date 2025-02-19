using System;
using System.Collections.Generic;

namespace InMindLab1.Models;

public partial class Author
{
    public Author(int authorId, string name, int? birthDate, string? country)
    {
        AuthorId = authorId;
        Name = name;
        BirthDate = birthDate;
        Country = country;
    }

    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public int? BirthDate { get; set; }

    public string? Country { get; set; }

    public Author()
    {
        
    }
    
    

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
