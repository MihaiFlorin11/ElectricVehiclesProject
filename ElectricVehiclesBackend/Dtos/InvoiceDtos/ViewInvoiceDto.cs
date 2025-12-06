namespace Dtos.InvoiceDtos
{
    public class ViewInvoiceDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }
    }
}
