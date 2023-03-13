using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Repositories
{
    public class InvoiceRepository : Repository<Invoice>
    {
        public InvoiceRepository(AppDbContext _db) : base(_db) { }

        public Invoice FillInvoice(Invoice invoice,List<InvoiceDetail> details)
        {
            
            invoice.SubTotal = details.Sum(x=>x.SubTotal);
            invoice.Total = details.Sum(x=>x.Total);
            invoice.Taxes = invoice.Total - invoice.SubTotal;
            return invoice;
        }
        public Invoice FillInvoice(Invoice invoice, List<InvoiceDetail> details , string clientID , string projectID)
        {
            invoice.SubTotal = details.Sum(x => x.SubTotal);
            invoice.Total = details.Sum(x => x.Total);
            invoice.Taxes = invoice.Total - invoice.SubTotal;
            invoice.ClientID = clientID;
            return invoice;
        }

    }
}
