using Api.CRUDPersonas.Core.DTOs.Request;
using Api.CRUDPersonas.Core.Entities;
using Api.CRUDPersonas.Core.Helpers;
using Api.CRUDPersonas.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.CRUDPersonas.Controllers
{
    /// <summary>
    /// CRUD Para entidad persona
    /// </summary>
    /// <response code="200">Respuesta correcta</response>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        /// <summary>
        /// Recupera todos los registros en la base de datos
        /// </summary>
        /// <returns></returns>
        /// <response code="204">No hubo resultados</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Persona>))]
        public IActionResult Get()
        {
            var personas = _personaRepository.GetAll();
            if (personas.Count == 0)
                return NoContent();
            return Ok(personas);
        }

        /// <summary>
        /// Recupera un registro por id
        /// </summary>
        /// <param name="id">Identificador unico a recuperar</param>
        /// <returns></returns>
        /// <response code="404">No se encontro el registro</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Persona))]
        public IActionResult GetById(Guid id)
        {
            var persona = _personaRepository.GetById(id);
            if (persona == null)
                return NotFound("No se encontro el registro solicitado");
            return Ok(persona);
        }

        /// <summary>
        /// Busca registros en la base de datos
        /// </summary>
        /// <remarks>Realiza la busqueda en base a los campos especificados</remarks>
        /// <param name="City">Busqueda por ciudad</param>
        /// <param name="CodeCountry">Busqueda por Código</param>
        /// <returns></returns>
        /// <response code="204">No hubo resultados</response>
        [HttpGet]
        [Route("Buscar")]
        public IActionResult GetBySearch(string City, string CodeCountry)
        {
            var personas = _personaRepository.GetBySearch(City, CodeCountry);
            if (personas.Count == 0)
                return NoContent();
            return Ok(personas);
        }

        /// <summary>
        /// Agrega un nuevo registro a la base de datos
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <response code="201">Registro creado</response>
        /// <response code="400">Solicitud incorrecta</response>
        [HttpPost]
        public IActionResult Post(PersonaRequest req)
        {
            var persona = _personaRepository.Create(
                new Persona
                {
                    Name = req.Name,
                    Phone = req.Phone,
                    City = req.City,
                    CodeCountry = req.CodeCountry,
                    Email = req.Email
                });
            if (persona == null)
                return BadRequest("Datos no validos");
            return CreatedAtAction(nameof(GetById),new { id = persona.Id }, persona);

        }
        /// <summary>
        /// Agrega un nuevo registro a la base de datos
        /// </summary>
        /// <param name="id">Identificador del registro a actualizar</param>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <response code="404">Registro no encontrado</response>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, PersonaRequest req)
        {
            var persona = _personaRepository.Update(
                new Persona
                {
                    Id = id,
                    Name = req.Name,
                    Phone = req.Phone,
                    City = req.City,
                    CodeCountry = req.CodeCountry,
                    Email = req.Email
                });
            if (persona == null)
                return NotFound("No se encontro el registro especificado");
            return Ok(persona);

        }

        /// <summary>
        /// Elimina un registro de la base de datos
        /// </summary>
        /// <param name="id">Identificador del registro a actualizar</param>
        /// <returns></returns>
        /// <response code="404">Registro no encontrado</response>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            var success = _personaRepository.Delete(id);
            if (!success)
                return NotFound();
            return Ok("Se ha eliminado el registro correctamente");
        }

    }
}
