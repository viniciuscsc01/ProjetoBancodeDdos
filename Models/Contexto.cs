using Microsoft.EntityFrameworkCore;
using ProjetoBancodeDados.Models;
using ProjetoBancoDeDados.Models;

namespace ProjetoBancodeDdos.Models
{
    public class Contexto : DbContext
    {
    
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }



        public DbSet<Eventos> eventos { get; set; }
        public DbSet<Inscricoes> Inscricoes { get; set; }


        public DbSet<Pagamentos> Pagamentos { get; set; }


        public DbSet<Passagens> Passagens { get; set; }


        public DbSet<Usuarios> Usuarios { get; set; } }


}


