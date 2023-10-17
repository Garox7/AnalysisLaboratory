namespace LaboratoryLibrary.Classes;


public class Reagent
{
    public string Name {get;}
    public int QuantityAvaiable {get;}
    public int QuantityInStock {get;}

    public Reagent(string reagents, int quantityAvaiable, int quantityInStock)
    {
        Name = reagents;
        QuantityAvaiable = quantityAvaiable;
        QuantityInStock = quantityInStock;
    }


}