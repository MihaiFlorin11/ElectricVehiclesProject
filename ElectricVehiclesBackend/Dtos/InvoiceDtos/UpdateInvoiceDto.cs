namespace Dtos.InvoiceDtos
{
    public class UpdateInvoiceDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }
    }
}
