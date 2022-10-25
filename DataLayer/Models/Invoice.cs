using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Invoice : BaseModel
    {
        [ForeignKey("Client")]
        public string ClientID { get; set; }
        [ForeignKey("Project")]
        public string ProjectID { get; set; }

        public string InvoiceNumber { get; set; }
        public bool IsCredit { get; set; }
        public float SubTotal { get; set; }
        public float? Discount { get; set; }
        public float Taxes { get; set; }
        public float Total { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual Client Client { get; set; }
        public virtual Project Project { get; set; }

    }
}