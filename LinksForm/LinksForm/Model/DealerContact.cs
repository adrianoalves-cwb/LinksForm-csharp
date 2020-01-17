using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Links.Model
{
    class DealerContact
    {
        public int DealerContactId { get; set; }
        public int MainDealerId { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
}
