using System.ComponentModel.DataAnnotations;
namespace Portfolio.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }
        public string LogoImage { get; set; }
        public string Title { get; set; }
        public string Dates { get; set; }
        public string Description { get; set; }
        public string WebsiteURl { get; set; }
        public bool IsPosLeft { get; set; }
    }
}
