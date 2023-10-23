using System.Diagnostics;
using LaboratoryLibrary.Classes;
public class User
{
    public static int Main()
    {


        Console.WriteLine("Welcome To Laboratory");
        Console.WriteLine("Press any key to login");
        Console.WriteLine("1. Exit");
        if (Console.ReadLine() == "1") return 1;

        do
        {
            Console.WriteLine("Enter a username: ");
            string username = Console.ReadLine().Trim();
            Console.WriteLine("Enter a password: ");
            string password = Console.ReadLine().Trim();

            IAuthenticator authenticator = new AutenticationManager();
            UserAuthenticationResult result = authenticator.Autenticate(username, password);

            switch (result)
            {
                case UserAuthenticationResult.Admin:
                    StartConsoleAppAdmin();
                    break;
                case UserAuthenticationResult.User:
                    UserInterface userInterface = new();
                    userInterface.User();
                    break;
                case UserAuthenticationResult.InvalidCredentials:
                    Console.WriteLine("Invalid credentials. Please try again");
                    break;

            }
        } while (true);
    }
    static void StartConsoleAppAdmin()
    {
        Process.Start(@"C:\Users\Huawei\OneDrive\Desktop\esercizi\Martina\AnalysisLaboratory\AdminApp\bin\Debug\net7.0\AdminApp.exe");
    }

}
