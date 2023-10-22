using LaboratoryLibrary.Classes;

public class Prenotation {
    private string _username;
    private Analysis _analyses;
    public bool confirmed {get; private set;}

    public Prenotation (string username, Analysis analysis)
    {
        _username = username;
        _analyses = analysis;
    }

    public bool ConfimPrenotation()
    {
        if (!confirmed)
        {
            confirmed = true;
            return true;
        }

        return false;

    }

    public override string ToString()
    {
        return "";
    }
}