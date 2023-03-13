using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class NCF : BaseModel
    {
        public string GobNCF { get; set; }
        public string NormalNCF { get; set; }
        public int ActualNCF { get; set; }
        public int StartNCF { get; set; }
        public int EndNCF { get; set; }

        public int ActualGobNCF { get; set; }
        public int StartGobNCF { get; set; }
        public int EndGobNCF { get; set; }
        public bool IsActive { get; set; }
    }
}
