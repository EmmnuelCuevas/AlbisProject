using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class InvoiceDetail:BaseModel
    {
        [ForeignKey("Invoice")]
        public string InvoiceID { get; set; }
        [ForeignKey("Product")]
        public string ProductID { get; set; }

        public float Price { get; set; }
        public float Discount { get; set; }
        public int Quantity { get; set;}

        public float SubTotal { get; set; }
        public float Total { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Product Product { get; set; }
    }
}
