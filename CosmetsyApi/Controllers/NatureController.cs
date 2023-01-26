using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IvaBeautyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatureController : ControllerBase
    {
        private readonly INatureManager _natureManager;

        public NatureController(INatureManager natureManager)
        {
            _natureManager = natureManager;
        }

        [HttpGet("getall")]
        public List<Nature> GetAll()
        {
            return _natureManager.GetAllNature();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var slider = _natureManager.GetNatureById(id);
            return Ok(new { status = 200, message = slider });
        }


        [HttpPost("add")]
        public object AddNature(Nature nature)
        {
            _natureManager.Add(nature);
            return Ok("Nature added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSlider(Nature nature, int id)
        {
            _natureManager.Update(nature, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteBlog(Nature nature, int id)
        {
            _natureManager.Remove(nature, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
