namespace DataLayer.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public bool HasTaxes { get; set; }
        public int AvailableQuantity { get; set; }
    }
}