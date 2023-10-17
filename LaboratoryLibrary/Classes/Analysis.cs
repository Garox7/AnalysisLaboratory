namespace LaboratoryLibrary.Classes;

public class Analysis
{
    public string Name {get;}
    public List<Reagent> RequiredReagents {get;}

    public Analysis(string name)
    {
        Name = name;
        RequiredReagents = new List<Reagent>();
    }

    public void AddReagent(Reagent reangent)
    {
        RequiredReagents.Add(reangent);
    }
}