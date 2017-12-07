using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiJwt.Entities
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Comercio> Comercios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            const string databaseServer = "192.168.30.23";
            const string databaseName = "mpsfree";//"webapijwt";
            const string databaseUser = "mps_free";
            const string databasePass = "medeve1$";

            return $"Server={databaseServer};" +
                   $"database={databaseName};" +
                   $"uid={databaseUser};" +
                   $"pwd={databasePass};" +
                   $"pooling=true;";
        }
    }
}