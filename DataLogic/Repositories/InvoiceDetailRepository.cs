using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Repositories
{
    public class InvoiceDetailRepository : Repository<InvoiceDetail>
    {
        public InvoiceDetailRepository(AppDbContext _db) : base(_db) { }


        public InvoiceDetail MapInvoice(InvoiceDetail invoiceDetail, string invoiceID,float price)
        {
            try
            {
                var product = db.Products.Where(x => x.ID == invoiceDetail.ProductID).FirstOrDefault();
                if(product != null)
                {
                    // populates object 
                    invoiceDetail.InvoiceID = invoiceID;
                    invoiceDetail.SubTotal = product.Price * invoiceDetail.Quantity;
                    invoiceDetail.Total = 
                        (product.HasTaxes) ? (float)(invoiceDetail.SubTotal * 1.18)
                                    : invoiceDetail.SubTotal;

                    return invoiceDetail;
                }
                
                return null;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public float GetSubTotal(InvoiceDetail invoiceDetail)
        {
            try
            {
                var product = db.Products.Where(x => x.ID == invoiceDetail.ProductID).FirstOrDefault();
                if (product is not null)
                {
                    return product.Price * invoiceDetail.Quantity;
                }
            }
            catch (Exception)
            {

            }
                return 0;
        }

        public float GetTotal(InvoiceDetail invoiceDetail)
        {
            try
            {
                var product = db.Products.Where(x => x.ID == invoiceDetail.ProductID).FirstOrDefault();
                if (product != null)
                {
                    // populates object 
                    var subTotal = product.Price * invoiceDetail.Quantity;
                    var total =
                        (product.HasTaxes) ? (float)(subTotal * 1.18)
                                    : subTotal;

                    return total;
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
                return 0;
        }
        public float GetItbisFromInvoice(InvoiceDetail invoiceDetail)
        {
            try
            {
                if(invoiceDetail.Product != null)
                {
                    return (float)(invoiceDetail.Product.Price * 0.18);
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
