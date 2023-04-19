using Shoes.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Shoes.Models

{
    public class Shoe
    {
        [Display(Name = "Skriv størrelse")]
        [Range(typeof(int), "1", "120", ErrorMessage = "Værdien for størrelse skal være mellem {1} and {2}")]
        [Required(ErrorMessage = "Du skal udfylde størrelse for at fortsætte")]
        //notice the vaidation attribute below - this is a custom one
        public int Size { get; set; }

     
        [Display(Name = "Skriv marteriale")]
        [Required(ErrorMessage = "Du har glemt at skrive marteriale")]
        [StringLength(120, MinimumLength = 0, ErrorMessage = "Marteriale teksten må ikke være tom")]
        [MarterialValidAttribut(ErrorMessage = "Marteriale er ikke læder")]
        public string Material { get; set; }


        [Display(Name = "Skriv produktions dato")]
        [Required(ErrorMessage = "Du skal udfylde produktions dato")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

    }
}
