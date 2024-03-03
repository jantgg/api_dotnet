using Microsoft.AspNetCore.Mvc;
using PruebaApi.Data;
using PruebaApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Asegura que todos los endpoints requieran autenticación.
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        // Obtiene una lista de todos los libros.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                return Ok(books); // Devuelve la lista de libros con un 200 OK.
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada y devuelve un error 500.
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/Books/5
        // Obtiene un libro específico por ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    // Devuelve 404 si no se encuentra el libro.
                    return NotFound($"No se encontró el libro con ID {id}.");
                }
                return book; // Devuelve el libro solicitado con un 200 OK.
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada y devuelve un error 500.
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Books
        // Crea un nuevo libro.

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                // Devuelve errores de validación
                return BadRequest(ModelState);
            }

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBook", new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        // PUT: api/Books/5
        // Actualiza un libro existente y devuelve el libro actualizado.
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                // Devuelve 400 si el ID en la URL no coincide con el ID del libro en el cuerpo de la solicitud.
                return BadRequest("El ID del libro no coincide con el ID en la URL.");
            }

            if (!ModelState.IsValid)
            {
                // Si el estado del modelo no es válido, devuelve un BadRequest con los detalles de la validación.
                return BadRequest(ModelState);
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                // Devuelve 200 OK con el libro actualizado.
                return Ok(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.Id == id))
                {
                    // Devuelve 404 si no se encuentra el libro a actualizar.
                    return NotFound($"No se encontró el libro con ID {id} para actualizar.");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada y devuelve un error 500.
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



        // DELETE: api/Books/5
        // Elimina un libro existente y devuelve el libro eliminado.
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    // Devuelve 404 si no se encuentra el libro a eliminar.
                    return NotFound($"No se encontró el libro con ID {id} para eliminar.");
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                // Devuelve 200 OK con el libro eliminado.
                return Ok(book);
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada y devuelve un error 500.
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
