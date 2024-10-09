namespace capacitacion.Models
{
  public class UsuarioModel
  {
    public int IdUsuario { get; set; }
    public string Nombres { get; set; }
    public string Usuario { get; set; }
    public string Contrasena { get; set; }
		public IEnumerable<TareaModel> Tareas { get; set; } = [];

  }
}
