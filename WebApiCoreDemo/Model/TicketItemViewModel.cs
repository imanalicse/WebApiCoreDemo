using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCoreDemo.Model
{
    public class TicketItemViewModel
    {
        public string Concert { get; set; }
        public string Artist { get; set; }
        public int postCode { get; set; }
        public bool Available { get; set; }
    }
}
