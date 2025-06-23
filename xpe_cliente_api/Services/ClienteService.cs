
using XpeClienteApi.Models;
using XpeClienteApi.Repositories;

namespace XpeClienteApi.Services;

public class ClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Cliente>> ListarTodosAsync() => _repository.GetAllAsync();
    public Task<Cliente?> BuscarPorIdAsync(int id) => _repository.GetByIdAsync(id);
    public Task<IEnumerable<Cliente>> BuscarPorNomeAsync(string nome) => _repository.GetByNomeAsync(nome);
    public Task<int> ContarAsync() => _repository.CountAsync();
    public Task<Cliente> CriarAsync(Cliente cliente) => _repository.CreateAsync(cliente);
    public Task<Cliente?> AtualizarAsync(int id, Cliente cliente) => _repository.UpdateAsync(id, cliente);
    public Task<bool> DeletarAsync(int id) => _repository.DeleteAsync(id);
}
