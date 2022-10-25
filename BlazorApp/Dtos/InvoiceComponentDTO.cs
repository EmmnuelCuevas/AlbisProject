using DataLayer.Models;
using DataLogic.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Dtos
{
    public class InvoiceComponentDTO
    {
        public InvoiceComponentDTO()
        {
            Invoice = new Invoice();
            Details = new List<InvoiceDetail>();
            Clients = new List<Client>();
        }
        public List<InvoiceDetail> Details { get; set; }
        public Invoice Invoice { get; set; }
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }
        public string ClientID { get; set; }
        public string ProjectID { get; set; }


        public void CreateInvoice(string clientID, string projectID, bool credit = false)
        {
            var subtotal = Details.Sum(x => x.SubTotal);
            var total = Details.Sum(x => x.Total);
            this.Invoice.ProjectID = projectID;
            this.Invoice.ClientID = clientID;
            this.Invoice.SubTotal = subtotal;
            this.Invoice.Total = total;
            this.Invoice.Taxes = total - subtotal;
            this.Invoice.IsCredit = credit;
            //change
            this.Invoice.InvoiceNumber = "test";
        }

        public void EditInvoice(Invoice invoice)
        {
            var subtotal = Details.Sum(x => x.SubTotal);
            var total = Details.Sum(x => x.Total);
            var taxes = Details.Where(x => x.Product.HasTaxes).Sum(x => x.Product.Price * 1.18 * x.Quantity);
            this.Invoice.SubTotal = subtotal;
            this.Invoice.Total = total;
            this.Invoice.Taxes = (float)taxes;
            //change
            this.Invoice.InvoiceNumber = "test";
        }
    }
}