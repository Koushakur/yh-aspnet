using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;
public class PasswordSecurity {

    public static (string, string) GenerateHashAndKey(string password) {
        try {
            using var hmac = new HMACSHA512();
            var secKey = Convert.ToBase64String(hmac.Key);
            var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return (hash, secKey);

        } catch (Exception e) { Debug.WriteLine(e); }

        return (null, null)!;
    }

    public static bool ValidatePassword(string password, string hashedPassword, string securityKey) {
        try {
            using var hmac = new HMACSHA512(Convert.FromBase64String(securityKey));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return hash.SequenceEqual(Convert.FromBase64String(hashedPassword));

        } catch (Exception e) { Debug.WriteLine(e); }

        return false;
    }
}
