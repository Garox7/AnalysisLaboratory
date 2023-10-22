using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;

public class Analysis
{
    public string Name {get;}

    [JsonProperty]
    private List<string> _requiredReagents = new();

    public Analysis(string name)
    {
        Name = name;
    }

    public bool AddReagent(List<Reagent> reagents)
    {
        bool reagentExist = true;

        foreach (var reagentName in _requiredReagents.ToList())
        {
            Reagent? reagent = reagents
                .FirstOrDefault(reagent => reagent.Name == reagentName && reagent.QuantityAvailable >= 1);

            if (reagent != null)
            {
                _requiredReagents.Add(reagentName);
                reagent.DecreaseAvailableQuantity();
            } 
            else
            {
                _requiredReagents.Remove(reagentName);
                reagentExist = false;
            }
        }
        return reagentExist;
    }

    public List<string> GetRequiredReagent()
    {
        return _requiredReagents;
    }

    public override string ToString()
    {
        string reagentString = string.Empty;
        foreach (var reagent in _requiredReagents)
        {
            reagentString += $"{reagent}\n";
        }

        return 
            $"---- {Name.ToUpper()} ----\n"  +
            $"{reagentString}";
    }
}