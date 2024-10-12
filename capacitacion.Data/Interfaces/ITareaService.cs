using capacitacion.Models;
using capacitacion.DTOs.Tarea;

namespace capacitacion.Data.Interfaces {
	public interface ITareaService {
		public Task<TareaModel?> Create(CreateTareaDTO createTareaDTO);
		public Task<TareaModel?> Update(int idTarea, UpdateTareaDTO updateTareaDTO);
	}
}
