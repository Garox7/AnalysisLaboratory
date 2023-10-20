using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;

public class Analysis
{
    public string Name {get;}

    [JsonProperty]
    private List<string> RequiredReagents = new();

    public Analysis(string name)
    {
        Name = name;
    }

    public bool AddReagent(List<Reagent> reagents)
    {
        bool reagentExist = true;

        foreach (var reagentName in RequiredReagents.ToList())
        {
            Reagent? reagent = reagents
                .FirstOrDefault(reagent => reagent.Name == reagentName && reagent.QuantityAvaiable >= 1);

            if (reagent != null)
            {
                RequiredReagents.Add(reagentName);
                reagent.DecreaseAvailableQuantity();
            } 
            else
            {
                RequiredReagents.Remove(reagentName);
                reagentExist = false;
            }
        }

        return reagentExist;
    }

    public override string ToString()
    {
        string reagentString = string.Empty;
        foreach (var reagent in RequiredReagents)
        {
            reagentString += $"{reagent}\n";
        }

        return 
            $"---- {Name.ToUpper()} ----\n"  +
            $"{reagentString}";
    }
}