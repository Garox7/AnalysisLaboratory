using System;
using Newtonsoft.Json;
using LaboratoryLibrary.Classes;
using System.Diagnostics;
using System.Transactions;

class Program
{
    static void Main()
    {
        // Laboratory lab = new();
        // JsonFileManager jsonFile = new(lab);

        AdminInterface adminInterface = new();
        adminInterface.Admin();

        Console.WriteLine("Welcome To Laboratory");
        Console.WriteLine("Enter a username: ");
        string username = Console.ReadLine().Trim();
        Console.WriteLine("Enter a password: ");
        string password = Console.ReadLine().Trim();

        IAuthenticator authenticator = new AutenticationManager();
        UserAuthenticationResult result = authenticator.Autenticate(username, password);

        switch (result)
        {
            case UserAuthenticationResult.Admin:
                adminInterface.Admin();
                break;
            case UserAuthenticationResult.User:
                StartConsoleAppUser();
                break;
            case UserAuthenticationResult.InvalidCredentials:
                Console.WriteLine("Invalid credentials. Please try again");
                break;
        }
    }
    static void StartConsoleAppUser()
    {
        Process.Start(@"C:\Users\Huawei\OneDrive\Desktop\esercizi\Martina\AnalysisLaboratory\UserApp\bin\Debug\net7.0\UserApp.exe");
    }

    // public void Inizialization()
    // {
    //     // REAGENTS
    //     Reagent reagent1 = new("reagente1");
    //     Reagent reagent2 = new("reagente2");
    //     Reagent reagent3 = new("reagente3");
    //     Reagent reagent4 = new("reagente4");
    //     Reagent reagent5 = new("reagente5");
    //     Reagent reagent6 = new("reagente6");
    //     Reagent reagent7 = new("reagente7");
    //     Reagent reagent8 = new("reagente8");
    //     Reagent reagent9 = new("reagente9");

    //     Laboratory.Reagents.Add(reagent1);
    //     Laboratory.Reagents.Add(reagent2);
    //     Laboratory.Reagents.Add(reagent3);
    //     Laboratory.Reagents.Add(reagent4);
    //     Laboratory.Reagents.Add(reagent5);
    //     Laboratory.Reagents.Add(reagent6);
    //     Laboratory.Reagents.Add(reagent7);
    //     Laboratory.Reagents.Add(reagent8);
    //     Laboratory.Reagents.Add(reagent9);

    //     // ANALYSIS
    //     var array1 = new List<string>{"reagente9", "reagente7", "reagente6"};
    //     var array2 = new List<string>{"reagente4", "reagente7", "reagente6"};
    //     var array3 = new List<string>{"reagente3", "reagente2", "reagente1"};
    //     var array4 = new List<string>{"reagente9", "reagente8", "reagente5"};
    //     Analysis analysis1 = new("analisi_1", array1) ;
    //     Analysis analysis2 = new("analisi_2", array2);
    //     Analysis analysis3 = new("analisi_3", array3);
    //     Analysis analysis4 = new("analisi_4", array4);

    //     Laboratory.Analysis.Add(analysis1);
    //     Laboratory.Analysis.Add(analysis2);
    //     Laboratory.Analysis.Add(analysis3);
    //     Laboratory.Analysis.Add(analysis4);

    //     // WRITE FILE
    //     JsonFileManager jsonFile = new();

    //     string filePathAnalysis = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Analysis.JSON";
    //     string filePathReagents = "/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/LaboratoryLibrary/Data/Reagent.JSON";
    //     jsonFile.WriteJsonFile(filePathAnalysis, Laboratory.Analysis, JsonConvert.SerializeObject);
    //     jsonFile.WriteJsonFile(filePathReagents, Laboratory.Reagents, JsonConvert.SerializeObject);
    // }
}

/*
TODO:
1. Classe prenotazione, V
2. Creare Dictonary,
3. Provare a serializzare e deserializzare i dati,
4. Effettuare prenotazione sia lato Admin che User,
5. Lato Admin ottenere per ogni Analisi gli utenti prenotati,
6. Lato User ottenere per lo User corrente lo storico degli esami effettuati.
7. 
*/