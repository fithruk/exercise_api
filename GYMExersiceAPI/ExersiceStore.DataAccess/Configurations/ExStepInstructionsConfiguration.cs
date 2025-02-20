using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GYMExersiceAPI.ExersiceStore.DataAccess.Configurations;

public class ExStepInstructionsConfiguration : IEntityTypeConfiguration<ExStepInstructionsEntity>
{
    public void Configure(EntityTypeBuilder<ExStepInstructionsEntity> builder)
    {
        // ✅ Указываем правильный первичный ключ
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired();
        
        builder.Property(e => e.ExerciseStepId).IsRequired();
        builder.Property(e => e.Instructions).IsRequired();

        // ✅ Один шаг (ExerciseStepEntity) может иметь много инструкций (ExStepInstructionsEntity)
        builder.HasOne(e => e.ExerciseStep)  
            .WithMany(s => s.Instructions) // 👈 Коллекция инструкций внутри шага
            .HasForeignKey(e => e.ExerciseStepId); // 👈 Указываем внешний ключ
        
    }
}