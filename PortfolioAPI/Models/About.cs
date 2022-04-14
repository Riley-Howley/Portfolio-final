using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class About
    {
        [Key]
        public int AboutId { get; set; } 
        public string Desciption { get; set; }
    }
}
