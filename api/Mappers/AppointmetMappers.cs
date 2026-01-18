using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using api.Dtos.Appointmet;
using api.Models;

namespace api.Mappers
{
    public static class AppointmetMappers
    {
        public static ReadAppointmetDto ToReadAppointmetDto(this Appointmet appointmetModel)
        {
            return new ReadAppointmetDto
            {
                Id= appointmetModel.Id,
                AppointmentDate= appointmetModel.AppointmentDate,
                Diagnosis=appointmetModel.Diagnosis,
                Treatment=appointmetModel.Treatment,
                Notes= appointmetModel.Notes,
                FollowUpDate=appointmetModel.FollowUpDate,

                
                Patient = new PatientSummaryDto
                {
                    Name = appointmetModel.Patient.Name,
                    Species = appointmetModel.Patient.Species

                },

                //AGREGAR CUANDO ESTÉ VET

                // Vet = new VetSummaryDto
                // {
                //     FirstName= appointmetModel.Vet.FirstName,
                //     LastName= appointmetModel.Vet.LastName
                // },

                //AGREGAR CUANDO ESTÉ Client

                // Vet = new VetSummaryDto
                // {
                //     FirstName= appointmetModel.Vet.FirstName,
                //     LastName= appointmetModel.Vet.LastName
                // }
            };
        }
        public static Appointmet ToAppointmetFromCreateDto(this CreateAppointmetDto appointmetDto)
        {
            return new Appointmet
            {
                AppointmentDate= appointmetDto.AppointmentDate,
                Diagnosis=appointmetDto.Diagnosis,
                Treatment=appointmetDto.Treatment,
                Notes= appointmetDto.Notes,
                FollowUpDate=appointmetDto.FollowUpDate,

                    //Llaves foraneas
                ClientId= appointmetDto.PatientId,
                PatientId = appointmetDto.PatientId,
                VetId = appointmetDto.VetId,
            };
        }
    }
}