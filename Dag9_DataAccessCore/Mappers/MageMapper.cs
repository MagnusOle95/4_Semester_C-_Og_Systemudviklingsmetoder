using Dag9_DataAccessCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DataAccessCore.Mappers
{
    internal class MageMapper
    {
        public static Dag9_DTOCore.Model.Mage MapMage(Mage mage)
        {
            return new Dag9_DTOCore.Model.Mage (mage.MageId,mage.Name,mage.IsDark);

        }
        
    }
}
