namespace LaboratoryLibrary.Classes;


public class Reagent
{
    public string Name {get;}
    private int QuantityAvaiable = 20;
    private int QuantityInStock = 14;

    public Reagent(string reagents)
    {
        Name = reagents;
    }

    public override string ToString()
    {
        return "";
    }
}