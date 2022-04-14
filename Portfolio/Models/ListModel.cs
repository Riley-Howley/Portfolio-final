namespace Portfolio.Models
{
    public class ListModel
    {
        public IList<About> AboutModel { get; set; }
        public IList<Services> ServiceModel { get; set; }
        public IList<TechnicalSkills> TechnicalSkillsModel { get; set; }
        public IList<SoftSkills> SoftSkillsModel { get; set; }
        public IList<Experience> ExperienceModel { get; set; }
        public IList<Projects> ProjectsModel { get; set; }

    }
}
