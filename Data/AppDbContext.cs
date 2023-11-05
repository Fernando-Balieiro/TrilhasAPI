
using CaminhadasAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CaminhadasAPI.Data; 

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        //Seedar dificuldades

        var difficulty = new List<Difficulty>() {
            new Difficulty() {
                Id = Guid.NewGuid(),
                Name = "Very Easy"
            },
            new Difficulty() {
                Id = Guid.NewGuid(),
                Name = "Easy"
            },
            new Difficulty() {
                Id = Guid.NewGuid(),
                Name = "Medium"
            },
            new Difficulty() {
                Id = Guid.NewGuid(),
                Name = "Hard"
            },
            new Difficulty() {
                Id = Guid.NewGuid(),
                Name = "Very Hard"
            },
        };

        modelBuilder.Entity<Difficulty>().HasData(difficulty);

        var regions = new List<Region>() {
            new Region() {
              Id  = Guid.NewGuid(),
              Name = "São Paulo",
              Code = "SP",
              RegionImageUrl = 
                  "https://upload.wikimedia.org/wikipedia/commons/1/11/Parque_do_ibirapuera_visto_do_c%C3%A9u.jpg",
            },
            new Region() {
              Id  = Guid.NewGuid(),
              Name = "Minas Gerais",
              Code = "MG",
              RegionImageUrl = 
                  "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg",
            },
            new Region() {
              Id  = Guid.NewGuid(),
              Name = "Mato Grosso",
              Code = "MT",
              RegionImageUrl = 
                  "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg",
            },
        };
            modelBuilder.Entity<Region>().HasData(regions);
    }
}