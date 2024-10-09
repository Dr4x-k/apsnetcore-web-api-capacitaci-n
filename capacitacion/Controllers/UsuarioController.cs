using capacitacion.Data.Interfaces;
using capacitacion.DTOs;
using capacitacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace capacitacion.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class UsuarioController : ControllerBase {

		IUsuarioService _service;

		public UsuarioController(IUsuarioService service) => _service = service;

		[HttpGet]
    public async Task<IActionResult> FindAll () {
			IEnumerable<UsuarioModel> users = await _service.FindAll();
			return Ok(users);
    }

    [HttpGet ("{targetId}")]
    public async Task<IActionResult> FindOne (int targetId) {
			UsuarioModel? user = await _service.FindOne(targetId);

			if (user == null) return NotFound();

			return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create ([FromBody] CreateUsuarioDto createUsuarioDto) {
			UsuarioModel? user = await _service.Create(createUsuarioDto);

			if (user == null) return StatusCode(500);

			return Created(user.IdUsuario.ToString(), user);
    }

    [HttpPut ("{targetId}")]
    public async Task<IActionResult> Update (int targetId, [FromBody] UpdateUsuarioDto updateUsuarioDto) {
			UsuarioModel? userUpdated = await _service.Update(updateUsuarioDto, targetId);
			return Ok(userUpdated);
    }

    [HttpDelete ("{targetId}")]
    public async Task<IActionResult> Remove (int targetId) {
			UsuarioModel? userRemoved = await _service.Remove(targetId);
			return Ok(userRemoved);
    }
  }
}
