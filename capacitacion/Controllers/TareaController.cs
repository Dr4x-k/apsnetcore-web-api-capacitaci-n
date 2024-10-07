using Microsoft.AspNetCore.Mvc;

namespace capacitacion.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class TareaController : ControllerBase {

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

    [HttpPut ("{id}")]
    public void Update (int id, [FromBody] string value) {
    }

    [HttpDelete ("{id}")]
    public void Remove (int id) {
    }
  }
}
