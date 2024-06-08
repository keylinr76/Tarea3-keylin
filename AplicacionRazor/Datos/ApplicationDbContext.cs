using AplicacionRazor.modelos;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Los modelos se escriben aquí
    public DbSet<Curso> Curso { get; set; }
}

