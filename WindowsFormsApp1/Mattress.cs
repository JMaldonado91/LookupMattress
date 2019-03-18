using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class mattress
    {
        public string Mattress { get; set; }
        public string profile { get; set; }
        public string feel { get; set; }
        public string removeable_cover { get; set; }
        public string size_range { get; set; }
        public string weight_range { get; set; }
        public string pricing_range { get; set; }
        public string pricingdisplay => "$" + pricing_range;
        public string year { get; set; }
    }
}
