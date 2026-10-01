public class AuthService
{
   
    public bool CheckLoginCredentials(string username, string password)
    {
    // dit is een neppe gebruiker, zodat ik al de aan de logica kan beginnen. Voor dit test stukje. 
        if (username == "Appelflap" && password == "Dikkelul123")
        {
            return true;
        }
        return false;
    }
}

