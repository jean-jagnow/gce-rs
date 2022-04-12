using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCE.Application.Common
{
    public class EntityNotFoundException:Exception
    {
        public EntityNotFoundException(string message = "O registro não existe ou foi excluído."):base(message)
        {
        }
    }
}
