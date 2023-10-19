using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;


public class Reagent
{
    public string Name {get;}
    public int QuantityAvaiable = 20;
    public int QuantityInStock = 14;

    public Reagent(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return 
            $"Nome: {Name}\n" + 
            $"Quantità diponibile: {QuantityAvaiable}\n" +
            $"Qantità in magazzino: {QuantityInStock}\n";
    }
}