using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;


public class Reagent
{
    public string Name {get;}
    public int QuantityAvaiable {get; private set;}
    public int QuantityInStock {get; private set;}

    public Reagent(string name)
    {
        Name = name;
        QuantityAvaiable = 20;
        QuantityInStock = 20;
    }

    public bool DecreaseAvailableQuantity()
    {
        bool isAvailable = true;

        if (QuantityAvaiable > 0)
        {
            QuantityAvaiable--;
        }
        else isAvailable = false;

        return isAvailable;
    }

    public override string ToString()
    {
        return 
            $"---- {Name.ToUpper()} ----\n" + 
            $"Quantità diponibile: {QuantityAvaiable}\n" +
            $"Qantità in magazzino: {QuantityInStock}\n";
    }
}