using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using PetSavingBackend.DTOs.Appointmet;
using PetSavingBackend.Models;

namespace PetSavingBackend.Mappers
{
    public static class AppointmetMappers
    {
        public static ReadAppointmetDTO ToReadAppointmetDTO(this Appointmet appointmetModel)
        {
            return new ReadAppointmetDTO
            {
                Id= appointmetModel.Id,
                AppointmentDate= appointmetModel.AppointmentDate,
                Diagnosis=appointmetModel.Diagnosis,
                Treatment=appointmetModel.Treatment,
                Notes= appointmetModel.Notes,
                FollowUpDate=appointmetModel.FollowUpDate,

                
                Pet = new PetSummaryDTO
                {
                    Name = appointmetModel.Pet.Name,
                    Species = appointmetModel.Pet.Species

                },

                Vet = new VetSummaryDTO
                {
                    FirstName= appointmetModel.Vet.FirstName,
                    LastName= appointmetModel.Vet.LastName,
                    Specialization=appointmetModel.Vet.Specialization
                },

                Client = new ClientSummaryDTO
                {
                    FirstName= appointmetModel.Client.FirstName,
                    LastName= appointmetModel.Client.LastName,
                }
            };
        }
        public static Appointmet ToAppointmetFromCreateDTO(this CreateAppointmetDTO appointmetDTO)
        {
            return new Appointmet
            {
                AppointmentDate= appointmetDTO.AppointmentDate,
                Diagnosis=appointmetDTO.Diagnosis,
                Treatment=appointmetDTO.Treatment,
                Notes= appointmetDTO.Notes,
                FollowUpDate=appointmetDTO.FollowUpDate,

                //Llaves foraneas
                ClientId= appointmetDTO.ClientId,
                PetId = appointmetDTO.PetId,
                VetId = appointmetDTO.VetId,
            };
        }
    }
}