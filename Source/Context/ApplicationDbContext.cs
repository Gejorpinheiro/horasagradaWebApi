using HoraSagradaWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace HoraSagradaWebApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {}

        public DbSet<Usuario> Usuario { get; set;}
        public DbSet<Restaurante> Restaurante { get; set;}
    }
}