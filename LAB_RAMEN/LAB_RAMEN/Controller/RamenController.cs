
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_RAMEN.Controller
{
    public class RamenController
    {
        public static bool ValidateName(string name)
        {
            return name.Contains("Ramen");
        }

        public static bool ValidateMeat(string meat)
        {
            return !string.IsNullOrEmpty(meat);
        }

        public static bool ValidateBroth(string broth)
        {
            return !string.IsNullOrEmpty(broth);
        }

        public static bool ValidatePrice(decimal price)
        {
            return price >= 3000;
        }

    
    }
}