using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetSavingBackend.DTOs.Vet
{
    public class UpdateVetDTO
    {
        [MaxLength(100, ErrorMessage ="El nombre no puede superar los 100 caracteres") ]
        public string? FirstName {get;set;}=string.Empty;

        [MaxLength(100, ErrorMessage ="El apellido no puede superar los 100 caracteres")]
        public string? LastName {get;set;}=string.Empty;

        [EmailAddress (ErrorMessage ="El formato del email es incorrecto")]
        [MaxLength(150, ErrorMessage ="El email no puede superar los 150 caracteres")]
        public string? Email {get;set;}=string.Empty;

        [RegularExpression (@"^\d+$", ErrorMessage ="El telefono solo puede contener numeros")]
        [MaxLength(15, ErrorMessage ="El telefono no puede superar los 15 caracteres")]
        public string? PhoneNumber {get;set;}=string.Empty;
        
        [MaxLength(100, ErrorMessage ="La especializacion no puede superar los 100 caracteres")]
        public string? Specialization {get;set;}=string.Empty;

        public DateTime? BirthDate {get;set;}

        public DateTime? HireDate {get;set;}
        
        [MaxLength(50, ErrorMessage ="La actividad no puede superar los 50 caracteres")]
        public string? Activity {get;set;}=string.Empty;
    }
}