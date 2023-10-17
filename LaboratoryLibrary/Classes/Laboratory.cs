namespace LaboratoryLibrary.Classes;

public class Laboratory
{
    public Dictionary<string, Analysis> Analysis {get; set;}
    public List<Reagent> Reagents {get; set;}

    public Laboratory() {}

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

    public Reagent GetReagentWithMostAvailability()
    {
        // Restituisci il reagente con la maggiore disponibilità
    }
}
