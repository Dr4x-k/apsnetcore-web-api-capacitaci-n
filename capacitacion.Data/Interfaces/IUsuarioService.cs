using capacitacion.DTOs;
using capacitacion.Models;

namespace capacitacion.Data.Interfaces {
	public interface IUsuarioService {

		public Task<UsuarioModel?> Create(CreateUsuarioDto createUsuarioDto);
		public Task<IEnumerable<UsuarioModel>> FindAll (string targetId);
		public Task<UsuarioModel?> FindOne (string targetId);
		public Task<UsuarioModel?> Update (UpdateUsuarioDto updateUsuarioDto, string targetId);
		public Task<UsuarioModel?> Remove (string targetId);
	}
}
