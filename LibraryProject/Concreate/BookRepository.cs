using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Abstract;
using LibraryProject.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace LibraryProject.Concreate
{
    public class BookRepository : IGenericRepository<Book>
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddComment(Book entity)
        {
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book entity)
        {
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetEntitiesById(int id)
        {
            return await _context.Books.Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Book>> GetEntities()
        {
            return await _context.Books
                .ToListAsync();
        }
    }
}
