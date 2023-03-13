using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Invoice : BaseModel
    {
        [ForeignKey("Client")]
        public string ClientID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNumber { get; set; }
        public string NCF { get; set; }
        public bool IsCredit { get; set; }
        public float SubTotal { get; set; }
        public float? Discount { get; set; }
        public float Taxes { get; set; }
        public float Total { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual Client Client { get; set; }

    }
}