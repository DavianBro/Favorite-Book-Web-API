using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Models;

// Davian Brown




namespace BookAPI.Repositories
{

        public interface IBookRepository
        {
            Task<IEnumerable<Book>> Get();

            Task<Book> Get(int id);
            Task<Book> Create(Book book);
            Task Update(Book book);
            Task Delete(int id);
        }
    }

