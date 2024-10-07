using Microsoft.AspNetCore.Mvc;

namespace capacitacion.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class UsuarioController : ControllerBase {

    [HttpGet]
    public IEnumerable<string> FindAll () {
      return new string[] { "value1", "value2" };
    }

    [HttpGet ("{id}")]
    public string FindOne (int id) {
      return "value";
    }

    [HttpPost]
    public void Create ([FromBody] string value) {
    }

    // PUT api/<UsuarioController>/5
    [HttpPut ("{id}")]
    public void Update (int id, [FromBody] string value) {
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete ("{id}")]
    public void Remove (int id) {
    }
  }
}
