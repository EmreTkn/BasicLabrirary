using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Abstract;
using LibraryProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Concreate
{
    public class CommentRepository : IGenericRepository<Comment>
    {
        private readonly LibraryContext _context;

        public CommentRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddComment(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> GetEntitiesById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Comment>> GetEntities()
        {
            return await _context.Comments
                .ToListAsync();
        }
    }
}
