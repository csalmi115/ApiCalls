using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotApiCalls
{
    public class Product
    {
        public int Id { get; set; }
        public string productCode_code {get; set; }
        public string ProductName { get; set; }

        public string Date { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
