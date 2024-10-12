using capacitacion.Data.Interfaces;
using capacitacion.DTOs.Tarea;
using capacitacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace capacitacion.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class TareaController : ControllerBase {
		ITareaService _service;
		public TareaController(ITareaService service) => _service = service;
		// http://localhost:5000/api/create
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateTareaDTO createTareaDTO) {
			TareaModel? task = await _service.Create(createTareaDTO);
			if (task == null) return NotFound();
			return Ok(task);
		}

		[HttpPut("{idUsuario}")]
		public async Task<IActionResult> Update(int idUsuario, [FromBody] UpdateTareaDTO updateTareaDTO) {
			TareaModel? task = await _service.Update(idUsuario, updateTareaDTO);
			if (task == null) return NotFound();
			return Ok(task);
		}
	}
}
