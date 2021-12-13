using Hybrid.Models;
using Hybrid;
using Microsoft.AspNetCore.Mvc;

namespace HybridEncrypt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecryptController : ControllerBase
    {
        public DecryptController()
        {

        }

        [HttpPost]
        public IActionResult Decrypt(SymmetricTextModel encrypted)
        {

            HybridProvider hybridProvider = new HybridProvider();
            string text = hybridProvider.HybridDecryption(encrypted);
            if (text is null)
            {
                return BadRequest("Invalid input");
            }
            return Ok(text);
        }
    }
}