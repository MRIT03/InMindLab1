using InMindLab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace InMindLab1.Services;

public interface ILibraryService
{
    public List<Book> booksInYear([FromQuery] int year, [FromQuery] string order_by);
    public List<Author> authorsInYear([FromQuery] int year);
    public List<Author> authorsInYearAndCountry([FromQuery] int year, [FromQuery] string country);
    public int totalBooks();
    public List<Book> getBooks([FromQuery] int page, [FromQuery] int page_size);

}