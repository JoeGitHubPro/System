using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.DAL.Data;
using System.DAL.DTOs;
using System.DAL.Models;

namespace System.BAL.Services
{
    public class AdditionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdditionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdditionDTO>> GetAllAdditionsAsync()
        {
            var additions = await _context.Additions.ToListAsync();
            return _mapper.Map<IEnumerable<AdditionDTO>>(additions);
        }

        public async Task<AdditionDTO> GetAdditionByIdAsync(int id)
        {
            var addition = await _context.Additions.FindAsync(id);
            return _mapper.Map<AdditionDTO>(addition);
        }

        public async Task<AdditionDTO> AddAdditionAsync(AdditionDTO additionDTO)
        {
            var addition = _mapper.Map<Addition>(additionDTO);
            _context.Additions.Add(addition);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdditionDTO>(addition);
        }

        public async Task UpdateAdditionAsync(AdditionDTO additionDTO)
        {
            var addition = _mapper.Map<Addition>(additionDTO);
            _context.Entry(addition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
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

