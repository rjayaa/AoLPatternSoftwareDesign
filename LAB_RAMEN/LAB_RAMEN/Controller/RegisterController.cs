using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_RAMEN.Controller
{
    public class RegisterController
    {
        public static bool ValidateUsername(string username)
        {

            if (username.Length < 5 || username.Length > 15)
            {
                return false;
            }

            foreach (char c in username)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateEmail(string email)
        {
            return email.EndsWith(".com", StringComparison.OrdinalIgnoreCase);
        }

        public static bool ValidateGender(string gender)
        {
            return !string.IsNullOrEmpty(gender);
        }

        public static bool ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)) return false;
            return password == confirmPassword;
        }

        public static bool ValidateConfirmPassword(string confirmPassword, string password)
        {
            if (string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(password)) return false;
            return confirmPassword == password;
        }

    }
}