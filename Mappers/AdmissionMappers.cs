using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using PetSavingBackend.Dtos.Admission;
using PetSavingBackend.Models;

namespace PetSavingBackend.Mappers
{
    public static class AdmissionMappers
    {
        public static ReadAdmissionDto ToReadAdmissionDto(this Admission admissionModel)
        {
            return new ReadAdmissionDto
            {
                Id = admissionModel.Id,
                AdmissionDate= admissionModel.AdmissionDate,
                DischargeDate= admissionModel.DischargeDate,
                AdmissionReason= admissionModel.AdmissionReason,
                CageNumber= admissionModel.CageNumber,

                Patient = new PatientSummaryDto
                {
                    Name = admissionModel.Patient.Name,
                    Species = admissionModel.Patient.Species
                },

                Vet= new VetSummaryDto
                {
                    FirstName=admissionModel.Vet.FirstName,
                    LastName=admissionModel.Vet.LastName,
                    Specialization=admissionModel.Vet.Specialization
                }
          
            };
        }

        public static Admission ToAdmissionFromCreateDto(this CreateAdmissionDto admissionDto)
        {
            return new Admission
            {
                AdmissionDate = admissionDto.AdmissionDate,
                DischargeDate = admissionDto.DischargeDate,
                AdmissionReason = admissionDto.AdmissionReason,
                CageNumber = admissionDto.CageNumber,

                // Aquí simplemente asignas los Ids
                //Son llaves foraneas 
                PatientId = admissionDto.PatientId,
                VetId = admissionDto.VetId

            };
        }
    }
}