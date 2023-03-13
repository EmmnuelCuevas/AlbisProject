using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Address1 { get; set; }

        public bool IsGob { get; set; }
        public string? Rnc { get; set; }

        public string? PhoneNumber { get; set; }
        public virtual ICollection<Debt> Debts { get; set; }

    }
}
