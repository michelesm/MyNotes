using Microsoft.EntityFrameworkCore;
using MyNotes.API.Models;

namespace MyNotes.API.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<Category> Categories { get; set; }
    public DbSet<Note> Notes { get; set; }
}
