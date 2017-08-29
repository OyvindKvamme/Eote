using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;

namespace EdgeOfTheEmpire.Models
{
    public class Career
    {
        public Career()
        {
            Specializations = new List<CareerSpecialization>();
            Skills = new List<CareerSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        //navigation
        public virtual ICollection<CareerSpecialization> Specializations { get; set; }

        public virtual ICollection<CareerSkill> Skills { get; set; }
    }
}