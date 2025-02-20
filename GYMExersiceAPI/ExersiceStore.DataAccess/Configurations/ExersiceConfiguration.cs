using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYMExersiceAPI.ExersiceStore.DataAccess.Configurations;

public class ExersiceConfiguration : IEntityTypeConfiguration<ExersiceEntity>
{
    public void Configure(EntityTypeBuilder<ExersiceEntity> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.ExerciseName).IsRequired();
        builder.Property(e => e.Difficulty).IsRequired();
        builder.Property(e => e.ImageUrl).IsRequired();
        builder.Property(e => e.Equipment).IsRequired();

        
        builder
            .HasMany(ex => ex.ExerciseSteps)
            .WithOne(st => st.Exersice)
            .HasForeignKey(st => st.ExersiceId);
    }
}



