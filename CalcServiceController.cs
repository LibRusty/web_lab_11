using Microsoft.AspNetCore.Mvc;
using CalcService.Services;
using System;

namespace CalcService.Controllers
{
    public class CalcServiceController : Controller
    {
        private readonly Services.CalculatorService _calcService;

        public CalcServiceController(Services.CalculatorService calcService) 
        {
            _calcService = calcService;
        }

        public IActionResult PassUsingModel()
        {
            var rand = new Random();
            int a = rand.Next(0, 11);
            int b = rand.Next(0, 11);

            var model = new CalcModel
            {
                A = a,
                B = b,
                Sum = _calcService.Add(a, b),
                Difference = _calcService.Subtract(a, b),
                Product = _calcService.Multiply(a, b),
                Quotient = b != 0 ? _calcService.Divide(a, b) : double.NaN
            };

            return View(model);
        }

        public IActionResult PassUsingViewData()
        {
            var rand = new Random();
            int a = rand.Next(0, 11);
            int b = rand.Next(0, 11);

            ViewData["A"] = a;
            ViewData["B"] = b;
            ViewData["Sum"] = _calcService.Add(a, b);
            ViewData["Difference"] = _calcService.Subtract(a, b);
            ViewData["Product"] = _calcService.Multiply(a, b);
            ViewData["Quotient"] = b != 0 ? _calcService.Divide(a, b) : "Ошибка: деление на ноль";

            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            var rand = new Random();
            int a = rand.Next(0, 11);
            int b = rand.Next(0, 11);

            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.Sum = _calcService.Add(a, b);
            ViewBag.Difference = _calcService.Subtract(a, b);
            ViewBag.Product = _calcService.Multiply(a, b);
            ViewBag.Quotient = b != 0 ? (double)a / b : (double?)null;

            return View();
        }

        public IActionResult AccessServiceDirectly()
        {
            var rand = new Random();
            int a = rand.Next(0, 11);
            int b = rand.Next(0, 11);

            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.Sum = _calcService.Add(a, b);
            ViewBag.Difference = _calcService.Subtract(a, b);
            ViewBag.Product = _calcService.Multiply(a, b);
            ViewBag.Quotient = b != 0 ? (double)a / b : (double?)null;

            return View();
        }
    }

    public class CalcModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Sum { get; set; }
        public int Difference { get; set; }
        public int Product { get; set; }
        public double Quotient { get; set; }
    }
}