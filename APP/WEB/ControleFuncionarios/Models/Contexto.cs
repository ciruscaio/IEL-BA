#nullable disable
using Microsoft.EntityFrameworkCore;
using ControleFuncionarios.Models;

namespace ControleFuncionarios.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated(); //Cria a base
        }

        public DbSet<Funcionario> Funcionarios { get; set; } //Sincroniza a tabela
        public DbSet<HorarioTrabalho> HorarioTrabalhos { get; set; } //Sincroniza a tabela

    }
}
