using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SpesenApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Personen => Set<Person>();
    public DbSet<SpesenEintrag> SpesenEintraege => Set<SpesenEintrag>();
}