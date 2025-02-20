namespace GYMExersiceAPI.ExersiceStore.DataAcess.Entities;

public class ExersiceEntity
{
    public Guid Id { get; set; }
    public string? ExerciseName { get; set; }
    public string? ExerciseMuscleGroup { get; set; }
    public string? Equipment { get; set; }
    public string? Difficulty { get; set; }
    public string? ImageUrl { get; set; }
    
    public string? TitleRu { get; set; }
    public string? TitleUa { get; set; }
    
    public ICollection<ExerciseStepEntity> ExerciseSteps { get; set; } =  new List<ExerciseStepEntity>();
    
    public ExersiceEntity(
        string exerciseName, 
        string exerciseMuscleGroup, 
        string equipment, 
        string difficulty, 
        string imageUrl, 
        string titleRu, 
        string titleUa
        )
    {
        ExerciseName = exerciseName;
        ExerciseMuscleGroup = exerciseMuscleGroup;
        Equipment = equipment;
        Difficulty = difficulty;
        ImageUrl = imageUrl;
        TitleRu = titleRu;
        TitleUa = titleUa;
    }
}



