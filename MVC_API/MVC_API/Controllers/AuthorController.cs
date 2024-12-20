﻿using Microsoft.AspNetCore.Mvc;

namespace MVC_API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            Author? result = _authorService.GetAuthor(id);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        [HttpPost]
        public IActionResult PostAuthor(Author author)
        {
            _authorService.PostAuthor(author);
            return Created($"/authors/{author.Id}", author);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            bool searchResult = _authorService.authorExists(id);
            if (!searchResult) return BadRequest();
            _authorService.DeleteAuthor(id);
            return NoContent();

        }
    }
}
