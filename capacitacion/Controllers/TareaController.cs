<<<<<<< Updated upstream
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
=======
﻿using Microsoft.AspNetCore.Mvc;
using capacitacion.Data.Interfaces;
using capacitacion.Models;
using capacitacion.DTOs.Tarea;

namespace capacitacion.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class TareaController : ControllerBase {
		ITareaService _service;
		public TareaController (ITareaService service) => _service = service;
		// localhost:5000/api/Tarea?userId=1
    [HttpGet]
    public async Task<IActionResult> FindAll ([FromQuery] int userId) {
      IEnumerable<TareaModel?> tasks = await _service.FindAll(userId);
			
			if (tasks.Count() == 0) {
				return  NotFound();
			}

			return Ok(tasks);
    }

    [HttpGet ("{id}")]
    public string FindOne (int id) {
      return "value";
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTareaDTO createTareaDTO) {
			TareaModel? task = await _service.Create(createTareaDTO);

			if (task == null) return NotFound();

			return Ok(task);
    }

    [HttpPut ("{id}")]
    public void Update (int id, [FromBody] string value) {
    }

    [HttpDelete ("{id}")]
    public void Remove (int id) {
    }
  }
}
>>>>>>> Stashed changes
