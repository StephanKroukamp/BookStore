using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Entities;
using BookStore.Resources;
using BookStore.Services;
using BookStore.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;

        private readonly IMapper _mapper;

        public BooksController(IBookService booksService, IMapper mapper)
        {
            _mapper = mapper;

            _booksService = booksService;
        }

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BookResource>>> GetAllBooks()
        {
            var books = await _booksService.GetAllWithAuthor();

            var bookResources = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(books);

            return Ok(bookResources);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BookResource>> GetBookByIdWithAuthor(int id)
        {
            var book = await _booksService.GetBookByIdWithAuthor(id);

            var bookResource = _mapper.Map<Book, BookResource>(book);

            return Ok(bookResource);
        }

        [HttpPost("")]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<ActionResult<BookResource>> CreateBook([FromBody] SaveBookResource saveBookResource)
        {
            var validator = new SaveBookResourceValidator();

            var validationResult = await validator.ValidateAsync(saveBookResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors); // this needs refining
            }

            var bookToCreate = _mapper.Map<SaveBookResource, Book>(saveBookResource);

            var newBook = await _booksService.CreateBook(bookToCreate);

            var book = await _booksService.GetBookByIdWithAuthor(newBook.Id);

            var bookResource = _mapper.Map<Book, BookResource>(book);

            return Ok(bookResource);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<ActionResult<BookResource>> UpdateBook(int id, [FromBody] SaveBookResource saveBookResource)
        {
            var validator = new SaveBookResourceValidator();

            var validationResult = await validator.ValidateAsync(saveBookResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
            {
                return BadRequest(validationResult.Errors); // this needs refining
            }

            var bookToBeUpdated = await _booksService.GetBookByIdWithAuthor(id);

            if (bookToBeUpdated == null)
            {
                return NotFound();
            }

            var book = _mapper.Map<SaveBookResource, Book>(saveBookResource);

            await _booksService.UpdateBook(bookToBeUpdated, book);

            var updatedBook = await _booksService.GetBookByIdWithAuthor(id);

            var updatedBookResource = _mapper.Map<Book, BookResource>(updatedBook);

            return Ok(updatedBookResource);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }  

            var book = await _booksService.GetBookByIdWithAuthor(id);

            if (book == null)
            {
                return NotFound();
            }

            await _booksService.DeleteBook(book);

            return NoContent();
        }
    }
}