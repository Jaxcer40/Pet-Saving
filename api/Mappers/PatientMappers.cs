using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Admission;
using api.Dtos.Patient;
using api.Models;

namespace api.Mappers
{
    public static class PatientMappers
    {
        public static ReadPatientDto ToReadPatientDto(this Patient patientModel)
        {
            return new ReadPatientDto
            {
                Id= patientModel.Id,
                Name=patientModel.Name,
                Species=patientModel.Species,
                Breed=patientModel.Breed,
                Gender=patientModel.Gender,
                BirthDate=patientModel.BirthDate,
                Weight=patientModel.Weight,
                AdoptedDate=patientModel.AdoptedDate,

                Client= new ClientSummaryDto
                {
                    FirstName=patientModel.Client.FirstName,
                    LastName=patientModel.Client.LastName
                }
            };
        }

        public static Patient ToPatientFromCreateDto(this CreatePatientDto patientDto)
        {
            return new Patient
            {
                Name=patientDto.Name,
                Species=patientDto.Species,
                Breed=patientDto.Breed,
                Gender=patientDto.Gender,
                BirthDate=patientDto.BirthDate,
                Weight=patientDto.Weight,
                AdoptedDate=patientDto.AdoptedDate,  

                //Lave foranea a Client
                ClientId= patientDto.ClientId,
            };
        }

    }
}