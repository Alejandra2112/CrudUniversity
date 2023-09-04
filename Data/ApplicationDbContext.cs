using CrudUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUniversity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Estudiante> Estudiante { get; set;}
        public DbSet<Inscripcion> Inscripcion { get; set;}


    }
}
