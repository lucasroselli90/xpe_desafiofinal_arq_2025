using XpeClienteApi.Models;

namespace XpeClienteApi.Repositories;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task<IEnumerable<Cliente>> GetByNomeAsync(string nome);
    Task<int> CountAsync();
    Task<Cliente> CreateAsync(Cliente cliente);
    Task<Cliente?> UpdateAsync(int id, Cliente cliente);
    Task<bool> DeleteAsync(int id);
}
