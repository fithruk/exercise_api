using System.Text.Json.Serialization;

namespace GYMExersiceAPI.ExersiceStore.DataAcess.Entities;

public class ExerciseStepEntity
{
    public Guid Id { get; set; }
    public Guid ExersiceId { get; set; }
    
    public int PhaseKey { get; set; }
    public string PhaseName { get; set; }
    
    [JsonIgnore]
    public ExersiceEntity Exersice { get; set; }
    public ICollection<ExStepInstructionsEntity> Instructions { get; set; } = new List<ExStepInstructionsEntity>();

    public ExerciseStepEntity(){}
    public ExerciseStepEntity(Guid stepId, Guid exersiceId, int phaseKey, string phaseName)
    {
        this.Id = stepId;
        this.ExersiceId = exersiceId;
        this.PhaseName = phaseName;
        this.PhaseKey = phaseKey;
    }
    
}