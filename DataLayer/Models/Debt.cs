
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Debt : BaseModel
    {
        [ForeignKey("Client")]
        public string ClientID { get; set; }
        public string InvoceID { get; set; }

        public virtual Client Client { get; set; }  
    }
}
