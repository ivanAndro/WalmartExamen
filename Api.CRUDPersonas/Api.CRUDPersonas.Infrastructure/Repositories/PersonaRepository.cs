using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.CRUDPersonas.Core.Entities;
using Api.CRUDPersonas.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Api.CRUDPersonas.Core.DTOs.Request;

namespace Api.CRUDPersonas.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {

        private readonly IConfiguration _config;
        public PersonaRepository(IConfiguration config)
        {
            _config = config;
        }

        public Persona Create(Persona persona)
        {

            using (var con = new SqlConnection(_config.GetConnectionString("defaultConnection")))
            {
                string qry = @"[dbo].[SP_Personas_Insert]";
                var parameters = new { persona.Name, persona.City, persona.Phone, persona.CodeCountry, persona.Email };
                var res = con.QuerySingle<Persona>(qry, parameters,commandType:CommandType.StoredProcedure);
                return res;
            }

        }

        public bool Delete(Guid id)
        {            
            using (var con = new SqlConnection(_config.GetConnectionString("defaultConnection")))
            {
                string qry = @"delete from personas where id = @id";
                var res = con.Execute(qry, new { id});
                return res > 0;
            }

        }

        public List<Persona> GetAll()
        {
            string qry = @"select * from personas";
            using (var con = new SqlConnection(_config.GetConnectionString("defaultConnection")))
            {
                var persona = con.Query<Persona>(qry).ToList();
                return persona;
            }
        }

        public List<Persona> GetBySearch(string City,string CodeCountry)
        {

            using (var con = new SqlConnection(_config.GetConnectionString("defaultConnection")))
            {
                string qry = @"[dbo].[SP_Personas_Search]";
                var parameters = new { City, CodeCountry };
                var res = con.Query<Persona>(qry, parameters, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }

        }


        public Persona GetById(Guid id)
        {
            string qry = @"select * from personas where id = @id";
            using (var con = new SqlConnection(_config.GetConnectionString("defaultConnection")))
            {
                var persona = con.QuerySingleOrDefault<Persona>(qry, new { id });
                return persona;
            }
        }

        public Persona Update(Persona persona)
        {
            using (var con = new SqlConnection(_config.GetConnectionString("defaultConnection")))
            {
                var pUpdate = con.ExecuteScalar<int>("select count(*) from personas where id = @Id",new { persona.Id });
                if (pUpdate == 0)
                    return null;
                string qry = @"[dbo].[SP_Personas_Update]";
                var parameters = new {persona.Id, persona.Name, persona.City, persona.Phone, persona.CodeCountry, persona.Email };
                var res = con.QuerySingle<Persona>(qry, parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
    }
}
