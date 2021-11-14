using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CRUDPersonas.Core.Entities
{
    public class Persona
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public long Phone { get; set; }
        public string CodeCountry { get; set; }
        public string Email { get; set; }

    }
}
