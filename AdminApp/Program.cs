using System;
using LaboratoryLibrary.Classes;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Ciao");
    }

    public void Inizialization()
    {
        Reagent reagent1 = new("reagente1");
        Reagent reagent2 = new("reagente2");
        Reagent reagent3 = new("reagente3");
        Reagent reagent4 = new("reagente4");
        Reagent reagent5 = new("reagente5");
        Reagent reagent6 = new("reagente6");
        Reagent reagent7 = new("reagente7");
        Reagent reagent8 = new("reagente8");
        Reagent reagent9 = new("reagente9");

        Analysis analysis1 = new("analisi_1");
        analysis1.AddReagent(reagent9);
        analysis1.AddReagent(reagent7);
        analysis1.AddReagent(reagent6);

        Analysis analysis2 = new("analisi_2");
        analysis2.AddReagent(reagent5);
        analysis2.AddReagent(reagent1);

        Analysis analysis3 = new("analisi_3");
        analysis3.AddReagent(reagent6);
        analysis3.AddReagent(reagent5);
        analysis3.AddReagent(reagent2);

        Analysis analysis4 = new("analisi_4");
        analysis4.AddReagent(reagent3);
        analysis4.AddReagent(reagent4);
        analysis4.AddReagent(reagent8);
    }
}
