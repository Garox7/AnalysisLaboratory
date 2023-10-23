using LaboratoryLibrary.Classes;
using Newtonsoft.Json;

public class Prenotation
{
    [JsonProperty]
    private Analysis _analyses;

    public Prenotation (Analysis analysis)
    {
        _analyses = analysis;
    }

    public override string ToString()
    {
        return $"\n - {_analyses.Name.ToUpper()}\n";
    }
}