using System.Diagnostics;

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
}

/*
TODO:
1. Sitemare Login
2. Sistemare prenotazioni User
3. Serializzare magazzino
4. Check generico
5. Controllo nome variabili (soprattutto private!!!!!)
6. qualche test? chene dici 
*/