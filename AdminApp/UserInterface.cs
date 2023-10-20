using LaboratoryLibrary.Classes;
// si deve fare la reference per provarlo.
public class UserInterface
{
    public static void User()
    {
        Console.WriteLine("Hello User");
        Console.WriteLine("1. Book an analysis");
        Console.WriteLine("2. View the history of reservation");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                {
                    ReservationAnalysis();
                    break;
                }
            case "2":
                {
                    GetHistoryReservation();
                    break;
                }
        }


    }
}