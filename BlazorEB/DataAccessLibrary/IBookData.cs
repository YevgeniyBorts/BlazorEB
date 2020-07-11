using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IBookData
    {
        Task<List<BookModel>> GetBooks();
        Task InsertBook(BookModel book);
    }
}