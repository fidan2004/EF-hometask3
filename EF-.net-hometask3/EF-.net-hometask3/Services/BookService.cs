using EF_.net_hometask3.Data.Context;
using EF_.net_hometask3.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_.net_hometask3.Services
{
    public class BookService:IBookService
    {
        private readonly BookDbContext _db;

        public BookService(BookDbContext bookDbContext)
        {
            _db = bookDbContext;
        }

        public async Task<Book> Create(Book book)
        {

            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync(); 
            return book;
        }

        public async Task<List<Book>> Get()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> Get(string id)
        {
            var existingBook = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            return existingBook;
        }

        public async Task Remove(string id)
        {
            var existingBook = _db.Books.FirstOrDefault(m => m.Id == id);
            if (existingBook == null) throw new Exception();

            _db.Books.Remove(existingBook);
            await _db.SaveChangesAsync();

        }

        public async Task<Book> Update(string id, Book book)
        {
            var existingBook = _db.Books.First(x => x.Id == id);
            if (existingBook == null) throw new Exception();

            existingBook.BookName = book.BookName;
            existingBook.Author = book.Author;
            existingBook.Category = book.Category;
            existingBook.Price = book.Price;
            await _db.SaveChangesAsync();
            return existingBook;

        }
    }
}

