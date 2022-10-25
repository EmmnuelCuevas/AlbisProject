using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BaseModel
    {
        public BaseModel() { ID = Guid.NewGuid().ToString(); CreatedOn = DateTime.Now; }  
        public string ID { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
