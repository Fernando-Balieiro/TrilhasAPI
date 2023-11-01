
using CaminhadasAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CaminhadasAPI.Data; 

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
}