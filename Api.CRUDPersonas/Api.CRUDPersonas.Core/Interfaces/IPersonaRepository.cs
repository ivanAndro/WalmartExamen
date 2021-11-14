using Api.CRUDPersonas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CRUDPersonas.Core.Interfaces
{
    public interface IPersonaRepository
    {
        Persona GetById(Guid id);
        List<Persona> GetBySearch(string City, string CodeCountry);
        List<Persona> GetAll();
        Persona Create(Persona persona);
        Persona Update(Persona persona);
        bool Delete(Guid id);

    }
}
