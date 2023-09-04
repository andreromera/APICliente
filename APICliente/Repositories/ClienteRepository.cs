using APICliente.Data;
using APICliente.Models;
using Microsoft.EntityFrameworkCore;
using APICliente.Repositories.Interfaces;

namespace APICliente.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbClientesContext _context;

        public ClienteRepository(DbClientesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        } 

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public void Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Cliente? cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
