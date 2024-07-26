using Microsoft.EntityFrameworkCore;
using System.DAL.Data;
using System.DAL.Models;

namespace System.BAL.Services
{
    public class AdditionService
    {
        private readonly AppDbContext _context;

        public AdditionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Addition>> GetAllAdditionsAsync()
        {
            return await _context.Additions.ToListAsync();
        }

        public async Task<Addition> GetAdditionByIdAsync(int id)
        {
            return await _context.Additions.FirstOrDefaultAsync(a => a.AdditionId == id);
        }

        public async Task<Addition> AddAdditionAsync(Addition addition)
        {
            _context.Additions.Add(addition);
            await _context.SaveChangesAsync();
            return addition;
        }

        public async Task<Addition> UpdateAdditionAsync(Addition addition)
        {
            _context.Additions.Update(addition);
            await _context.SaveChangesAsync();
            return addition;
        }

        public async Task DeleteAdditionAsync(int id)
        {
            var addition = await _context.Additions.FindAsync(id);
            if (addition != null)
            {
                _context.Additions.Remove(addition);
                await _context.SaveChangesAsync();
            }
        }
    }
}

