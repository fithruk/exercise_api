
using GYMExersiceAPI.ExersiceStore.Core.Models;
using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;
using Description = GYMExersiceAPI.ExersiceStore.Core.Models.Description;
using ExerciseStep = GYMExersiceAPI.ExersiceStore.Core.Models.ExerciseStep;


namespace GYMExersiceAPI.ExersiceStore.DataAccess.Repositories;

public class ExersiceRepository
{
    private readonly ExerciseStroreDBContext _context;

    public ExersiceRepository(ExerciseStroreDBContext context)
    {
        this._context = context;
    }
    
    public async Task<List<ExersiceEntity>> GetAllExercisesAsync()
    {
        return await this._context.Exersices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ExersiceEntity?> getExerciseAsync(string exerciseName)
    {
        var exersiceEntity = await this._context.Exersices
            .AsNoTracking()
            .Where(e => e.ExerciseName == exerciseName)
            .FirstOrDefaultAsync();

        return exersiceEntity != null ? exersiceEntity : null;
    }

    public async Task<List<ExersiceEntity>> getExercisesByMuscleGroupe(string muscleGroupe)
    {
        var exercises = await this._context.Exersices
            .AsNoTracking()
            .Where(e => e.ExerciseMuscleGroup == muscleGroupe)
            .ToListAsync();
        return exercises;
    }

    public async Task<List<ExersiceEntity>> getExercisesByEquipment(string equipment)
    {
        var exercises = await this._context.Exersices
            .AsNoTracking()
            .Where(e => e.Equipment == equipment)
            .ToListAsync();
        return exercises;
    }

    public async Task<Guid> createExerciseAsync(Exercise exercise)
    {
        ExersiceEntity exersiceEntity = new ExersiceEntity(
            exercise.ExerciseName, 
            exercise.ExerciseMuscleGroup, 
            exercise.Equipment, 
            exercise.Difficulty,
            exercise.ImageUrl,
            exercise.Steps[0].StepNameRu,
            exercise.Steps[0].StepNameUa
            );
        exersiceEntity.Id = Guid.NewGuid();
        this._context.Exersices.Add(exersiceEntity);
        Console.WriteLine($"Saving exercise: {exersiceEntity.ExerciseName}, Id: {exersiceEntity.Id}");
        await this._context.SaveChangesAsync();
        return exersiceEntity.Id;
    }

    public async Task<ExersiceEntity> findByIdAsync(Guid exerciseId)
    {
        return await _context.Exersices
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == exerciseId);
    }

    public async Task<ExersiceEntity?> findExerciseByNameAsync(string exerciseName)
    {
        var exercise = await this._context.Exersices
            .Where(ex => ex.ExerciseName == exerciseName)
            .Include(e => e.ExerciseSteps)
            .ThenInclude(s => s.Instructions) 
            .FirstOrDefaultAsync();

        if (exercise == null)
        {
            return null;
        }
        exercise.ExerciseSteps = exercise.ExerciseSteps.OrderBy(s => s.PhaseKey).ToList();
        return exercise;

    }
}