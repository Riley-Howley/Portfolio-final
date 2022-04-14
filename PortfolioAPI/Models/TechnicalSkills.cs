using System.ComponentModel.DataAnnotations;
namespace Portfolio.Models
{
    public class TechnicalSkills
    {
        [Key]
        public int TechnicalSkillsID { get; set; }
        public string TechnicalSkillTitle { get; set; }
        public int TechnicalSkillPercentage { get; set; }
    }
}
