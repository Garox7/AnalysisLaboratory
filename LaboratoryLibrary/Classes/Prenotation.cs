using LaboratoryLibrary.Classes;

public class Prenotation {
    private User _username;
    private Analysis _analyses;
    private bool _confirmed;

    public Prenotation (User user, Analysis analysis)
    {
        _username = user;
        _analyses = analysis;
        _confirmed = false;
    }
}