using EF_.net_hometask3.Data.Entities;
using EF_.net_hometask3.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_.net_hometask3.Controllers
{
    public class BooksController:ControllerBase
    {
        private readonly IBookService _bookService;


        public BooksController(IBookService bookService)
        {
            _bookService = bookService;

        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.Get();
            return Ok(result);
        }

        

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var existingBook = await _bookService.Get(id);
            return Ok(existingBook);
        }
        [HttpPut("book/{id}")]
        public async Task<IActionResult> UpdateBook(string id, Book book)
        {
            var isSuccessfullyUpdated = await _bookService.Update(id, book);
            return Ok(isSuccessfullyUpdated);

        }
        [HttpDelete("{id")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            await _bookService.Remove(id);
            return Ok();
        }

        public async Task<IActionResult> Create(Book book)
        {
            var isSuccessfullyCreated = await _bookService.Create(book);
            return Ok(book);
        }
    }
}

