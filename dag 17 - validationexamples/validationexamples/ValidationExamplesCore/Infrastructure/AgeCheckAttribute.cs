using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;



namespace validationexamples.Infrastructure
{
    //This is a custom age check attribute - could be achieved
    //with the range attribute, but just to show the use of it 
    public class AgeCheckAttribute : ValidationAttribute
    {       

    //we convert the input to a string and then convert it
     //to an integer to check the age
       public override bool IsValid(object value) {
           string val = Convert.ToString(value);
           int x = Int32.Parse(val);
           if (x<18)
               return false;
           else
              return true;    
        }
    }
}