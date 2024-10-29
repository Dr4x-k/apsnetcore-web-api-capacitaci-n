<<<<<<< Updated upstream
=======
using System.Data;
>>>>>>> Stashed changes
using capacitacion.Data.Interfaces;
using capacitacion.DTOs.Tarea;
using capacitacion.Models;
using Dapper;
using Npgsql;

namespace capacitacion.Data.Services {
	public class TareaService : ITareaService {
		private PostgreSQLConnection _connection;
<<<<<<< Updated upstream

		public TareaService(PostgreSQLConnection connection) => _connection = connection;

=======
		public TareaService(PostgreSQLConnection connection) => _connection = connection;
>>>>>>> Stashed changes
		private NpgsqlConnection CreateConnection() => new(_connection.ConnectionString);

		#region Create
		public async Task<TareaModel?> Create(CreateTareaDTO createTareaDTO) {
			using NpgsqlConnection database = CreateConnection();
<<<<<<< Updated upstream
			string sqlQuery = "select * from fun_task_create (p_tarea := @task, p_descripcion := @description, p_idusuario := @userId);";

			try {
				await database.OpenAsync();

=======
			string sqlQuery = "select * from fun_task_create (" +
				"p_tarea := @task," +
				"p_descripcion := @description," +
				"p_idUsuario := @userId" +
				");";

			try {
				await database.OpenAsync();
				
>>>>>>> Stashed changes
				var result = await database.QueryAsync<TareaModel, UsuarioModel, TareaModel>(
					sqlQuery,
					param: new {
						task = createTareaDTO.Tarea,
						description = createTareaDTO.Descripcion,
<<<<<<< Updated upstream
						userId =  createTareaDTO.IdUsuario
=======
						userId = createTareaDTO.IdUsuario
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
		#region Update
		public async Task<TareaModel?> Update(int idTarea, UpdateTareaDTO updateTareaDTO) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "select * from fun_task_update (p_idtarea := @taskId, p_tarea := @task, p_descripcion := @description);";
=======
		#region FindAll
		public async Task<IEnumerable<TareaModel?>> FindAll(int userId) {
			using NpgsqlConnection database = CreateConnection();
			string sqlQuery = "SELECT * FROM view_tarea WHERE idUsuario = @userId";
>>>>>>> Stashed changes

			try {
				await database.OpenAsync();

				var result = await database.QueryAsync<TareaModel, UsuarioModel, TareaModel>(
					sqlQuery,
					param: new {
<<<<<<< Updated upstream
						task = updateTareaDTO.Tarea,
						description = updateTareaDTO.Descripcion,
						taskId = idTarea
=======
						userId
>>>>>>> Stashed changes
					},
					map: (task, user) => {
						task.Usuario = user;

						return task;
					},
					splitOn: "usuarioId"
				);

				await database.CloseAsync();

<<<<<<< Updated upstream
				return result.FirstOrDefault();
=======
				return result;
>>>>>>> Stashed changes
			} catch (Exception ex) {
				return null;
			}
		}
		#endregion
	}
}
