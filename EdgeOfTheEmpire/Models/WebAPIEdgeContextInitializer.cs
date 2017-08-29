using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EdgeOfTheEmpire.Models
{
    public class WebAPIEdgeContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //Skills
            var skills = new List<Skill>
            {
                new Skill() {Name = "Astrogation", Description = "Spaceship astrogation"},
                new Skill() {Name = "Athletics", Description = "Athlete"},
                new Skill() {Name = "Coordination", Description = "Coordinate"},
                new Skill() {Name = "Mechanics", Description = "Mechanic"}
            };

            skills.ForEach(s => context.Skills.Add(s));
            context.SaveChanges();


            //Specializations
            var gamblerSpecialization = new Specialization() {Name = "Gambler"};
            var gamblerSkills = new List<SpecializationSkill>()
            {
                new SpecializationSkill() { Skill = skills[0], Specialization = gamblerSpecialization},
                new SpecializationSkill() { Skill = skills[1], Specialization = gamblerSpecialization}
                
            };
            context.Specialications.Add(gamblerSpecialization);
            gamblerSkills.ForEach(s => context.SpecialicationSkills.Add(s));
            context.SaveChanges();

            //Careers
            var smugglerCareer = new Career() { Name = "Smuggler" };
            var smugglerSpecialications = new List<CareerSpecialization>()
            {
                new CareerSpecialization() { Specialication = gamblerSpecialization, Career = smugglerCareer }
            };
            var smugglerSkills = new List<CareerSkill>()
            {
                new CareerSkill() {Skill = skills[0]},
                new CareerSkill() {Skill = skills[1]}
            };
            context.Careers.Add(smugglerCareer);
            smugglerSpecialications.ForEach(s => context.CareerSpecializations.Add(s));
            smugglerSkills.ForEach(s => context.CareersSkills.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}