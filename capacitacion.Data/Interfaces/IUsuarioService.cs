using capacitacion.DTOs;
using capacitacion.Models;

namespace capacitacion.Data.Interfaces {
	public interface IUsuarioService {

		public Task<UsuarioModel?> Create(CreateUsuarioDto createUsuarioDto);
		public Task<IEnumerable<UsuarioModel>> FindAll ();
		public Task<UsuarioModel?> FindOne (int targetId);
		public Task<UsuarioModel?> Update (UpdateUsuarioDto updateUsuarioDto, int targetId);
		public Task<UsuarioModel?> Remove (int targetId);
	}
}
