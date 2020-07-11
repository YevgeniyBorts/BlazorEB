using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class BookData : IBookData
    {
        private readonly ISQLDataAccess _db;

        public BookData(ISQLDataAccess db)
        {
            _db = db;
        }

        public Task<List<BookModel>> GetBooks()
        {
            string sql = "select * from dbo.Books";

            return _db.LoadData<BookModel, dynamic>(sql, new { });
        }

        public Task InsertBook(BookModel book)
        {
            string sql = @"insert into Dbo.Books (Title, Author, Category, Genre, Format, Year, Read) 
                        values (@Title, @Author, @Category, @Genre, @Format, @Year, @Read)";

            return _db.SaveData(sql, book);
        }
    }
}
