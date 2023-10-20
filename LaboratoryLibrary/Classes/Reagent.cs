using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;

public class Reagent
{
    public string Name {get;}

    [JsonProperty]
    public int QuantityAvaiable {get; private set;}

    [JsonProperty]
    public int QuantityInStock {get; private set;}

    public Reagent(string name)
    {
        Name = name;
        QuantityAvaiable = 12;
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
            $"Quantity available: {QuantityAvaiable}\n" +
            $"Quantity in stock: {QuantityInStock}\n";
    }
}