using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GYMExersiceAPI.ExersiceStore.DataAccess.Repositories;

public class ExersiceInstructionsRepository
{
    private readonly ExerciseStroreDBContext _context;
    
    public ExersiceInstructionsRepository(ExerciseStroreDBContext context)
    {
        this._context = context;
    }
    
    public async Task<Guid> createExerciseInstructionsAsync(
        Guid exerciseStepId,
       List<string> instructions
        )
    {
        ExStepInstructionsEntity exStepInstructionsEntity = new ExStepInstructionsEntity(
            exerciseStepId,
            instructions
            );
        exStepInstructionsEntity.Id = Guid.NewGuid();
        this._context.ExersicesInstructions.Add(exStepInstructionsEntity);
        //Console.WriteLine($"Saving exStepInstructionsEntity: Id: {exStepInstructionsEntity.Id}");
        await this._context.SaveChangesAsync();
        return exStepInstructionsEntity.Id;
    }

    public async Task<List<ExStepInstructionsEntity>> getInstructionsByIdAsync(Guid stepId)
    {
        return await _context.ExersicesInstructions
            .AsNoTracking()
            .Where(i => i.ExerciseStepId == stepId) 
            .ToListAsync();
    }

    public async Task<ExStepInstructionsEntity> getInstructionsEntityByIdAsync(Guid instructionsId)
    {
        return await _context.ExersicesInstructions.FindAsync(instructionsId);
    }
}