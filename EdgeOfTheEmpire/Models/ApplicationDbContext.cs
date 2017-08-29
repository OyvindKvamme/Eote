using Microsoft.AspNet.Identity.EntityFramework;

namespace EdgeOfTheEmpire.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Career> Careers { get; set; }
        public System.Data.Entity.DbSet<CareerSpecialization> CareerSpecializations { get; set; }
        public System.Data.Entity.DbSet<CareerSkill> CareersSkills { get; set; }
        public System.Data.Entity.DbSet<Skill> Skills { get; set; }
        public System.Data.Entity.DbSet<Specialization> Specialications { get; set; }
        public System.Data.Entity.DbSet<SpecializationSkill> SpecialicationSkills { get; set; }
    }
}