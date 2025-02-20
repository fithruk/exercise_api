using System.Text.Json.Serialization;

namespace GYMExersiceAPI.ExersiceStore.DataAcess.Entities;

public class ExStepInstructionsEntity
{
    public Guid Id { get; set; }
    public Guid ExerciseStepId { get; set; }
    
    [JsonIgnore]
    public ExerciseStepEntity ExerciseStep { get; set; }
    
    
    
    public List<string> Instructions { get; set; } = new();

    public ExStepInstructionsEntity() { }
    
    public ExStepInstructionsEntity(Guid exerciseStepId, List<string> instructions)
    {
        this.ExerciseStepId = exerciseStepId;
        this.Instructions = instructions;
    }
}