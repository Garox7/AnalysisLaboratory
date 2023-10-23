using LaboratoryLibrary.Exceptions;
using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;

public class Reagent
{
    public string Name { get; }

    [JsonProperty]
    public int QuantityAvailable { get; private set; }

    [JsonProperty]
    public int QuantityInStock { get; private set; }

    public Reagent(string name)
    {
        Name = name;
    }

    /* 
        sarebbe possibile creare una funzione che possa interaggire con il magazzino
        che predisporrebbe nuovamente le quantità disponibili se queste sono a 0 e 
        in magazzino ci sono pezzi disponibili.
        in quest'ottica il rifornimento delle quantità del magazzino potrebbe avvenire 
        in un ulteriore classe che si occupa di gestire i pezzi nel magazzino
        
        private bool RequestNewAvailableQuantity()
        {
        
        }
    */

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