using LaboratoryLibrary.Classes;
using LaboratoryLibrary.Exceptions;
using Newtonsoft.Json;

public class AdminInterface
{
    private Laboratory Laboratory;
    private JsonFileManager JsonFile;

    public AdminInterface()
    {
        Laboratory = new Laboratory();
        JsonFile = new JsonFileManager(Laboratory);
    }

    public void Admin()
    {
        JsonFile.ReadReagentJsonFile();
        JsonFile.ReadAnalysesJsonFile();
        JsonFile.ReadPrenotationJsonFile();

        Console.WriteLine("Welcome Admin");

        do
        {
            Console.WriteLine("1. Shows analyses and warehouse availability");
            Console.WriteLine("2. Searches for the reagent with greater availability");
            Console.WriteLine("3. Create Prenotation");
            Console.WriteLine("4. Get History of prenotation from username");
            Console.WriteLine("5. Exit");

            string choise = Console.ReadLine().Trim();

            try
            {
                switch (choise)
                {
                    case "1":
                        ShowAnalysesAndWarehouse();
                        break;
                    case "2":
                        SearchForReagentWithGreaterAvailability();
                        break;
                    case "3":
                        CreatePrenotation();
                        break;
                    case "4":
                        GetHistoryFromUser();
                        break;
                    case "5":
                        
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

    private void CreatePrenotation()
    {
        string userIdentifier;
        int selectedAnalysis;

        Console.Write("Please enter a user identifier: ");
        // Effettuare controllo 
        userIdentifier = Console.ReadLine().Trim();

        for (int i = 0; i < Laboratory.Analysis.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. " + Laboratory.Analysis[i].ToString()
            );
        }

        Console.Write("\nInserisci l'analisi da prenotare: ");

        if (int.TryParse(Console.ReadLine(), out selectedAnalysis))
        {

            try
            {
                if (Laboratory.CreatePrenotation(userIdentifier, Laboratory.Analysis[selectedAnalysis - 1]))
                {
                    Console.WriteLine($"\n{Laboratory.Analysis[selectedAnalysis - 1].Name.ToUpper()} Booking made successfully\n");
                    JsonFile.WriteJsonFile(JsonFile.filePathPrenotations, Laboratory._prenotations, JsonConvert.SerializeObject);
                }
                else
                {
                    Console.WriteLine("The reservation was not successful\n");
                }
            }
            catch (ReagentUnavailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid analysis selection. Please enter a valid analysis number.\n");
        }
    }

    private void GetHistoryFromUser()
    {
        string userIdentifier;

        Console.Write("Please enter a user identifier: ");
        userIdentifier = Console.ReadLine().Trim();

        var userHistory = Laboratory.GetUserHistory(userIdentifier);

        foreach (var prenotation in userHistory)
        {
            Console.WriteLine(prenotation.ToString());
        }
    }
}