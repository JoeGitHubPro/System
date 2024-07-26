using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.DAL.Data;
using System.DAL.DTOs;
using System.DAL.Models;

namespace System.BAL.Services
{
    public class InvoiceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetAllInvoicesAsync()
        {
            var invoices = await _context.Invoices
                .Include(i => i.Products)
                .ToListAsync();
            return _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
        }

        public async Task<InvoiceDTO> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Products)
                .FirstOrDefaultAsync(i => i.InvoiceId == id);
            return _mapper.Map<InvoiceDTO>(invoice);
        }

        public async Task<InvoiceDTO> AddInvoiceAsync(InvoiceDTO invoiceDTO)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return _mapper.Map<InvoiceDTO>(invoice);
        }

        public async Task UpdateInvoiceAsync(InvoiceDTO invoiceDTO)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}

