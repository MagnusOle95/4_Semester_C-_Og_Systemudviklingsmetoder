using Dag9_DataAccessCore.Repositories;
using Dag9_DTOCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_BusinessLogicCore.BLL
{
    public class MageBll
    {
        public Mage GetMage(int id)
        {
            return MageRepositories.getMage(id);
        }

    }
}
