using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DataAccessCore.Model
{
    [Table("Magespell")]
    public class Magespell
    {
        public int MageId { get; set; }
        public Mage Mage { get; set; } //Navigation proberty. 
        public int SpellId { get; set; }
        public Spell Spell { get; set; }
    }

}
