using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotApiCalls
{
    public class DLLFacade
    {
        public IProductManager GetProduct()
        {
            return new IProductManager();
        }
    }
}
