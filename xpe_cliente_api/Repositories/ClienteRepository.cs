using Microsoft.EntityFrameworkCore;
using XpeClienteApi.Data;
using XpeClienteApi.Models;

namespace XpeClienteApi.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync() =>
        await _context.Clientes.ToListAsync();

    public async Task<Cliente?> GetByIdAsync(int id) =>
        await _context.Clientes.FindAsync(id);

    public async Task<IEnumerable<Cliente>> GetByNomeAsync(string nome) =>
        await _context.Clientes
            .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
            .ToListAsync();

    public async Task<int> CountAsync() =>
        await _context.Clientes.CountAsync();

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente?> UpdateAsync(int id, Cliente cliente)
    {
        var existing = await _context.Clientes.FindAsync(id);
        if (existing == null) return null;

        existing.Nome = cliente.Nome;
        existing.Email = cliente.Email;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }
}
