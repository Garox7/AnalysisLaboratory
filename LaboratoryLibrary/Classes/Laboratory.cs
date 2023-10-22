namespace LaboratoryLibrary.Classes;

public class Laboratory
{
    public List<Analysis>? Analysis {get; private set;}
    private List<Reagent>? _reagents;
    private Dictionary<string, List<Analysis>> prenotations;

    public void SetAnalyses(List<Analysis> analyses)
    {
        this.Analysis = analyses;
    }

    public void SetReagents(List<Reagent> reagents)
    {
        this._reagents = reagents;
    }

    public (List<Analysis>? analysesList, List<Reagent>? reagentsList) GetAnalysesAndReagent() {
        return (Analysis, _reagents);
    }

    public void AnalysisPrenotation() 
    {
        // Tale funzione deve controllare la disponibilità dei reagenti richiesti per effettuare
        // l'esame e aggiornare l'elenco. Nel caso dei reagenti non disponibili informa l'utente e non permette la prenotazione
    }

    public List<Reagent> GetReagentWithMostAvailability()
    {
        
        var reagents = this._reagents.OrderByDescending(reagent => reagent.QuantityAvaiable).ToList();
        return reagents;
    }
}
