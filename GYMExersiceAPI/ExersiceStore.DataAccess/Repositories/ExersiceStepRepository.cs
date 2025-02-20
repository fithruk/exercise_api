
using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GYMExersiceAPI.ExersiceStore.DataAccess.Repositories;

public class ExersiceStepRepository
{
    private readonly ExerciseStroreDBContext _context;
    
    public ExersiceStepRepository(ExerciseStroreDBContext exerciseStroreDBContext)
    {
        this._context = exerciseStroreDBContext;
    }
    
    public async Task createExerciseStepAsync(Guid stepId, Guid exersiceId, int phaseKey,string phaseName )
    {
        ExerciseStepEntity exersiceStepEntity = new ExerciseStepEntity(
            stepId,
            exersiceId,
            phaseKey,
            phaseName
        );
       // exersiceStepEntity.Id = Guid.NewGuid();
        this._context.ExersicesSteps.Add(exersiceStepEntity);
        Console.WriteLine($"Saving exerciseStep: {exersiceStepEntity.Id}");
        await this._context.SaveChangesAsync();
        
    }

    public async Task<ExerciseStepEntity> getStepByIdAsync(Guid stepId)
    {
        return await _context.ExersicesSteps
            .AsNoTracking()
            .FirstOrDefaultAsync(step => step.Id == stepId);
    }
}