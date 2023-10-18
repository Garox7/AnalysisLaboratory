using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using LaboratoryLibrary.Classes;

class Program
{
    static void Main(string[] args)
    {
        Program program = new();
        Laboratory lab = new();
        JsonFileManager jsonFile = new();
        // program.Inizialization();

        string filePathAnalysis = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Analysis.JSON";
        string filePathReagents = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Reagent.JSON";

        Laboratory.Analysis = jsonFile.ReadJsonFile(filePathAnalysis, JsonConvert.DeserializeObject<List<Analysis>>);
        
        foreach (var analysis in Laboratory.Analysis)
        {
            Console.WriteLine(analysis.ToString());
        }
    }

    public void Inizialization()
    {
        // REAGENTS
        Reagent reagent1 = new("reagente1");
        Reagent reagent2 = new("reagente2");
        Reagent reagent3 = new("reagente3");
        Reagent reagent4 = new("reagente4");
        Reagent reagent5 = new("reagente5");
        Reagent reagent6 = new("reagente6");
        Reagent reagent7 = new("reagente7");
        Reagent reagent8 = new("reagente8");
        Reagent reagent9 = new("reagente9");

        Laboratory.Reagents.Add(reagent1);
        Laboratory.Reagents.Add(reagent2);
        Laboratory.Reagents.Add(reagent3);
        Laboratory.Reagents.Add(reagent4);
        Laboratory.Reagents.Add(reagent5);
        Laboratory.Reagents.Add(reagent6);
        Laboratory.Reagents.Add(reagent7);
        Laboratory.Reagents.Add(reagent8);
        Laboratory.Reagents.Add(reagent9);

        // ANALYSIS
        Analysis analysis1 = new("analisi_1", "reagente9", "reagente7", "reagente6") ;
        Analysis analysis2 = new("analisi_2", "reagente5", "reagente1");
        Analysis analysis3 = new("analisi_3", "reagente6", "reagente5", "reagente2");
        Analysis analysis4 = new("analisi_4", "reagente3", "reagente1");

        Laboratory.Analysis.Add(analysis1);
        Laboratory.Analysis.Add(analysis2);
        Laboratory.Analysis.Add(analysis3);
        Laboratory.Analysis.Add(analysis4);

        // WRITE FILE
        JsonFileManager jsonFile = new();

        string filePathAnalysis = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Analysis.JSON";
        string filePathReagents = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Reagent.JSON";
        jsonFile.WriteJsonFile(filePathAnalysis, Laboratory.Analysis, JsonConvert.SerializeObject);
        jsonFile.WriteJsonFile(filePathReagents, Laboratory.Reagents, JsonConvert.SerializeObject);
    }
}
