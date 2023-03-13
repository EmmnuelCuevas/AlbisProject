using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Repositories
{
    public class NcfRepository : Repository<NCF>
    {
        public NcfRepository(AppDbContext _db) : base(_db)
        {
        }
    }
}
