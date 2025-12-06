namespace Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public bool Paid { get; set; }

        public Rental Rental { get; set; }
    }
}
