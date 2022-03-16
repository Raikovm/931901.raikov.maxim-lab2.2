using Microsoft.AspNetCore.Mvc;
using WEB_Lab_2.Models;

namespace WEB_Lab_2.Controllers
{
    public class CalcServiceController : Controller
    {

        public IActionResult Index() => View();

        public IActionResult ManualParsingSingle()
        {
            if (Request.Method != "POST") 
                return View("Window");
            
            try
            {
                var calc = new CalcModel
                {
                    X = float.Parse(HttpContext.Request.Form["x"]),
                    Operation = HttpContext.Request.Form["operation"],
                    Y = float.Parse(HttpContext.Request.Form["y"])
                };

                ViewBag.Result = calc.Calc();
            }
            catch
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }



        [HttpGet]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparateGet() => View("Window");

        [HttpPost]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparatePost()
        {
            try
            {
                var calc = new CalcModel
                {
                    X = float.Parse(HttpContext.Request.Form["x"]),
                    Operation = HttpContext.Request.Form["operation"],
                    Y = float.Parse(HttpContext.Request.Form["y"])
                };

                ViewBag.Result = calc.Calc();
            }
            catch
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }



        [HttpGet]
        public IActionResult ModelBindingParameters() => View("Window");

        [HttpPost]
        public IActionResult ModelBindingParameters(int x, string operation, int y)
        {
            if (ModelState.IsValid)
            {
                var calc = new CalcModel
                {
                    X = x,
                    Operation = operation,
                    Y = y
                };
                ViewBag.Result = calc.Calc();
            }
            else
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingSeparate() => View("Window");

        [HttpPost]
        public IActionResult ModelBindingSeparate(CalcModel model)
        {
            ViewBag.Result = ModelState.IsValid
                ? model.Calc()
                : "Invalid input";

            return View("Result");
        }
    }
}
