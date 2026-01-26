using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetSavingBackend.Dtos.Vet;
using PetSavingBackend.Models;

namespace PetSavingBackend.Mappers
{
    public static class VetMappers
    {
        public static ReadVetDto ToReadVetDto(this Vet vetModel)
        {
            return new ReadVetDto
            {
                Id = vetModel.Id,
                FirstName = vetModel.FirstName,
                LastName = vetModel.LastName,
                Email = vetModel.Email,
                PhoneNumber = vetModel.PhoneNumber,
                Specialization = vetModel.Specialization,
                BirthDate = vetModel.BirthDate,
                HireDate = vetModel.HireDate,
                Activity = vetModel.Activity
            };
        }

        public static Vet ToVetFromCreateDto(this CreateVetDto vetDto)
        {
            return new Vet
            {
                FirstName = vetDto.FirstName,
                LastName = vetDto.LastName,
                Email = vetDto.Email,
                PhoneNumber = vetDto.PhoneNumber,
                Specialization = vetDto.Specialization,                
                BirthDate = vetDto.BirthDate,
                HireDate = vetDto.HireDate,
                Activity = vetDto.Activity
            };
        }
    }
}