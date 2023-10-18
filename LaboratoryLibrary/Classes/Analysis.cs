namespace LaboratoryLibrary.Classes;

public class Analysis
{
    public string Name {get;}
    private List<string> RequiredReagents {get; }

    public Analysis(string name, params string[] reagentName)
    {
        Name = name;
        RequiredReagents = new List<string>();
        foreach (var reagent in reagentName)
        {
            AddReagent(reagent);
        }
    }

    private void AddReagent(string reagentName)
    {
        if (Laboratory.Reagents.Any(reagent => reagent.Name == reagentName))
        {
            RequiredReagents.Add(reagentName);
        } else {
            Console.WriteLine($"In {Name} non è stato aggiunto {reagentName} perchè non è presente in magazzino.");
        }
    }

    public override string ToString()
    {
        return $"{Name}\n";
    }
}