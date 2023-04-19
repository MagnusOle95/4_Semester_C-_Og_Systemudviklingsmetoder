using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using validationexamples.Infrastructure;


namespace validationexamples.Models
{
    //using a model validation here for the entire model, not just on attributes
    //[PersonValid(ErrorMessage="Can't use fake names!")]
    public class Person
    {

        //[Display(Name = "Enter Name")]
        [Required(ErrorMessage = "You forgot to enter your name")]
        [StringLength(120,MinimumLength=2,ErrorMessage="Name must be at least 2 characters")]
        public string Name { get; set; }

        [Display(Name = "Enter Age")]
        [Range(typeof(int), "1", "120", ErrorMessage = "Value for age must be between {1} and {2}")]
        [Required(ErrorMessage = "You forgot to enter your age")]
        //notice the vaidation attribute below - this is a custom one
        [AgeCheck(ErrorMessage="not old enough for this site")]
        public int Age { get; set; }

        [Display(Name = "Enter Birtday")]
        [Required(ErrorMessage = "You forgot to enter your birth day")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; } 
    }
}