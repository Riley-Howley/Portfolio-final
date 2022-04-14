using System.ComponentModel.DataAnnotations;
namespace Portfolio.Models
{
    public class Projects
    {
        [Key]
        public int ProjectID { get; set; }
        public string BackgroundImage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
