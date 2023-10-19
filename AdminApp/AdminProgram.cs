using System;
using Newtonsoft.Json;
using LaboratoryLibrary.Classes;

class Program
{
    static void Main()
    {
        JsonFileManager jsonFile = new();
        // program.Inizialization();


        jsonFile.ReadAnalysisJsonFile();
        // foreach (var reagent in Laboratory.Reagents)
        // {
        //     Console.WriteLine(reagent.ToString());
        // }

        // foreach (var analysis in Laboratory.Analysis)
        // {
        //     Console.WriteLine(analysis.ToString());
        // }

        do
        {
            Console.WriteLine("Welcome To Laboratory");
            Console.WriteLine("1. Login as a Admin");
            Console.WriteLine("2. Continue as a Guest");
            Console.WriteLine("3. Exit to Program");

            string choise = Console.ReadLine().Trim();

            switch (choise)
            {
                case "1":
                    AdminInterface.Admin();
                    break;
                case "2":
                    UserInterface.User();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid Choise");
                    return;
            }

        } while (true);
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
        var array1 = new List<string>{"reagente9", "reagente7", "reagente6"};
        var array2 = new List<string>{"reagente4", "reagente7", "reagente6"};
        var array3 = new List<string>{"reagente3", "reagente2", "reagente1"};
        var array4 = new List<string>{"reagente9", "reagente8", "reagente5"};
        Analysis analysis1 = new("analisi_1", array1) ;
        Analysis analysis2 = new("analisi_2", array2);
        Analysis analysis3 = new("analisi_3", array3);
        Analysis analysis4 = new("analisi_4", array4);

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
