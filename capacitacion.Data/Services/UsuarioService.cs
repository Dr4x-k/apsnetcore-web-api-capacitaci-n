using capacitacion.Data.Interfaces;
using capacitacion.DTOs;
using capacitacion.Models;
using Dapper;
using Npgsql;

namespace capacitacion.Data.Services;
public class UsuarioService : IUsuarioService {

	private PostgreSQLConnection _connection;

	public UsuarioService(PostgreSQLConnection connection) => _connection = connection;

	private NpgsqlConnection CreateConnection() => new(_connection.ConnectionString);

	#region Create
	public async Task<UsuarioModel?> Create(CreateUsuarioDto createUsuarioDto) {
		using NpgsqlConnection database = CreateConnection();
		string sqlQuery = "select * from fun_user_create(p_nombres := @names, p_usuario := @userName, p_contrasena := @password);";

		try {
			await database.OpenAsync();

			UsuarioModel? result = await database.QueryFirstOrDefaultAsync<UsuarioModel>(sqlQuery, new {
				names = createUsuarioDto.Nombres,
				userName = createUsuarioDto.Usuario,
				password = createUsuarioDto.Contrasena
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
		string sqlQuery = "select * from view_usuario;";

		Dictionary<int, List<TareaModel>> tasks = new();

		try {
			await database.OpenAsync();

			IEnumerable<UsuarioModel> result = await database.QueryAsync<UsuarioModel>(
				sql: sqlQuery
				//map: (user, task) => {
				//	List<TareaModel> userTasks = tasks[user.IdUsuario] ?? [];

				//	if (userTasks.Count == 0) userTasks = [task];
				//	else userTasks.Add(task);

				//	tasks[user.IdUsuario] = userTasks;

				//	return user;
				//},
				//splitOn: "IdTarea"
			);

			//IEnumerable<UsuarioModel> users = result.Distinct().ToList().Select(user => {
			//	List<TareaModel> userTasks = tasks[user.IdUsuario];
			//	user.Tareas = userTasks;
			//	return user;
			//});

			IEnumerable<UsuarioModel> users = result.Distinct();

			await database.CloseAsync();

			return users;
		} catch (Exception e) {
			return [];
		}
	}
	#endregion

	#region FindOne
	public async Task<UsuarioModel?> FindOne(int targetId) {
		using NpgsqlConnection database = CreateConnection();
		string sqlQuery = "select * from view_usuario where idUsuario = @targetId;";

		List<TareaModel> tasks = new();

		try {
			await database.OpenAsync();

			IEnumerable<UsuarioModel> result = await database.QueryAsync<UsuarioModel>(
				sql: sqlQuery,
				param: new {
					targetId
				}
				//map: (user, task) => {
				//	tasks.Add(task);
				//	return user;
				//},
				//splitOn: "IdTarea"
			);

			await database.CloseAsync();

			UsuarioModel? user = result.FirstOrDefault();

			if (user == null) return null;

			user.Tareas = tasks;

			return user;
		} catch (Exception e) {
			return null;
		}
	}
	#endregion

	#region Remove
	public async Task<UsuarioModel?> Remove(int targetId) {
		using NpgsqlConnection database = CreateConnection();
		string sqlQuery = "select * from fun_user_remove(p_idUsuario := @targetId);";

		try {
			await database.OpenAsync();

			UsuarioModel? result = await database.QueryFirstOrDefaultAsync<UsuarioModel>(sqlQuery, new {
				targetId 
			});

			await database.CloseAsync();

			return result;
		} catch (Exception e) {
			return null;
		}
	}
	#endregion

	#region Update
	public async Task<UsuarioModel?> Update(UpdateUsuarioDto updateUsuarioDto, int targetId) {
		using NpgsqlConnection database = CreateConnection();
		string sqlQuery = "select * from fun_user_update(p_idUsuario := @targetId, p_nombres := @names, p_usuario := @userName, p_contrasena := @password)";

		try {
			await database.OpenAsync();

			UsuarioModel? result = await database.QueryFirstOrDefaultAsync<UsuarioModel>(sqlQuery, new {
				targetId,
				names = updateUsuarioDto.Nombres,
				userName = updateUsuarioDto.Usuario,
				password = updateUsuarioDto.Contrasena
			});

			await database.CloseAsync();

			return result;
		} catch (Exception e) {
			return null;
		}
	}
	#endregion
}
