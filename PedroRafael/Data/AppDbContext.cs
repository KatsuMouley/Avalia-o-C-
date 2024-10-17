using Microsoft.EntityFrameworkCore;
using PedroRafael.Models;
using PedroRafael.Data;

public class AppDbContext : DbContext
{
    public DbSet<Folha> Folhas { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=pedrorafael_vitormougenot.db");
    }
}