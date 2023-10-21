namespace LaboratoryLibrary.Classes;

public class Analysis
{
    public string Name {get;}
    public List<string> RequiredReagents {get; }

    public Analysis(string name)
    {
        Name = name;
        RequiredReagents = new List<string>();
        
        if (reagentName != null)
        {
            foreach (string reagent in reagentName)
            {
                AddReagent(reagent);
            }
        }
        else
        {
            Console.WriteLine($"In {Name}, la lista di reagenti è nulla.");
        }
    }

    private void AddReagent(string reagentName)
    {
        if (Laboratory.Reagents.Any(reagent => reagent.Name == reagentName))
        {
            RequiredReagents.Add(reagentName);
        }
    }

    public override string ToString()
    {
        string reagentString = string.Empty;
        foreach (var reagent in RequiredReagents)
        {
            reagentString += $"{reagent}\n";
        }

        return 
            $"{Name}\n" +
            $"{reagentString}";
    }
}