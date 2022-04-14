using System.ComponentModel.DataAnnotations;
namespace Portfolio.Models
{
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }
        public string BackgroundImage { get; set; }
        public string ServicesTitle { get; set; }
        public string ServicesDescription { get; set; }
        //public List<string> Icons { get; set; }
    }
}
