namespace capacitacion.DTOs {
  public class CreateTareaDTO {
    public string Tarea { get; set; }
    public string Descripcion { get; set; }
    public bool Completado { get; set; }
    public string IdUsuario { get; set; }
  }
}