using System.Runtime.CompilerServices;
using Newtonsoft.Json;
namespace LaboratoryLibrary.Classes;

public delegate string JsonWriter<T>(T data, Formatting indent);

public class JsonFileManager
{
    string filePathReagents = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Reagent.JSON";
    string filePathAnalysis = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Analysis.JSON";


    public void ReadAnalysisJsonFile()
    {
        using (StreamReader reader = new StreamReader(filePathReagents))
        {
            Console.WriteLine("Sto caricando i reagenti");
            string json = reader.ReadToEnd();
            Laboratory.Reagents = new List<Reagent>(JsonConvert.DeserializeObject<List<Reagent>>(json));
        }

        using (StreamReader reader = new StreamReader(filePathAnalysis))
        {
            Console.WriteLine("Sto caricando le analisi");
            string json = reader.ReadToEnd();
            Laboratory.Analysis = JsonConvert.DeserializeObject<List<Analysis>>(json);
        }
    }

    public void ReadReagentJsonFile() {
    }
    
    public void WriteJsonFile<T>(string filePath, T data, JsonWriter<T> jsonWriter)
    {
       string jsonData = jsonWriter(data, Formatting.Indented);
       File.WriteAllText(filePath, jsonData);
    }
}