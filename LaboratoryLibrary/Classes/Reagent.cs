using LaboratoryLibrary.Exceptions;
using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;

public class Reagent
{
    public string Name {get;}

    [JsonProperty]
    public int QuantityAvailable {get; private set;}

    [JsonProperty]
    public int QuantityInStock {get; private set;}

    public Reagent(string name)
    {
        Name = name;
    }

    // private bool RequestNewAvailableQuantity()
    // {
        
    // }

    // questo metodo si occupa di decrementare le quantità disponibili.
    // Se queste non sono disponibii allora richiene una nuova disponibilià dal magazzino.
    public bool DecreaseAvailableQuantity()
    {
        if (QuantityAvailable > 0)
        {
            QuantityAvailable--;
            return true;

        }
        else 
        {
            throw new ReagentUnavailableException("Insufficient quantity available");
        }
    }

    public override string ToString()
    {
        return 
            $"---- {Name.ToUpper()} ----\n" + 
            $"Quantity available: {QuantityAvailable}\n" +
            $"Quantity in stock: {QuantityInStock}\n";
    }
}