using AuthAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Infra.Data.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ApplicationUser> Users { get; set; }
}