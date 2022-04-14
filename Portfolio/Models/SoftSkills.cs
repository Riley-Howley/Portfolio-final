using System.ComponentModel.DataAnnotations;
namespace Portfolio.Models
{
    public class SoftSkills
    {
        [Key]
        public int SoftSkillsID { get; set; }
        public string SoftSkillTitle { get; set; }
        public int SoftSkillpercentage { get; set; }
    }
}
