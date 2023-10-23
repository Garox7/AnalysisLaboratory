using System.Diagnostics;

class Program
{
    static int Main()
    {
    
        do
        {    
            Console.WriteLine("Welcome To Laboratory");
            Console.WriteLine("Any key to Login");
            Console.WriteLine("1. Exit");
            if (Console.ReadLine() == "1") return 1;

            Console.Write("Enter a username: ");
            string username = Console.ReadLine().Trim();

            Console.Write("Enter a password: ");
            string password = Console.ReadLine().Trim();

            IAuthenticator authenticator = new AutenticationManager();
            UserAuthenticationResult result = authenticator.Autenticate(username, password);

            try
            {
                switch (result)
                {
                    case UserAuthenticationResult.Admin:
                        AdminInterface adminInterface = new();
                        adminInterface.Admin();
                        break;
                    case UserAuthenticationResult.User:
                        StartConsoleAppUser();
                        break;
                    case UserAuthenticationResult.InvalidCredentials:
                        Console.WriteLine("Invalid credentials. Please try again");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } while (true);
    }
    
    static void StartConsoleAppUser()
    {
        Process.Start("/Users/giuseppegarozzo/Desktop/FMF/AnalysisLaboratory/UserApp/bin/Debug/net7.0/UserApp");
    }
}