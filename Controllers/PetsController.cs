
using Microsoft.AspNetCore.Mvc;
using LHPetsAPI.Models;

namespace LHPetsAPI.Controllers;

[ApiController]
[Route("api/pets")]
public class PetsController : ControllerBase
{
    private static readonly List<Pet> pets = new();
    private static int proximoId = 1;

    [HttpGet]
    public ActionResult<IEnumerable<Pet>> Get()
    {
        return Ok(pets);
    }

    [HttpPost]
    public ActionResult<Pet> Post(Pet pet)
    {
        pet.Id = proximoId++;
        pets.Add(pet);

        return Ok(pet);
    }

    [HttpGet("cliente/{clienteId}")]
    public ActionResult<IEnumerable<Pet>> GetPorCliente(int clienteId)
    {
        var petsDoCliente = pets
            .Where(p => p.ClienteId == clienteId)
            .ToList();

        return Ok(petsDoCliente);
    }
}
