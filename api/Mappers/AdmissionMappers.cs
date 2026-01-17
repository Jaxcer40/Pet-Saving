using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Admission;
using api.Models;

namespace api.Mappers
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

                //AGREGAR CUANDO ESTE VET

                // Vet = new VetSummaryDto
                // {
                //     FirstName= admissionModel.Vet.FirstName,
                //     LastName= admissionModel.Vet.LastName
                // }


            };

        }
    }
}