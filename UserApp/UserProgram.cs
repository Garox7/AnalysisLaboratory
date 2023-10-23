using LaboratoryLibrary.Classes;
public class UserInterface
//si deve provare con il codice completo altrimenti non posso vedere se funziona
{
    private ReservationHistory reservationHistory = new ReservationHistory();
    public static void Main()
    {
        UserInterface userInterface = new();
        Console.WriteLine("Hello User");
        Console.WriteLine("1. Book an analysis");
        Console.WriteLine("2. View the history of reservation");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                {
                   // bool isRunning = true;
                    while (true)
                    {
                        Console.WriteLine("Select an analysis to book or select 0 to exit:");
                        Console.WriteLine("0. Exit");
                        Console.WriteLine("1. Analysis 1");
                        Console.WriteLine("2. Analysis 2");
                        Console.WriteLine("3. Analysis 3");
                        Console.WriteLine("4. Analysis 4");
                        string analysischoice = Console.ReadLine();

                        if (analysischoice == "0")
                        {
                            //isRunning = false;
                            break;
                        }
                        else
                        {
                            Analysis selectedAnalysis = userInterface.GetAnalysis(analysischoice);
                            if (analysischoice != null)
                            {
                                if (userInterface.CheckReagentAvaiability(selectedAnalysis))
                                {
                                    Reservation reservation = new Reservation(selectedAnalysis);
                                    // ReservationHistory reservationHistory = new ReservationHistory();
                                    userInterface.reservationHistory.AddReservation(reservation);
                                    Console.WriteLine("Analysis booked successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, is not possible to book the analysis");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid analysis choice");
                            }

                        }
                    }
                    break;
                }
            case "2":
                {
                    userInterface.ViewReservationHistory();
                    break;
                }
        }


    }

    private Analysis GetAnalysis(string choice)
    {
        return Laboratory.Analysis.FirstOrDefault(a => a.Name == $"Anlysis {choice}");
    }

    private bool CheckReagentAvaiability(Analysis analysis)
    {
        foreach (string reagentName in analysis.RequiredReagents)
        {
            Reagent reagent = Laboratory.Reagents.FirstOrDefault(r => r.Name == reagentName);
            if (reagent == null || reagent.QuantityInStock == 0)
            {
                return false; //reagent not avaiable
            }
        }
        return true; //Alla reagent are avaiable
    }

    public void ViewReservationHistory()
    {
        foreach (var reservation in reservationHistory.Reservations)
        {
            Console.WriteLine(reservation);
        }
    }
}