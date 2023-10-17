namespace LaboratoryLibrary.Classes;


public class Reagent
{
    public string Name {get;}
    readonly int QuantityAvaiable = 20;
    public int QuantityInStock = 15;

    public Reagent(string reagents)
    {
        Name = reagents;
    }
}