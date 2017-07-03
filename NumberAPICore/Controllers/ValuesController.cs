using Microsoft.AspNetCore.Mvc;
using NumberAPICore.Filters;
using StringMathLib;
namespace NumberAPICore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly StringNumber calc;
        public ValuesController(StringNumber nums)
        {
            this.calc = nums;
        }
        // GET api/values

        [Route("addnumbers/{number1}/{number2}")]
        [TypeFilter(typeof(LogMeAll))]
        public string Addnumbers(string number1, string number2)
        {
            if (string.IsNullOrEmpty(number1) || string.IsNullOrEmpty(number2))
                return null;
            return calc.AddOrSubNumber(number1, number2);
        }
    }
}
