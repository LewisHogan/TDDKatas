namespace PasswordValidator;
public class PasswordValidator
{

    public static PasswordState GetPasswordState(string password)
    {
        if (password == string.Empty) return new PasswordState(false, "Passwords may not be empty.");

        var reasonsForRejection = new List<string>();
        if (password.Length < 8)
        {
            reasonsForRejection.Add("Password must be at least 8 characters.");
        }

        if (password.Where(c => char.IsDigit(c)).Count() < 2)
        {
            reasonsForRejection.Add("Password must contain at least 2 numbers.");
        }

        if (password.All(c => !char.IsUpper(c)))
        {
            reasonsForRejection.Add("Password must contain a capital character.");
        }

        if (password.All(c => char.IsLetterOrDigit(c)))
        {
            reasonsForRejection.Add("Password must contain a special character.");
        }
        
        return reasonsForRejection.Any() ? new PasswordState(false, string.Join('\n', reasonsForRejection)) : new PasswordState(true, "");
    }
}
