using System.Collections.Generic;

namespace EdgeOfTheEmpire.Models
{
    public class Specialization
    {
        public Specialization()
        {
            Skills = new List<SpecializationSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SpecializationSkill> Skills { get; set; }        
    }
}