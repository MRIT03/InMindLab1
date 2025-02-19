using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using InMindLab1.Data;
using InMindLab1.Models;
using System.Linq;

namespace ODataLibraryDemo.Controllers
{
    public class LibraryODataController : ODataController
    {
        private readonly LibrarydbContext _context;

        public LibraryODataController(LibrarydbContext context)
        {
            _context = context;
        }

        // 1. List groups of authors born in the same year.
        //    Example OData query: GET http://localhost:5142/odata/AuthorsGroupByYear?$apply=groupby((BirthDate), aggregate($count as count))
        [HttpGet("odata/AuthorsGroupByYear")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Count | AllowedQueryOptions.Apply | AllowedQueryOptions.Top | AllowedQueryOptions.Expand) ]
        public IActionResult AuthorsGroupByYear()
        {
            return Ok(_context.Authors);
        }

        // 2. List groups of authors born in the same year and in the same country.
        //    Example OData query: GET http://localhost:5142/odata/AuthorsGroupByYear?$apply=groupby((BirthDate, Country), aggregate($count as count))
        [HttpGet("odata/Authors")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Apply | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Count)]
        public IActionResult AuthorsGroupByYearAndCountry()
        {

            return Ok(_context.Authors);
        }

        // 3. Calculate the total number of books in the library.
        //    Example OData query: GET http://localhost:5142/odata/TotalBooks?$apply=aggregate($count as TotalCount) 
        [HttpGet("odata/TotalBooks")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Count | AllowedQueryOptions.Apply ) ]
        public IActionResult TotalBooks()
        {
            
            return Ok(_context.Books);
        }

        // 4. Retrieve a specified number of book records determined by a page size,
        //    skipping a specified number of records based on the current page number.
        //    The user can use OData’s $top and $skip query options.
        //    Example OData query: GET /odata/Books?$top=2&$skip=2
        [HttpGet("odata/Books")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Count | AllowedQueryOptions.Skip | AllowedQueryOptions.Top ) ]
        public IActionResult Books()
        {
            return Ok(_context.Books);
        }
    }
}
