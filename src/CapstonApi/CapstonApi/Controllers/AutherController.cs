using CapstoneData.Model;
using CapstoneData.Provider;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneApi.Controllers
{
    [ApiController]
    [Route("Authers")]
    public class AutherController : ControllerBase
    {
        private readonly ILogger<AutherController> _logger;
        private readonly IAutherProvider _autherProvider;

        public AutherController(ILogger<AutherController> logger, IAutherProvider autherProvider)
        {
            _logger = logger;
            _autherProvider = autherProvider;
        }

        [HttpGet]
        public IEnumerable<AutherDbo> GetAuthers()
        {
            return _autherProvider.GetAuthers();
        }


        [HttpGet]
        [Route("{id}")]
        public AutherDbo? RetriveAutherById(int id)
        {
            return _autherProvider.GetAutherById(id);
        }


        [HttpPut]
        [Route("{id}")]
        public AutherDbo UpdateAutherById([FromRoute]int id, [FromBody] AutherDbo auther)
        {
            return _autherProvider.UpdateAutherById(id, auther);
        }


        [HttpPost]
        public AutherDbo CreateAuther([FromBody] AutherDbo auther)
        {
            return _autherProvider.CreateAuther(auther);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAutherById(int id)
        {
            return Ok(_autherProvider.DeleteAutherById(id));
        }
    }
}
