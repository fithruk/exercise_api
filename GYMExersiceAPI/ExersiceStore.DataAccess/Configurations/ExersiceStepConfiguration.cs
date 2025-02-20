using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYMExersiceAPI.ExersiceStore.DataAccess.Configurations;

public class ExersiceStepConfiguration : IEntityTypeConfiguration<ExerciseStepEntity>
{
    public void Configure(EntityTypeBuilder<ExerciseStepEntity> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).IsRequired();
        builder.Property(s => s.ExersiceId).IsRequired();
        
        
        builder.HasOne(e => e.Exersice)
            .WithMany(e => e.ExerciseSteps)
            .HasForeignKey(e => e.ExersiceId);

        builder.HasMany(s => s.Instructions)
            .WithOne(i => i.ExerciseStep)
            .HasForeignKey(i => i.ExerciseStepId);
    }
}

