
using Microsoft.AspNetCore.Mvc;
using LHPetsAPI.Models;

namespace LHPetsAPI.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private static readonly List<Cliente> clientes = new();
    private static int proximoId = 1;

    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> Get()
    {
        return Ok(clientes);
    }

    [HttpPost]
    public ActionResult<Cliente> Post(Cliente cliente)
    {
        cliente.Id = proximoId++;
        clientes.Add(cliente);

        return Ok(cliente);
    }
}
