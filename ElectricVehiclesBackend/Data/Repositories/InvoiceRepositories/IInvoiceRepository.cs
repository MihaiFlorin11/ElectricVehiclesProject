using Entities;

namespace Data.Repositories.InvoiceRepositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetInvoicesAsync();

        Task<Invoice> GetInvoiceByIdAsync(int id);

        Task<Invoice> AddInvoice(Invoice invoice);

        Task<Invoice> UpdateInvoice(Invoice invoice);

        Task<Invoice> DeleteInvoice(int id);

        Task<bool> SaveChangesAsync();
    }
}
