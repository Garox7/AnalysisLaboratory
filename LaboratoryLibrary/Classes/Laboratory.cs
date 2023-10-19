using Newtonsoft.Json;

namespace LaboratoryLibrary.Classes;

public class Laboratory
{
    public static List<Analysis> Analysis = new();

    [JsonProperty]
    public static List<Reagent> Reagents = new();

    public Laboratory() {
    }

    public void LoadAnalysesFromFile(string filePath)
    {
        // Implementa il caricamento delle analisi dal file ANALISI.DAT
        // Aggiungi analisi e reagenti alla lista analyses e reagents
    }

    public void LoadReagentsFromFile(string filePath)
    {
        // Implementa il caricamento dei reagenti dal file MAGAZZINO.DAT
        // Aggiorna le quantità disponibili dei reagenti esistenti e aggiungi nuovi reagenti se necessario
    }

    // public static bool checkIfReagentIsAvaiable(string reagentName)
    // {
    //     if (Reagents.Any(reagent => reagent.Name == reagentName))
    //     {
    //         return true;
    //     } 
    //     return false;
    // }

    public void getListAnalysisAndReagents()
    {
        // Ottengo la lista delle analisi e dei loro reagenti richiesti.
        // oppure stampo la lisa delle analisi e dei reagenti separatamente?
    }

    public void AnalysisPrenotation() 
    {
        // Tale funzione deve controllare la disponibilità dei reagenti richiesti per effettuare
        // l'esame e aggiornare l'elenco. Nel caso dei reagenti non disponibili informa l'utente e non permette la prenotazione
        
    }

    // confronto reagenti analisi con reagenti in magazzino 

    // public Reagent GetReagentWithMostAvailability()
    // {
    //     // Restituisci il reagente con la maggiore disponibilità
    // }
}
