namespace Dtos.InvoiceDtos
{
    public class CreateInvoiceDto
    {
        public decimal TotalPrice { get; set; }

        public bool Paid { get; set; }
    }
}
