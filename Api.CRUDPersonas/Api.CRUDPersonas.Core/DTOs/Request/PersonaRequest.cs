using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CRUDPersonas.Core.DTOs.Request
{
    public class PersonaRequest
    {
        [Required]
        [StringLength(50, ErrorMessage = "El valor debe ser menor o igual a 50 caracteres")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El valor debe ser menor o igual a 50 caracteres")]
        public string City { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El valor debe ser menor o igual a 50 caracteres")]
        public string CodeCountry { get; set; }        
        [Required]
        [StringLength(100, ErrorMessage = "El valor debe ser menor o igual a 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Formato de email incorrecto.")]
        public string Email { get; set; }

    }
}
