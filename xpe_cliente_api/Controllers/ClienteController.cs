using Microsoft.AspNetCore.Mvc;
using XpeClienteApi.Models;
using XpeClienteApi.Services;

namespace XpeClienteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _service;

    public ClienteController(ClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.ListarTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _service.BuscarPorIdAsync(id);
        return cliente is null ? NotFound() : Ok(cliente);
    }

    [HttpGet("nome/{nome}")]
    public async Task<IActionResult> GetByNome(string nome) =>
        Ok(await _service.BuscarPorNomeAsync(nome));

    [HttpGet("contar")]
    public async Task<IActionResult> Contar() =>
        Ok(await _service.ContarAsync());

    [HttpPost]
    public async Task<IActionResult> Criar(Cliente cliente)
    {
        var criado = await _service.CriarAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Cliente cliente)
    {
        var atualizado = await _service.AtualizarAsync(id, cliente);
        return atualizado is null ? NotFound() : Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var sucesso = await _service.DeletarAsync(id);
        return sucesso ? NoContent() : NotFound();
    }
}
