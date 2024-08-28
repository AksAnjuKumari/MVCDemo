using Microsoft.AspNetCore.Mvc;
using MVCAssignment.Models;
using System.Xml.Linq;

namespace MVCAssignment.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FeverCheck()
        {
            Fever model = new Fever();
            return View(model);

        }
        [HttpPost]
        public IActionResult FeverCheck(Fever obj)
        {
            if (obj.TemperatureUnit == "Fahrenheit")
            {
                // Convert Fahrenheit to Celsius
                obj.BTemp = (obj.BTemp - 32) * 5 / 9;
            }
            if (obj.BTemp < 36.1)
                obj.Message = "You may have hypothermia or other health issues. Consult with Doctor.";
            else if (obj.BTemp >= 36.1 && obj.BTemp <= 37.2)
                obj.Message = "Not to worry! You do not have fever. ";
            else if (obj.BTemp >= 37.3 && obj.BTemp <= 38)
                obj.Message = "You have fever, Take rest. ";
            else if (obj.BTemp > 38)
                obj.Message = "You have high fever. Consult a doctor as soon as possiable.";
            return View(obj);
        }


        public IActionResult GuessGame()
        {
            int Attempts;
            GGame model = new GGame();
            Random rnd = new Random();
            int sNum = rnd.Next(1, 501);
            model.SNum = sNum;
            HttpContext.Session.SetInt32("SNumber", sNum);
            return View(model);
        }

        [HttpPost]
        public IActionResult GuessGame(GGame obj)
        {
            
            obj.SNum = (int)HttpContext.Session.GetInt32("SNumber");
            int counter = (int)(HttpContext.Session.GetInt32("GuessAttempts") ?? 0); // Retrieve existing counter or default to 0

            if (obj.GNum > obj.SNum)
            {
                obj.Message = "Your guess is hihg!";
            }
            else if (obj.GNum < obj.SNum)
            {
                obj.Message = "Your guess is low.";
            }
            else
            {
                obj.Message = "You guessed it correct!";
                HttpContext.Session.Clear();
            }

            counter++;
            HttpContext.Session.SetInt32("GuessAttempts", counter); // Store updated counter in session
            obj.Attemts = counter;
            return View(obj);
        }

        public IActionResult Greet()
        {
            ViewBag.vbMsg = "Welcome To My MVC Assignment and this message is through ViewBag.";
            ViewData["vdMsg"] = "Welcome To My MVC Assignment and this message is through ViewData";
            TempData["tdMsg"] = "Welcome To My MVC Assignment and this message is through TempData";
            return View();
        }
    }
}
