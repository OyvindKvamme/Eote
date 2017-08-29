using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeOfTheEmpire.Models
{
    public class CareerSpecialization
    {
        public int Id { get; set; }
        public int CareerId { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialication { get; set; }
        public virtual Career Career { get; set; }

    }
}