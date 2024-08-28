using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVCAssignment.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MVCAssignment.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StudentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<Student> Students = new List<Student>()
        {
            new Student(1, "Anju", "Female", 20),
            new Student(2, "Igore", "Female", 21),
            new Student(3, "Aassa", "Female", 19),
            new Student(4, "Erik", "Male", 22),
            new Student(5, "Shehan", "Male", 22),
            new Student(6, "Shradha", "Female", 20),
            new Student(7, "Dilip", "Male", 25),
            new Student(8, "Helena", "Female", 20),
            new Student(9, "Ingela", "Female", 21)
        };
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("sList") != null)
            {
                List<Student> StudentList =
                    JsonConvert.DeserializeObject<List<Student>>(HttpContext.Session.GetString("sList"));

                return View(StudentList);
            }
            else
            {
                return View(Students);
            }

        }


        public IActionResult Details(int id)
        {
            //var student = Students[id -1];
           
                var student = Students.FirstOrDefault(s => s.SId == id);
            return View(student);
                
        }
        public IActionResult StudentList()
        {

            var studentList = Students.OrderBy(s => s.Name).ToList();
            return View(Students);
        }

        public IActionResult DisplayStudents()
        {
            
            return View(Students);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {



            // HttpContext.Session.SetString("sList", JsonConvert.SerializeObject(Students));

            // var s = Students.LastOrDefault();
            //  student.SId = student.SId + 1;

            if (HttpContext.Session.GetString("sList") != null)
            {
                List<Student> StudentList = JsonConvert.DeserializeObject<List<Student>>(HttpContext.Session.GetString("sList"));
                var s = StudentList.LastOrDefault();
                student.SId = s.SId + 1;

                StudentList.Add(student);
                HttpContext.Session.SetString("sList", JsonConvert.SerializeObject(StudentList));
            }
            else
            {
                var s = Students.LastOrDefault();
                student.SId = s.SId + 1;
                Students.Add(student);
                HttpContext.Session.SetString("sList", JsonConvert.SerializeObject(Students));
            }
            // Students.Add(student);
            return RedirectToAction("Index");
        }
    }
}
