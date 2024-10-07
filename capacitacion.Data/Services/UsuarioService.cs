using capacitacion.Data.Interfaces;
using capacitacion.DTOs;
using capacitacion.Models;
using Dapper;
using Npgsql;

namespace capacitacion.Data.Services {
	public class UsuarioService : IUsuarioService {

		private PostgreSQLConnection _connection;

		public UsuarioService(PostgreSQLConnection connection) => _connection = connection;

		private NpgsqlConnection CreateConnection() => new(_connection.ConnectionString);

		#region Create
		public async Task<UsuarioModel?> Create(CreateUsuarioDto createUsuarioDto) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "";

			try {
				await database.OpenAsync();

				UsuarioModel? result = await database.QueryFirstOrDefaultAsync<UsuarioModel>(sqlQuery, new {
					name = createUsuarioDto.Nombre,
					userName = createUsuarioDto.Usuario,
					passowrd = createUsuarioDto.Contrasena
				});

				await database.CloseAsync();

				return result;
			} catch (Exception e) {
				return null;
			}
		}
		#endregion

		#region FindAll
		public async Task<IEnumerable<UsuarioModel>> FindAll() {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "";

			Dictionary<string, List<TareaModel>> tasks = new();

			try {
				await database.OpenAsync();

				IEnumerable<UsuarioModel> result = await database.QueryAsync<UsuarioModel, TareaModel, UsuarioModel>(
					sql: sqlQuery,
					param: new {},
					map: (user, task) => {
						List<TareaModel> userTasks = tasks[user.IdUsuario] ?? [];

						if (userTasks.Count == 0) userTasks = [task];
						else userTasks.Add(task);

						tasks[user.IdUsuario] = userTasks;

						return user;
					},
					splitOn: "IdTarea"
				);

				IEnumerable<UsuarioModel> usuarios = result.Distinct().ToList().Select(user => {
					List<TareaModel> userTasks = tasks[user.IdUsuario];
					user.Tareas = userTasks;
					return user;
				});

				await database.CloseAsync();

				return result;
			} catch (Exception e) {
				return [];
			}
		}
		#endregion

		#region FindOne
		public async Task<UsuarioModel?> FindOne(string targetId) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "";

			Dictionary<string, List<TareaModel>> tasks = new();

			try {
				await database.OpenAsync();

				IEnumerable<UsuarioModel> result = await database.QueryAsync<UsuarioModel, TareaModel, UsuarioModel>(
					sql: sqlQuery,
					param: new {},
					map: (user, task) => {
						List<TareaModel> userTasks = tasks[user.IdUsuario] ?? [];

						if (userTasks.Count == 0) userTasks = [task];
						else userTasks.Add(task);

						tasks[user.IdUsuario] = userTasks;

						return user;
					},
					splitOn: "IdTarea"
				);

				await database.CloseAsync();

				return result.FirstOrDefault();
			} catch (Exception e) {
				return null;
			}
		}
		#endregion

		#region Remove
		public async Task<UsuarioModel?> Remove(string userId) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "";

			try {
				await database.OpenAsync();

				UsuarioModel? result = await database.QueryFirstOrDefaultAsync<UsuarioModel>(sqlQuery, new { userId = userId });

				await database.CloseAsync();

				return result;
			} catch (Exception e) {
				return null;
			}
		}
		#endregion

		#region Update
		public async Task<UsuarioModel?> Update(UpdateUsuarioDto updateUsuarioDto, string userId) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "";

			try {
				await database.OpenAsync();

				UsuarioModel? result = await database.QueryFirstOrDefaultAsync<UsuarioModel>(sqlQuery, new { userId });

				await database.CloseAsync();

				return result;
			} catch (Exception e) {
				return null;
			}
		}
		#endregion
	}
}
