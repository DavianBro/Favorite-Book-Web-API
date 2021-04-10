using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;


// Davian Brown

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Book>> Get()
        {

            return await _context.Books.ToListAsync();

        }


        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id);

        }
        public async Task<Book> Create(Book book)
        {

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return book;

        }
        public async Task Update(Book book)
        {

            _context.Entry(book).State = EntityState.Modified;

           await _context.SaveChangesAsync();

        }
        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }


    }
    //5.4. Inject a BookContext field and Constructor on top of the class

}
        



