using System.ComponentModel;
using System.Xml.Serialization;

namespace LaboratoryLibrary.Classes;
public class Reservation
{
    public string? UserName { get; set; } // forse è meglio mettere un id?
    public List<string> BookedAnalysis { get; } = new List<string>();

    public Reservation(string username)
    {
        this.UserName = username;
    }
}

public class HistoryCostumer
{
    private List<Reservation> HistoryReservation = new List<Reservation>();


    public void ReservationAnalysis(string username)
    {
        Reservation reservation = new Reservation(username);
        bool ContinueReservation = true;
        while (ContinueReservation)
        {
            Console.WriteLine("Please, choose the analysis to book or press 0 to exit: ");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. Analysis1");
            Console.WriteLine("2. Analysis2");
            Console.WriteLine("3. Analysis3");
            Console.WriteLine("4. Analysis3");
            string choice = Console.ReadLine();
            if (choice == "0")
            {
                ContinueReservation = false;
            }
            else
            {
                // si deve il metodo per il confronto per la presenza delle quantità dei reagneti 
                // si deve mettere il metodo per scalare il numero delle quantità
                reservation.BookedAnalysis.Add(choice);
            }
        }
        HistoryReservation.Add(reservation);
    }
    public List<Reservation> GetHistoryReservations()
    {
        return HistoryReservation.ToList();
    }
}
