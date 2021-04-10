using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookAPI.Repositories;
using BookAPI.Models;




namespace BookAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class Bookscontroller : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public Bookscontroller(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        [HttpGet] // manuallyy added 

        [Microsoft.AspNetCore.Mvc.HttpGet]

        public async Task<IEnumerable<Book>> GetBooks()
        {

            return await _bookRepository.Get();
        }

        [HttpGet("{Id}") ] // manuallyy added

        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);

        }

        [HttpPost] // manuallyy added 

        public async Task<ActionResult<Book>> PostBooks ([FromBody] Book book)

        {


            var newBook = await _bookRepository.Create(book);

            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);

        }

        [HttpPut] // manuallyy added 


        public async Task <ActionResult> PutBooks (int id, [FromBody]  Book book)
        {

            if(id != book.Id)
            {
                return BadRequest();
            }
            await _bookRepository.Update(book);
            return NoContent();

        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete (int id)
        {

            var bookToDelete = await _bookRepository.Get(id);

            if(bookToDelete == null)
            
                return NotFound();
                await _bookRepository.Delete(bookToDelete.Id);

                return NoContent();
        }



    }
}
