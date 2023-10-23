using System.Security.Cryptography;
using LaboratoryLibrary.Classes;
using LaboratoryLibrary.Exceptions;

public class UserInterface
{
    private Laboratory Laboratory;
    private JsonFileManager JsonFile;

    public UserInterface()
    {
        Laboratory = new Laboratory();
        JsonFile = new JsonFileManager(Laboratory);
    }
    public void User()
    {
        JsonFile.ReadReagentJsonFile();
        JsonFile.ReadAnalysesJsonFile();
        JsonFile.ReadPrenotationJsonFile();

        Console.WriteLine("Hello User");

        do
        {
            Console.WriteLine("Hello User");
            Console.WriteLine("1. Book analysis");
            Console.WriteLine("2. View the history of reservation");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();
            try
            {


                switch (choice)
                {
                    case "1":
                        {
                            CreatePrenotation();
                            break;
                        }
                    case "2":
                        {
                            GetHistoryFromUser();
                            break;
                        }
                    case "3":
                        {
                            return;
                        }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } while (true);
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
                $"{i + 1}. " + Laboratory.Analysis[i].Name.ToUpper());
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