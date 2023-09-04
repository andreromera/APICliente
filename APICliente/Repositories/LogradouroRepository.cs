using AutoMapper;
using APICliente.Data;
using APICliente.Models;
using Microsoft.EntityFrameworkCore;
using APICliente.Repositories.Interfaces;

namespace APICliente.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly DbClientesContext _context;

        public LogradouroRepository(DbClientesContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Logradouro>> GetAllAsync()
        {
            return await _context.Logradouros.ToListAsync();
        }

        public async Task <Logradouro?> GetByIdAsync(int id)
        {
            return await _context.Logradouros.FindAsync(id);
        }

        public void Create(Logradouro logradouro)
        {
            _context.Logradouros.Add(logradouro);
            _context.SaveChanges();
        }

        public void Update(Logradouro logradouro)
        {
            _context.Entry(logradouro).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Logradouro? logradouro = _context.Logradouros.Find(id);
            if (logradouro != null)
            {
                _context.Logradouros.Remove(logradouro);
                _context.SaveChanges();
            }
        }
    }
}
