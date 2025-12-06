using Data.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.InvoiceRepositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DatabaseContext _databaseContext;

        public InvoiceRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            return await _databaseContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _databaseContext.Invoices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            _databaseContext.Invoices.Add(invoice);
            await SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> UpdateInvoice(Invoice invoice)
        {
            _databaseContext.Invoices.Update(invoice);
            await SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> DeleteInvoice(int id)
        {
            var invoice = await GetInvoiceByIdAsync(id);
            _databaseContext.Invoices.Remove(invoice);
            await SaveChangesAsync();
            return invoice;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync() > 0;
        }  
    }
}
