using Microsoft.AspNetCore.Mvc;
using To_Do_Project;

[ApiController]
[Route("[controller]")]
public class To_Do_Controller : ControllerBase
{
    To_Do_Service _service;
    
    public To_Do_Controller(To_Do_Service service)
    {
        _service = service;
    }


    [HttpGet]
    public IEnumerable<To_Do> Get_All()
    {
        return _service.Get_All();
    }


    [HttpGet("{id}")]
    public ActionResult<To_Do> GetById(string id)
    {
        var To_Do = _service.Get_To_Do_By_TitleId(id);

        if(To_Do is not null)
        {
            return To_Do;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Add_To_Do(To_Do newTo_Do)
    {
        var To_Do = _service.Add_To_Do(newTo_Do);
        return CreatedAtAction(nameof(GetById), new { id = To_Do!.TitleId }, To_Do);
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteById(string id)
    {
        var To_Do = _service.Get_To_Do_By_TitleId(id);

        if(To_Do is not null)
        {
            _service.Delete_To_Do_By_TitleId(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}