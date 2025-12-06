namespace Dtos.InvoiceDtos
{
    public class DeleteInvoiceDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }
    }
}
