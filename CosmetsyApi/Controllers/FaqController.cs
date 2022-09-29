using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IvaBeautyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly IFaqManager _faqManager;

        public FaqController(IFaqManager faqManager)
        {
            _faqManager = faqManager;
        }

        [HttpGet("getall")]
        public List<Faq> GetAll()
        {
            return _faqManager.GetAllFaq();
        }

        [HttpPost("add")]
        public object AddFaq(Faq faq)
        {
            _faqManager.Add(faq);
            return Ok("Faq added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateFaq(Faq faq, int id)
        {
            _faqManager.Update(faq, id);
            return Ok(new { status = 200, message = "Suallar yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteFaq(Faq faq, int id)
        {
            _faqManager.Remove(faq, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
