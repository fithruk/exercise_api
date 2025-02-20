using System.Collections;
using System.Text.Json;
using GYMExersiceAPI.ExersiceStore.DataAccess.Repositories;
using GYMExersiceAPI.ExersiceStore.Core.Models;
using GYMExersiceAPI.ExersiceStore.DataAcess.Entities;

namespace GYMExersiceAPI.ExersiceStore.DataAccess.DataFeeder;

public class Feeder
{
    private readonly ExersiceRepository _exersiceRepository;
    private readonly ExersiceStepRepository _exersiceStepRepository;
    private readonly ExersiceInstructionsRepository _exersiceInstructionsRepository;
    public Feeder(
        ExersiceRepository exersiceRepository, 
        ExersiceStepRepository exersiceStepRepository, 
        ExersiceInstructionsRepository exersiceInstructionsRepository
        )
    {
        this._exersiceRepository = exersiceRepository;
        this._exersiceStepRepository = exersiceStepRepository;
        this._exersiceInstructionsRepository = exersiceInstructionsRepository;
    }
    public async Task FeedAsync()
    {
        
       
        
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "dataBase.json");
        
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return;
        }
        
        string json = File.ReadAllText(filePath);
        Console.WriteLine(filePath + " filePath");
        var exercises = JsonSerializer.Deserialize<List<Exercise>>(json);
        
        if (exercises == null || exercises.Count == 0)
        {
            Console.WriteLine("Deserialization returned null or empty list!");
            return;
        }

        
        foreach (var ex in exercises)
        {
            Console.WriteLine($"Ex: {ex.ExerciseName}");
            Guid exersiceId = await this._exersiceRepository.createExerciseAsync(ex);
            //Guid exersiceStepId = Guid.NewGuid();
            await this._collectData(ex.Steps[0].DescriptionsRu, exersiceId);// exersiceStepId
            await this._collectData(ex.Steps[0].DescriptionsUa, exersiceId);// exersiceStepId
        }
    }
    private async Task _collectData(ICollection collection, Guid exersiceId)
    {
        foreach (Description step in collection)
        {
            if(step == null) continue;
            Guid exersiceStepId = Guid.NewGuid();
            await this._exersiceStepRepository.createExerciseStepAsync(
                exersiceStepId,
                exersiceId, 
                step.PhaseKey, 
                step.PhaseName
            );
                    
            Guid instructionsId = await _exersiceInstructionsRepository.createExerciseInstructionsAsync(exersiceStepId,step.Instructions);
            ExerciseStepEntity exStep = await this._exersiceStepRepository.getStepByIdAsync(exersiceStepId);
            exStep.Instructions = await _exersiceInstructionsRepository.getInstructionsByIdAsync(instructionsId);// was exersiceStepId
            ExStepInstructionsEntity instructions = await _exersiceInstructionsRepository.getInstructionsEntityByIdAsync(instructionsId);
            instructions.ExerciseStepId = exStep.Id;
            ExersiceEntity exersice = await _exersiceRepository.findByIdAsync(exersiceId);
            exStep.Exersice = exersice;
            exersice.ExerciseSteps.Add(exStep);
        }
    }
}