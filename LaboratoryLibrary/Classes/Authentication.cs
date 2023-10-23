public interface IAuthenticator
{
    UserAuthenticationResult Autenticate (string username, string password);
}

public enum UserAuthenticationResult
{
    Admin,
    User,
    InvalidCredentials,
    Exit,
}

public class AutenticationManager : IAuthenticator
{
    public UserAuthenticationResult Autenticate (string username, string password)
    {
        if(username == "admin" && password=="adminpassword")
        {
            return UserAuthenticationResult.Admin;
        }
        else if (username=="user" && password =="userpassword")
        {
            return UserAuthenticationResult.User;
        }
        else{
            return UserAuthenticationResult.InvalidCredentials;
        }
    }
}