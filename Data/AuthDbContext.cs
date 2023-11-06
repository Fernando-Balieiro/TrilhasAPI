using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaminhadasAPI.Data; 

public class AuthDbContext : IdentityDbContext {
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        var readerRoleId = Guid.NewGuid();
        var writerRoleId = Guid.NewGuid();
        var roles = new List<IdentityRole>() {
            new IdentityRole() {
                Id = readerRoleId.ToString(),
                ConcurrencyStamp = readerRoleId.ToString(),
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole() {
                Id = writerRoleId.ToString(),
                ConcurrencyStamp = writerRoleId.ToString(),
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}