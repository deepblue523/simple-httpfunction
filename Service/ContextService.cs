using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp.Service
{
    public class ContextService
    {
        public string CorrelationId
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
    }
}
