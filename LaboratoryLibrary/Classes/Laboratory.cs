using LaboratoryLibrary.Exceptions;

namespace LaboratoryLibrary.Classes;

public class Laboratory
{
    public List<Analysis>? Analysis { get; private set; }
    private List<Reagent>? _reagents;
    public Dictionary<string, List<Prenotation>>? _prenotations { get; private set; } = new Dictionary<string, List<Prenotation>>();

    public void SetAnalyses(in List<Analysis> analyses)
    {
        Analysis = analyses;
    }

    public void SetReagents(in List<Reagent> reagents)
    {
        _reagents = reagents;
    }

    public void SetPrenotations(in Dictionary<string, List<Prenotation>> prenotations)
    {
        _prenotations = prenotations;
    }

    public (List<Analysis>? analysesList, List<Reagent>? reagentsList) GetAnalysesAndReagent()
    {
        return (Analysis, _reagents);
    }

    /* Effettua la prenotazione sia lato Admin che Lato User:
    ** Torna vero se a sua volta i reagenti richiesti per effettuare l'analisi disponibili
    ** tramite "DecreaseReagentsQuantityForAnalysis".
    */
    public bool CreatePrenotation(string username, in Analysis analysis)
    {
        if (!_prenotations.ContainsKey(username))
        {
            _prenotations[username] = new List<Prenotation>();
        }

        if (DecreaseReagentsQuantityForAnalysis(analysis))
        {
            var prenotation = new Prenotation(analysis);
            _prenotations[username].Add(prenotation);
            return true;
        }
        else throw new ReagentUnavailableException("The required reagents are not available for analysis.");
    }

    // questo metodo si occupa di decrementare all'interno del magazzino 
    // le quantità dei reagenti richiesti di un determinato tipo di analisi
    // ritorna vero se a sua volta il metodo DecreaseAvailableQuantity trova pezzi disponibili
    // o per quel determinato reagente.
    private bool DecreaseReagentsQuantityForAnalysis(Analysis analysis)
    {
        List<string> requiredReagents = analysis.GetRequiredReagent();

        foreach (var requiredReagent in requiredReagents)
        {
            foreach (var reagent in _reagents.FindAll(r => r.Name == requiredReagent))
            {
                if (!reagent.DecreaseAvailableQuantity()) throw new ReagentUnavailableException("Insufficient quantity available");
                else return true;
            }
        }
        return true;
    }

    public List<Prenotation> GetUserHistory(string user)
    {
        if (_prenotations.ContainsKey(user))
        {
            return _prenotations[user];
        }
        else throw new PrenotationUnavailableException($"there is no reservation for the name {user}\n");
    }

    public List<Reagent> GetReagentWithMostAvailability()
    {

        var reagents = this._reagents.OrderByDescending(reagent => reagent.QuantityAvailable).ToList();
        return reagents;
    }
}
