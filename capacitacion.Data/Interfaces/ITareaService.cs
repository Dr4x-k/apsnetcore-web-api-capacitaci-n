using capacitacion.Models;
using capacitacion.DTOs;

namespace capacitacion.Data.Interfaces {
  public interface ITareaService {
    public Task<List<TareaModel>> FindAll();
    public Task<TareaModel> FindOne(string targetId);
    public Task<TareaModel> Create(CreateTareaDTO createTareaDTO);
    public Task<TareaModel> Update(UpdateTareaDTO updateTareaDTO, string targetId);
  }
}