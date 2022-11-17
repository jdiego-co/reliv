using domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace infraestructure.Repositories;

public class LocalDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public LocalDbContext(DbContextOptions options) : base(options)
	{
	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .ToTable("Patients", "dbo")
            .HasKey(x => x.PatientID);

        base.OnModelCreating(modelBuilder);
    }
}
