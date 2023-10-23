using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace LaboratoryLibrary.Classes;
public class Reservation
{
    public Analysis Analysis {get;}

    public Reservation(Analysis analysis){
        Analysis = analysis;
    }
}

public class ReservationHistory{
    public List<Reservation> Reservations { get;} = new List<Reservation>();

    public void AddReservation (Reservation reservation)
    {
        Reservations.Add(reservation);
    }
}



    


