using gestion_etablissement.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_etablissement {
public class GestionContext : DbContext
    {
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                @"Server=127.0.0.1;Initial Catalog=epsi;User ID=sa;Password=RjBnc450");
        }
    }
}
