using LaboratoryLibrary.Classes;

public class AdminInterface
{
    private Laboratory Laboratory;

    public AdminInterface() {
        Laboratory = new Laboratory();
    }
    
    public void Admin()
    {
        

        do
        {
            Console.WriteLine("Welcome Admin");
            Console.WriteLine("1. Shows analyses and warehouse availability");
            Console.WriteLine("2. Book an Analysis");
            Console.WriteLine("3. Searches for the reagent with greater availability");
            Console.WriteLine("4. Exit");

            string choise = Console.ReadLine().Trim();

            try
            {
                switch (choise)
                {
                    case "1":
                        ShowAnalysesAndWarehouse();
                        break;
                    case "2":
                        BookAnalyses();
                        break;
                    case "3":
                        SearchForReagentWithGreaterAvailability();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choise");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }


        } while (true);
    }

    private void ShowAnalysesAndWarehouse()
    {
        Console.WriteLine("Hi Admin");
    }

    private void BookAnalyses()
    {
        Console.WriteLine("Book Analyses");
    }

    private void SearchForReagentWithGreaterAvailability()
    {
        try 
        {
            var reagents = Laboratory.GetReagentWithMostAvailability();
            
            foreach (var reagent in reagents)
            {
                Console.WriteLine(reagent.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}