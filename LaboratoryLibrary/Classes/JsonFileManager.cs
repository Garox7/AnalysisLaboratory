using Newtonsoft.Json;
namespace LaboratoryLibrary.Classes;

public delegate string JsonWriter<T>(T data, Formatting indent);

public class JsonFileManager
{
    private Laboratory _lab;
    private readonly string filePathReagents = @"/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Reagent.JSON";
    private readonly string filePathAnalysis = @"/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Analysis.JSON";
    public readonly string filePathPrenotations = @"/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Prenotations.JSON";

    public JsonFileManager(Laboratory lab) {
        _lab = lab;
    }

    public async void ReadAnalysesJsonFile()
    {
        using (StreamReader reader = new StreamReader(filePathAnalysis))
        {
            string json = await reader.ReadToEndAsync();
            var analysis = JsonConvert.DeserializeObject<List<Analysis>>(json);
            _lab.SetAnalyses(analysis);
        }
    }

    public async void ReadReagentJsonFile()
    {
        using (StreamReader reader = new StreamReader(filePathReagents))
        {
            string json = await reader.ReadToEndAsync();
            var reagents = JsonConvert.DeserializeObject<List<Reagent>>(json);
            _lab.SetReagents(reagents);
        }
    }

     public async void ReadPrenotationJsonFile()
    {
        using (StreamReader reader = new StreamReader(filePathPrenotations))
        {
            string json = await reader.ReadToEndAsync();
            var prenotations = JsonConvert.DeserializeObject<Dictionary<string, List<Prenotation>>>(json);
            _lab.SetPrenotations(prenotations);
        }
    }
    
    public void WriteJsonFile<T>(string filePath, T data, JsonWriter<T> jsonWriter)
    {
       string jsonData = jsonWriter(data, Formatting.Indented);
       File.WriteAllText(filePath, jsonData);
    }
}