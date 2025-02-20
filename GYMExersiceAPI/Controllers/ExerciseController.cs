using GYMExersiceAPI.DTO;
using GYMExersiceAPI.ExersiceStore.Core.Models;
using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;
using Microsoft.AspNetCore.Mvc;
using GYMExersiceAPI.Sevices;
namespace GYMExersiceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly ExerciseService _exerciseService;
    
    public ExercisesController(ExerciseService exerciseService)
    {
        this._exerciseService = exerciseService;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetExercises()
    {
        var exercises = await _exerciseService.GetAllExercises();
       return Ok(exercises);
    }

    [HttpPost("getExerciseByName")]
    public async Task<IActionResult> getExerciseByName([FromBody] ExerciseDTO exerciseName)
    {
        var exercise = await _exerciseService.GetExerciseByName(exerciseName.ExerciseName);
        if(exercise == null) return NotFound(new Dictionary<string, string> { { "exercise", $"{exerciseName.ExerciseName} is not found" } });
        
       return Ok(new Dictionary<string, ExersiceEntity> { { "exercise", exercise } });
    }
}