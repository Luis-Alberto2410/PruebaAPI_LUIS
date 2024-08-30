using Microsoft.AspNetCore.Mvc;
using MissingNumber;

namespace MissingNumber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MissingNumberController : ControllerBase
    {
        private readonly NaturalNumberSet _naturalNumberSet;

        public MissingNumberController()
        {
            _naturalNumberSet = new NaturalNumberSet();
        }

        [HttpPost("extract")]
        public IActionResult ExtractNumber([FromBody] int number)
        {
            try
            {
                _naturalNumberSet.Extract(number);
                return Ok(new { Message = $"El número {number} fue extraído." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("calculate")]
        public IActionResult CalculateMissingNumber()
        {
            int missingNumber = _naturalNumberSet.CalculateMissingNumber();
            return Ok(new { MissingNumber = missingNumber });
        }
    }
}
