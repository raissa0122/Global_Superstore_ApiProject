namespace Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int SalesCount { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Profit { get; set; }
        public int ShippingCost {  get; set; }
        public string OrderPriority { get; set; }

        Customer Customer { get; set; }

        Product Product { get; set; }
    }
}
