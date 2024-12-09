using System.Globalization;
using Microsoft.AspNetCore.Mvc;


namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        #region verbo Get
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            return BadRequest("Invalid imput");
        }
        #endregion
        #region metodo conferir dados numericos 
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                NumberStyles.Any,
                NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
        #endregion
        #region metodo conversão para decimal 
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
        #endregion
    }
}
 