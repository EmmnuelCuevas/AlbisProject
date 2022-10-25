using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PersonInCharge { get; set; }
        public string PersonInChargePhoneNumber { get; set; }

        [ForeignKey("Client")]
        public string ClientID { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Client Client { get; set; }
    }
}