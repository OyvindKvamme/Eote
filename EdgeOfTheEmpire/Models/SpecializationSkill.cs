namespace EdgeOfTheEmpire.Models
{
    public class SpecializationSkill
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int SpecializationId { get; set; }

        //navigation
        public virtual Skill Skill { get; set; }
        public virtual Specialization Specialization{ get; set; }
    }
}