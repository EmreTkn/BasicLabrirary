using LibraryProject.Concreate;
using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryProject.Dtos;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly BookRepository _bookRepository;
        private readonly CommentRepository _commentRepository;

        public LibraryController(CommentRepository commentRepository, BookRepository bookRepository)
        {
            _commentRepository = commentRepository;
            _bookRepository = bookRepository;
        }


        [HttpGet("get-book")]
        public async Task<BookDto> GetCommentByBookId(int id)
        {
            var book = await _bookRepository.GetEntitiesById(id);
            var comments = new List<CommentDto>();
            foreach (var comment in book.Comments)
            {
                comments.Add(new CommentDto
                {
                    BookId = comment.BookId,
                    CommentDescription = comment.CommentDescription,
                });
            }
            var bookToReturn = new BookDto
            {
                Comments = comments,
                CategoryName = book.CategoryName,
                Name = book.Name,
                YayinEviAdi = book.YayinEviAdi,
                YazarAdi = book.YazarAdi,
                Url = book.Url
            };

            return bookToReturn;
        }

        [HttpGet("get-all-books")]
        public async Task<IReadOnlyList<Book>> GetAllBooks()
        {
            return await _bookRepository.GetEntities();
        }

        [HttpPost("add-comment")]
        public async Task<ActionResult> AddComment(CommentDto comment)
        {
            var commentToAdd = new Comment
            {
                Book = await _bookRepository.GetEntitiesById(comment.BookId),
                BookId = comment.BookId,
                CommentDescription = comment.CommentDescription
            };
            await _commentRepository.AddComment(commentToAdd);
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpPost("add-book")]
        public async Task<ActionResult> AddComment(BookToAddDto book)
        {
            var bookToAdd = new Book
            {
                CategoryName = book.CategoryName,
                Name = book.Name,
                YayinEviAdi = book.YayinEviAdi,
                YazarAdi = book.YazarAdi,
                Url = book.Url
            };
            await _bookRepository.AddComment(bookToAdd);
            return Ok();
        }
    }
}
