using System.ComponentModel.DataAnnotations;

namespace Dag9_Dag11_WebApplication.Models
{
    public class ModelMage
    {
        [Required(ErrorMessage = "ID skal Udfyldes")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Navn skal udfyldes")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Der skal indikeres om, personen er dark eller god - (True - False) <br> (Default bliver Sat til god hvis det ikke skrive rigtigt)")]
        public bool IsDark{get; set;}

    }

}
