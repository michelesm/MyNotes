using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNotes.API.Data;
using MyNotes.API.Models;

namespace MyNotes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase {
    private readonly AppDbContext _context;
    public NotesController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> Get() =>
        await _context.Notes.Include(n => n.Category).ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> Get(int id) {
        var note = await _context.Notes.FindAsync(id);
        return note is null ? NotFound() : note;
    }

    [HttpPost]
    public async Task<ActionResult<Note>> Post(Note note) {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Note note) {
        if (id != note.Id) return BadRequest();
        _context.Entry(note).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        var note = await _context.Notes.FindAsync(id);
        if (note is null) return NotFound();
        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
