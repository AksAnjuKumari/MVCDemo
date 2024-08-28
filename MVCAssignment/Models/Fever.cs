using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    public class Fever
    {
        //Data Anotation to change tha Property name in display screen
        [Display(Name = "Body Tempreture")]
        public double BTemp { get; set; }

        public string Message { get; set; }

        public string TemperatureUnit { get; set; }
    }
}
