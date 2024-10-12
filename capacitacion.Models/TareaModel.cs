namespace capacitacion.Models {
	public class TareaModel {
		public int IdTarea { get; set; }
		public string Tarea { get; set; }
		public string Descripcion { get; set; }
		public bool Completada { get; set; }
		public UsuarioModel Usuario { get; set; }
	}
}
