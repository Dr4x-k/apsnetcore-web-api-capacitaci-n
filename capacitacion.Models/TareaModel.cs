namespace capacitacion.Models
{
  public class TareaModel
  {
    public string IdTarea { get; set; }
    public string Tarea { get; set; }
    public string Descripcion { get; set; }
    public bool Completado { get; set; }
		public UsuarioModel Usuario { get; set; }
  }
}
