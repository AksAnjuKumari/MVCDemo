using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    public class GGame
    {
        public int SNum { get; set; }

        [Display(Name = "Your Guess")]
        public int GNum { get; set; }
        public string Message { get; set; }

        public int Attemts {  get; set; }
    }
}
