using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using validationexamples.Models;
using System.Diagnostics;


namespace validationexamples.Infrastructure
{
    //This is also a custom validation attribute, but we will
    //apply it at the model level.
    public class PersonValidAttribute : ValidationAttribute
    {
        //constructor
        public PersonValidAttribute()
        {
            //override error message
            ErrorMessage = "Person not valid - please use real names!";
        }
        public override bool IsValid(object value)
        {
            Person p = value as Person; //a "cast" to a person object
            //first check if we actually have a person obect to validate
            if (p == null)
                return true; //not really a person object, so skip this
            if (p.Name.Equals("superman"))
            {
                Debug.Write("model is not valid");
                return false;
            }
            else
            {
                Debug.Write("model is valid");
                return true;
            }
        }
    }
}