using EF_.net_hometask3.Data.Entities;

namespace EF_.net_hometask3.Services
{
    public interface IBookService
    {
        Task<List<Book>> Get();
        Task<Book> Get(string id);
        Task<Book> Create(Book book);
        Task<Book> Update(string id, Book book);
        Task Remove(string id);
    }
}
