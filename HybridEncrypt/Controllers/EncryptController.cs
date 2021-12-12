using Hybrid.Models;
using Hybrid;
using Microsoft.AspNetCore.Mvc;

namespace HybridEncrypt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : ControllerBase
    {
        public EncryptController()
        {

        }

        [HttpPost]
        public IActionResult Encrypt(TextModel text)
        {
            HybridProvider hybridProvider = new HybridProvider();
            SymmetricTextModel encrypted = hybridProvider.HybridEncryption(text.Text);
            return Ok(encrypted);
        }
    }
}