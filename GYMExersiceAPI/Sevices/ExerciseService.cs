using GYMExersiceAPI.ExersiceStore.DataAccess.Repositories;
using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;

namespace GYMExersiceAPI.Sevices;

public class ExerciseService
{
    private readonly ExersiceRepository _exersiceRepository;
    public ExerciseService(ExersiceRepository exersiceRepository)
    {
        this._exersiceRepository = exersiceRepository;
    }

    public async Task<List<ExersiceEntity>> GetAllExercises()
    {
        var exercises = await this._exersiceRepository
            .GetAllExercisesAsync()
            .ConfigureAwait(false);

        return exercises.ToList();
    }

    public async Task<ExersiceEntity?> GetExerciseByName(string exerciseName)
    {
        var exercise = await this._exersiceRepository.findExerciseByNameAsync(exerciseName);
        if (exercise == null) return null;
        return exercise;

    }
    
}