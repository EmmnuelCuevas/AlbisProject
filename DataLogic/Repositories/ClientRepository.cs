using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Repositories
{
    public class ClientRepository : Repository<Client>
    {
        public ClientRepository(AppDbContext _db) : base(_db)
        {
        }
    }
}
