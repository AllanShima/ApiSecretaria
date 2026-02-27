using ApiSecretaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiSecretaria.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Modelbuilder: configurar as tabelas 
        {
            modelBuilder.Entity<Aluno>()
                            .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }

        public static implicit operator ContextBoundObject(Context v)
        {
            throw new NotImplementedException();
        }
    }
}
