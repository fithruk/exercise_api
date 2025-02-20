using System.Security.Cryptography;

namespace GYMExersiceAPI.ExersiceStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;

public class ExerciseStroreDBContext : DbContext
{
    public ExerciseStroreDBContext(DbContextOptions<ExerciseStroreDBContext> options) : base(options)
    {}
    
    public DbSet<ExersiceEntity> Exersices { get; set; }
    
    public DbSet<ExerciseStepEntity> ExersicesSteps { get; set; }
    
    public DbSet<ExStepInstructionsEntity> ExersicesInstructions { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseStepEntity>()
            .HasKey(e => e.Id); 
        
        // modelBuilder.Entity<ExerciseStepEntity>()
        //     .Ignore(e => e.Exersice); // Отключаем обратную связь, чтобы не было рекурсии
        
        modelBuilder
            .Entity<ExStepInstructionsEntity>(e =>
                e.Property(i => i.Instructions)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ??
                             new List<string>()
                    ).HasColumnType("LONGTEXT"));
    }
}