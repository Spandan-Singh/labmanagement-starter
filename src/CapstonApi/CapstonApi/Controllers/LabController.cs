using CapstoneData.Model;
using CapstoneData.Provider;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneApi.Controllers
{
    [ApiController]
    [Route("Labs")]
    public class LabController : Controller
    {
        private readonly ILogger<LabController> _logger;
        private readonly ILabProvider _labProvider;

        public LabController(ILogger<LabController> logger, ILabProvider labProvider)
        {
            _logger = logger;
            _labProvider = labProvider;
        }

        [HttpGet]
        public IEnumerable<Lab> GetAuthers()
        {
            return _labProvider.GetLabs();
        }


        [HttpGet]
        [Route("{id}")]
        public Lab? RetriveAutherById(int id)
        {
            return _labProvider.GetLabById(id);
        }


        [HttpPut]
        [Route("{id}")]
        public Lab UpdateAutherById([FromRoute] int id, [FromBody] Lab lab)
        {
            return _labProvider.UpdateLabById(id, lab);
        }


        [HttpPost]
        public Lab CreateAuther([FromBody] Lab lab)
        {
            return _labProvider.CreateLab(lab);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAutherById(int id)
        {
            return Ok(_labProvider.DeleteLabById(id));
        }
    }
}
