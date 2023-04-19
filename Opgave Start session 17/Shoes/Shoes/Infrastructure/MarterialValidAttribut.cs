using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Shoes.Infrastructure
{
    public class MarterialValidAttribut : ValidationAttribute
    {
        //constructor
        public MarterialValidAttribut()
        {
            //override error message
            ErrorMessage = "Marteriale er ikke en ting";
        }
        public override bool IsValid(object value)
        {
            string marteriale = value as string;
           
            if (marteriale == "Læder")
            {
                Debug.Write("model is valid");
                return true;

            }
            else
            {
                Debug.Write("model is not valid");
                return false;
            }
        }

    }
}

