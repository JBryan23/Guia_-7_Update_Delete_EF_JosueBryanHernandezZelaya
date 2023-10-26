using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class UNABDbContext : DbContext
{
    //entities
    public DbSet<Estudiante> Estudiante { get; set; }
    //public DbSet<Grado> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-1I3C54GG\\SQLEXPRESS;Database=Progra2;Trusted_Connection=True;"); //Nota cambiar saver name de conexion de su computadora 
    }
}