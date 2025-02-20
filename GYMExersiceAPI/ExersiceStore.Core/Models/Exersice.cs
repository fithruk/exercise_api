namespace GYMExersiceAPI.ExersiceStore.Core.Models;

public class Exercise
{

 public Exercise(
  
  string exerciseName, 
  string exerciseMuscleGroup, 
  string equipment, 
  string difficulty, 
  string imageUrl, 
  List<ExerciseStep> steps)
 {
  this.ExerciseName = exerciseName;
  this.ExerciseMuscleGroup = exerciseMuscleGroup;
  this.Equipment = equipment;
  this.Difficulty = difficulty;
  this.ImageUrl = imageUrl;
  this.Steps = steps;
 }
 
 public string ExerciseName { get; }
 public string ExerciseMuscleGroup { get; }
 public string Equipment { get; }
 public string Difficulty { get; }
 public string ImageUrl { get; }
 public List<ExerciseStep> Steps { get; }
}

public class ExerciseStep
{
 public string StepNameEng { get; }
 public string StepNameRu { get; }
 public string StepNameUa { get; }
 public List<Description> DescriptionsRu { get; }
 public List<Description> DescriptionsUa { get;  }

 public ExerciseStep(string stepNameEng, string stepNameRu, string stepNameUa, List<Description> descriptionsRu, List<Description> descriptionsUa)
 {
  this.StepNameEng = stepNameEng;
  this.StepNameRu = stepNameRu;
  this.StepNameUa = stepNameUa;
  this.DescriptionsRu = descriptionsRu;
  this.DescriptionsUa = descriptionsUa;
 }
}

public class Description
{
 public int PhaseKey { get; }
 public string PhaseName { get; }
 public List<string> Instructions { get; }

 public Description(int phaseKey, string phaseName, List<string> instructions)
 {
  this.PhaseKey = phaseKey;
  this.PhaseName = phaseName;
  this.Instructions = instructions;
 }
}