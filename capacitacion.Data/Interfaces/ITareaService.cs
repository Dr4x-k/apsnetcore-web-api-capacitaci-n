using capacitacion.DTOs.Tarea;
using capacitacion.Models;
<<<<<<< Updated upstream
using capacitacion.DTOs.Tarea;
=======
>>>>>>> Stashed changes

namespace capacitacion.Data.Interfaces {
	public interface ITareaService {
		public Task<TareaModel?> Create(CreateTareaDTO createTareaDTO);
<<<<<<< Updated upstream
		public Task<TareaModel?> Update(int idTarea, UpdateTareaDTO updateTareaDTO);
=======
		// public Task<TareaModel?> Update(UpdateTareaDTO updateTareaDTO);
		public Task<IEnumerable<TareaModel?>> FindAll(int userId);
>>>>>>> Stashed changes
	}
}
