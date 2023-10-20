using LaboratoryLibrary.Classes;

public class AdminInterface
{
    private Laboratory Laboratory;
    private JsonFileManager JsonFile;

    public AdminInterface() {
        Laboratory = new Laboratory();
        JsonFile = new JsonFileManager(Laboratory);
    }
    
    public void Admin()
    {
        JsonFile.ReadReagentJsonFile();
        JsonFile.ReadAnalysesJsonFile();

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
        try
        {
            var result = Laboratory.GetAnalysesAndReagent();

            Console.WriteLine("\n======== ANALYSES LIST ========");
            foreach (var analysis in result.analysesList)
            { 
                Console.WriteLine(analysis.ToString());
            }

            Console.WriteLine("\n======== REAGENT LIST ========");
            foreach (var reagent in result.reagentsList)
            {
                Console.WriteLine(reagent.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

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