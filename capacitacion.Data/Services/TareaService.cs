using capacitacion.Data.Interfaces;
using capacitacion.DTOs.Tarea;
using capacitacion.Models;
using Dapper;
using Npgsql;

namespace capacitacion.Data.Services {
	public class TareaService : ITareaService {
		private PostgreSQLConnection _connection;

		public TareaService(PostgreSQLConnection connection) => _connection = connection;

		private NpgsqlConnection CreateConnection() => new(_connection.ConnectionString);

		#region Create
		public async Task<TareaModel?> Create(CreateTareaDTO createTareaDTO) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "select * from fun_task_create (p_tarea := @task, p_descripcion := @description, p_idusuario := @userId);";

			try {
				await database.OpenAsync();

				var result = await database.QueryAsync<TareaModel, UsuarioModel, TareaModel>(
					sqlQuery,
					param: new {
						task = createTareaDTO.Tarea,
						description = createTareaDTO.Descripcion,
						userId =  createTareaDTO.IdUsuario
					},
					map: (task, user) => {
						task.Usuario = user;

						return task;
					},
					splitOn: "usuarioId"
				);

				await database.CloseAsync();

				return result.FirstOrDefault();
			} catch (Exception ex) {
				return null;
			}
		}
		#endregion

		#region Update
		public async Task<TareaModel?> Update(int idTarea, UpdateTareaDTO updateTareaDTO) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "select * from fun_task_update (p_idtarea := @taskId, p_tarea := @task, p_descripcion := @description);";

			try {
				await database.OpenAsync();

				var result = await database.QueryAsync<TareaModel, UsuarioModel, TareaModel>(
					sqlQuery,
					param: new {
						task = updateTareaDTO.Tarea,
						description = updateTareaDTO.Descripcion,
						taskId = idTarea
					},
					map: (task, user) => {
						task.Usuario = user;

						return task;
					},
					splitOn: "usuarioId"
				);

				await database.CloseAsync();

				return result.FirstOrDefault();
			} catch (Exception ex) {
				return null;
			}
		}
		#endregion
	}
}
